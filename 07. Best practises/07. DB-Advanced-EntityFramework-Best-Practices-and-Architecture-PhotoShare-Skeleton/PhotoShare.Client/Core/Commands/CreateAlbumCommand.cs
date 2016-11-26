using System;
using System.Collections.Generic;
using System.Linq;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class CreateAlbumCommand : Command
    {

        public CreateAlbumCommand(string[] data) : base(data)
        {
        }

        //CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public override string Execute()
        {
            string username = Data[1];
            string albumeTitle = Data[2];

            string bgColor = Data[3];

            IEnumerable<Tag> tags = Data.Skip(4).Select(t => new Tag() { Name = t });

            User user = unit.Users.FirstOrDefaultWhere(u => (u.Username.ToLower() == username.ToLower()));

            Color backgroundColor = (Color)Enum.Parse(typeof(Color), bgColor);
            Album album = new Album
            {
                BackgroundColor = backgroundColor,
                Name = albumeTitle,
                Tags = tags.ToArray()
            };


            AlbumRole albumRole = new AlbumRole() { Album = album, User = user, Role = Role.Owner };

            user.AlbumRoles.Add(albumRole);

            unit.Albums.Add(album);

            return $"{albumeTitle} was added to database";
        }
    }
}
