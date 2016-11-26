using System;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class MakeFriendsCommand : Command
    {

        public MakeFriendsCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            //unit;
            //bidirectional adding friends
            //MakeFriends <username1> <username2>
            string userName1 = Data[1];
            string userName2 = Data[2];
            User user1 = unit.Users.FirstOrDefaultWhere(u => u.Username == userName1);
            User user2 = unit.Users.FirstOrDefaultWhere(u => u.Username == userName2);
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            unit.Save();
            return $"User {userName1} has alreday have friends {userName2} and vice verse";
        }
    }
}
