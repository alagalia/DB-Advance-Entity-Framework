using System;
using System.Data.Entity;
using PhotoShare.Client.Attributes;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class ModifyUserCommand : Command
    {
        [Inject]
        private PhotoShareContext context;
        [Inject]
        private DbSet<User> users;
        [Inject]
        private DbSet<Album> albums;
        [Inject]
        private DbSet<Picture> pictures;
        [Inject]
        private DbSet<Tag> tags;
        [Inject]
        private DbSet<AlbumRole> albumRoles;
        [Inject]
        private DbSet<Town> towns;

        public ModifyUserCommand(string[] data) : base(data)
        {
        }

        //ModifyUser <username> <property> <new value>
        //For example:
        //ModifyUser <username> Password <NewPassword>
        //ModifyUser <username> Email <NewEmail>
        //ModifyUser <username> FirstName <NewFirstName>
        //ModifyUser <username> LastName <newLastName>
        //ModifyUser <username> BornTown <newBornTownName>
        //ModifyUser <username> CurrentTown <newCurrentTownName>
        //!!! Cannot change username
        public override string Execute()
        {
            string resultOfTheOperation = string.Empty;
            string userName = Data[1];
            User user = unit.Users.FirstOrDefaultWhere(u => u.Username == userName);

            string property = Data[2];
            string value = Data[3];
            switch (property.ToLower())
            {
                case "password":
                    user.Password = value;
                    resultOfTheOperation = $"Password of the user was updated to {value}";
                    break;
                case "email":
                    user.Email = value;
                    resultOfTheOperation = $"Email of the user was updated in database to {value}";
                    break;
                case "firstName":
                    user.FirstName = value;
                    resultOfTheOperation = $"User`s first name was updated to {value}";
                    break;
                case "lastName":
                    user.LastName = value;
                    resultOfTheOperation = $"User`s last name  was updated to {value}";
                    break;
                case "bornTown":
                    Town bornTown = unit.Towns.FirstOrDefaultWhere(t => t.Name == value) ?? new Town() {Name = value};
                    user.BornTown = bornTown;
                    resultOfTheOperation = $"Born town was updated to {value}";
                    break;
                case "currentTown":
                    Town currentTown = unit.Towns.FirstOrDefaultWhere(t => t.Name == value) ?? new Town() { Name = value };
                    user.CurrentTown = currentTown;
                    resultOfTheOperation = $"Born town was updated to {value}";
                    break;
            }

            unit.Save();
            return resultOfTheOperation;
        }
    }
}
