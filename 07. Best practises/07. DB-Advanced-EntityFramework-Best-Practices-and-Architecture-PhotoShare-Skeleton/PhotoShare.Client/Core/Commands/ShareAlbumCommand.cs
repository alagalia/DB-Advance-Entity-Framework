using System;
using System.Data.Entity;
using PhotoShare.Client.Attributes;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class ShareAlbumCommand : Command
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

        public ShareAlbumCommand(string[] data) : base(data)
        {
        }

        //ShareAlbum <albumId> <username> <permission>
        //For example:
        //ShareAlbum 4 dragon321 Owner
        //ShareAlbum 4 pesho Viewer
        public override string Execute()
        {
            int albumId = int.Parse(Data[1]);
            string userName = Data[2];
            string permission = Data[3];

            Album album = unit.Albums.FirstOrDefaultWhere(al => al.Id == albumId);
            User user = unit.Users.FirstOrDefaultWhere(u => u.Username == userName);
            Role role = (Role)Enum.Parse(typeof(Role), permission);
            AlbumRole albumRole = new AlbumRole() { Album = album, User = user, Role = role };
            unit.AlbumRoles.Add(albumRole);
            if (user == null)
            {
                throw new ArgumentException($"No such username /{userName}/ in the DB");
            }
            user.AlbumRoles.Add(albumRole);
            unit.Save();
            return $"User {userName} is {permission} to album '{album.Name}'";
        }
    }
}
