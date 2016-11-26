using System;
using System.Data.Entity;
using PhotoShare.Client.Attributes;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class PrintFriendsListCommand : Command
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

        public PrintFriendsListCommand(string[] data) : base(data)
        {
        }

        //PrintFriendsList <username>
        public override string Execute()
        {
            //TODO prints all friends of user with given username
            throw new NotImplementedException();
        }
    }
}
