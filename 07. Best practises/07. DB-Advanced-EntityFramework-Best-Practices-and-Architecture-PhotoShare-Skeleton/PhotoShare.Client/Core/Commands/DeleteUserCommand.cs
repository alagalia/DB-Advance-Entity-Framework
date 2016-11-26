using System;

namespace PhotoShare.Client.Core.Commands
{
    public class DeleteUserCommand : Command
    {

        public DeleteUserCommand(string[] data) : base(data)
        {
        }

        //DeleteUser <username>
        public override string Execute()
        {
            string username = Data[1];
            var user = unit.Users.FirstOrDefaultWhere(u => u.Username == username);
            if(user == null)
            {
                throw new InvalidOperationException($"User with {username} was not found");
            }
            
            user.IsDeleted = true;
            unit.Save();

            return $"User {username} was deleted from the databse"; 
        }
    }
}
