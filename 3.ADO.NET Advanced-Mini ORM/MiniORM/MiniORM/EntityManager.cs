namespace MiniORM
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using CustomORM.Core;

    using MiniORM.Attributes;

    public class EntityManager : IDbContext
    {
       private SqlConnection connection;

        private string connectionString;

        private bool isCodeFirst;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;
        }
            
        public bool Persist(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot persist null entity!");
            }

            if (this.isCodeFirst && !this.IfTableExist(entity.GetType()))
            {
                this.CreateTable(entity.GetType());
            }

            Type entityType = entity.GetType();
            FieldInfo idInfo = this.GetId(entityType);
            int id = (int)idInfo.GetValue(entity);

            if (id <= 0)
            {
                // insert object
                return this.Insert(entity, idInfo);
            }

            return this.Update(entity, idInfo);
        }


        private bool Update(object entity, FieldInfo fieldInfo)
        {
            int numberOfAffectedRows = 0;

            string updatenString = this.PrepareEntityUpdateString(entity, fieldInfo);
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertionCommand = new SqlCommand(updatenString, connection);
                numberOfAffectedRows = insertionCommand.ExecuteNonQuery();
            }
            return numberOfAffectedRows > 0;
        }

        private string PrepareEntityUpdateString(object entity, FieldInfo idInfo)
        {
            StringBuilder updateStringBuilder = new StringBuilder();
            updateStringBuilder.Append($"UPDATE {GetTableName(entity.GetType())} SET ");

            StringBuilder tableSettings = new StringBuilder();
            FieldInfo[] columnsInfo = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();

            foreach (FieldInfo columnField in columnsInfo)
            {
                string columnValue = columnField.GetValue(entity).ToString();

                if (GetTypeToDB(columnField) == "datetime")
                {
                    columnValue = ConvertDataTimeToDB(columnValue);
                }
                else
                {
                    columnValue = $"'{columnValue}'";
                }

                tableSettings.Append($"{this.GetColumnName(columnField)} = {columnValue}, ");
            }

            tableSettings.Remove(tableSettings.Length - 2, 2);
            updateStringBuilder.Append(tableSettings);
            updateStringBuilder.Append($" WHERE Id = {idInfo.GetValue(entity)}");

            return updateStringBuilder.ToString();
        }

        private bool Insert(object entity, FieldInfo idInfo)
        {
            int numberOfAffectedRows = 0;

            string insertionString = this.PrepareInsertionEntityString(entity);
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertionCommand = new SqlCommand(insertionString, connection);
                numberOfAffectedRows = insertionCommand.ExecuteNonQuery();

                //fix number of local entity Id 
                string queryforLastIdInDb = $"SELECT MAX(Id) FROM {GetTableName(entity.GetType())}";
                SqlCommand commandForGetLastId = new SqlCommand(queryforLastIdInDb, connection);
                int lastId = (int)commandForGetLastId.ExecuteScalar();

                // set value to field 
                idInfo.SetValue(entity, lastId);
            }
            return numberOfAffectedRows > 0;
        }

        private string PrepareInsertionEntityString(object entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"INSERT INTO {GetTableName(entity.GetType())} ( ");

            FieldInfo[] columnsInfo = entity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();

            foreach (FieldInfo columnField in columnsInfo)
            {
                sb.Append($"{this.GetColumnName(columnField)}, ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(") VALUES ( ");

           foreach (FieldInfo columnField in columnsInfo)
            {
                if (GetTypeToDB(columnField) == "datetime")
                {
                    string convertedData = ConvertDataTimeToDB(columnField.GetValue(entity).ToString());
                    sb.Append(convertedData + ", ");
                }
                else
                {
                    sb.Append($"'{columnField.GetValue(entity)}', ");
                }
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            return sb.ToString();
        }

        private string ConvertDataTimeToDB(string value)
        {
            string date = value.Split(' ')[0];
            string[] allpartsOfDate = date.Split('.');
            return "CONVERT(datetime,'" + allpartsOfDate[1] + "." + allpartsOfDate[0] +"."+allpartsOfDate[2] +"')";
        }

        private bool IfTableExist(Type type)
        {
            int numberOfTables = 0;
            string query = "SELECT COUNT(name) " + 
                             "FROM sys.sysobjects "
                           + $"WHERE [Name] = '{this.GetTableName(type)}' AND [xtype] = 'U'";
            using (this.connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query, this.connection);
                numberOfTables = (int)command.ExecuteScalar();
            }

            return numberOfTables > 0;
        }

        public T FindById<T>(int id)
        {
            T foundObject = default (T);
            string query = $"SELECT * FROM {this.GetTableName(typeof (T))} WHERE Id = {id}";
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                foundObject = CreateEntity<T>(reader);
            }

            return foundObject;
        }

        private T CreateEntity<T>(SqlDataReader reader)
        {
            object[] colums = new object[reader.FieldCount];
            reader.GetValues(colums);

            Type[] columnTypes = new Type[colums.Length-1];
            object[] fieldValues = new object[colums.Length-1];

            for (int i = 1; i < colums.Length; i++)
            {
                columnTypes[i - 1] = colums[i].GetType();
                fieldValues[i - 1] = colums[i];
            }

           T createdObject = (T)typeof(T).GetConstructor(columnTypes).Invoke(fieldValues);
            FieldInfo idInfo = createdObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance )
                .FirstOrDefault(x => x.IsDefined(typeof (IdAttribute)));
            idInfo.SetValue(createdObject, colums[0]);

            return createdObject;
        }

        public IEnumerable<T> FindAll<T>()
        {
           return FindAll<T>(null);
        }

        public IEnumerable<T> FindAll<T>(string @where)
        {
            string query = $"SELECT * FROM {this.GetTableName(typeof(T))}";

            if (@where != null)
            {
                query += " " + @where;
            }
            List<T> foundEntities = new List<T>();
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundEntities.Add(CreateEntity<T>(reader));
                }
            }
            
            return foundEntities;
        }

        public T FindFirst<T>()
        {
            return FindFirst<T>(null);
        }

        public T FindFirst<T>(string @where)
        {
            string query = $"SELECT TOP 1 * FROM {this.GetTableName(typeof(T))}";

            if (@where != null)
            {
                query += " " + @where;
            }
            List<T> foundEntities = new List<T>();
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foundEntities.Add(CreateEntity<T>(reader));
                }
            }

            return foundEntities[0];
        }

        public void Delete<T>(object entity)
        {
            FieldInfo idInfo = GetId(entity.GetType());
            int id = (int)idInfo.GetValue(entity);
            DeleteById<T>(id);
        }

        public void DeleteById<T>(int id)
        {
            string query = $"DELETE FROM {this.GetTableName(typeof(T))} WHERE Id = @id";

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int afectedRows = command.ExecuteNonQuery();

                if (afectedRows == 0)
                {
                    throw new ArgumentException($"Id not found!");
                }
            }
        }

        // additional methods
        private void CreateTable(Type entity)
        {
            string creationString = this.PrepareTableCreationString(entity);
            using (connection = new SqlConnection(this.connectionString))
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(creationString, this.connection);
                command.ExecuteNonQuery();
            }
        }

        private string PrepareTableCreationString(Type entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CREATE TABLE {this.GetTableName(entity)} (");
            sb.Append($"Id INT PRIMARY KEY IDENTITY (1,1), ");

            FieldInfo[] columnsInfo = entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();

            foreach (FieldInfo columnField in columnsInfo)
            {
                sb.Append($"{this.GetColumnName(columnField)} {this.GetTypeToDB(columnField)}, ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            return sb.ToString();
        }

        private string GetTypeToDB(FieldInfo fieldInfo)
        {
            switch (fieldInfo.FieldType.Name)
            {
                case "Int32":
                    return "int";
                case "String":
                    return "VARCHAR(max)";
                case "DateTime":
                    return "datetime";
                case "Boolean":
                    return "bit";
                default: throw new ArgumentException("No such type.");
            }
        }

        private FieldInfo GetId(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Passed entity is null!");
            }

            FieldInfo id =
                entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.IsDefined(typeof(IdAttribute)));
            if (id == null)
            {
                throw new ArgumentNullException("Id cannot be null!");
            }

            return id;
        }

        private string GetTableName(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Passed entity is null!");
            }

            if (!entity.IsDefined(typeof(EntityAttribute)))
            {
                throw new ArgumentNullException("Name of the table cannot be null!");
            }

            string tableName = entity.GetCustomAttribute<EntityAttribute>().TableName;

            if (tableName == null)
            {
                throw new ArgumentNullException("Name of the table cannot be null!");
            }

            return tableName;
        }

        private string GetColumnName(FieldInfo field)
        {
            if (field == null)
            {
                throw new ArgumentNullException("Passed field is null!");
            }

            if (!field.IsDefined(typeof(ColumnAttribute)))
            {
                return field.Name;
            }
            

            string columnName = field.GetCustomAttribute<ColumnAttribute>().ColomnName;
            if (columnName == null)
            {
                throw new ArgumentNullException("Column name cannot be null!");
            }

            return columnName;
        }
    }
}
