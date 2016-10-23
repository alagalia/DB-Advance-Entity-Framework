namespace MiniORM.Entities
{
    using System;

    using MiniORM.Attributes;

    [Entity(TableName = "Users")]
    public class User
    {
        [Id]    
        private int id;

        [Column(ColomnName = "Username")]
        private string username;

        [Column(ColomnName = "Pass")]
        private string password;

        [Column(ColomnName = "Age")]
        private int age;

        [Column(ColomnName = "registrationDate")]
        private DateTime registerationDate;

       public User(string username, string password, int age, DateTime registerationDate)
        {
            this.Username = username;
            this.Password = password;
            this.Age = age;
            this.RegisterationDate = registerationDate;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }


        public DateTime RegisterationDate
        {
            get
            {
                return this.registerationDate;
            }

            set
            {
                this.registerationDate = value;
            }
        }

    }
}
