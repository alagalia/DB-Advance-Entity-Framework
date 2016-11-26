using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using PhotoShare.Client.Attributes;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class UploadProfilePictureCommand : Command
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

        public UploadProfilePictureCommand(string[] data) : base(data)
        {
        }

        //UploadProfilePicture <username> <pictureFilePath>
        public override string Execute()
        {
            string userName = Data[1];
            string pictureFilePath = Data[2];

            byte[] bytes;
            using (StreamReader reader = new StreamReader(pictureFilePath))
            {

                using (var memstream = new MemoryStream())
                {
                    reader.BaseStream.CopyTo(memstream);
                    bytes = memstream.ToArray();
                }
            }
            User user = unit.Users.FirstOrDefaultWhere(u => u.Username == userName);
            user.ProfilePicture = bytes;
            File.WriteAllBytes("testResult.txt", bytes);
            unit.Save();

            return $"Profile Picture of '{userName}' was added to the databse";
        }
    }
}
