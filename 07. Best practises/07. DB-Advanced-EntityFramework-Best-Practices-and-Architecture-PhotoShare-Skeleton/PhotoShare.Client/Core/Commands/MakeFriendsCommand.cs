using System;

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
            throw new NotImplementedException();
        }
    }
}
