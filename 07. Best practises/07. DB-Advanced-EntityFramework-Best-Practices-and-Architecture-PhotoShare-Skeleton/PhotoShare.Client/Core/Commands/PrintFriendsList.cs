using System;
using System.Data.Entity;
using System.Linq;
using PhotoShare.Client.Attributes;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class PrintFriendsListCommand : Command
    {
        public PrintFriendsListCommand(string[] data) : base(data)
        {
        }

        //PrintFriendsList <username>
        public override string Execute()
        {
            string userName = Data[1];
            User user = unit.Users.FirstOrDefaultWhere(u => u.Username == userName);
            string friends = string.Join(", ", user.Friends.Select(u=>u.Username));
            return friends;
        }
    }
}
