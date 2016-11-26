using System;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class ModifyAlbumCommand : Command
    {
        
        public ModifyAlbumCommand(string[] data) : base(data)
        {
        }

        //ModifyAlbum <albumId> <property> <new value>
        //For example
        //ModifyAlbum 4 Name <new name>
        //ModifyAlbum 4 BackgroundColor <new color>
        //ModifyAlbum 4 IsPublic <True/False>
        public override string Execute()
        {
            string resultOfTheOperation = string.Empty;
            int albumId = int.Parse(Data[1]);

            Album album = unit.Albums.FirstOrDefaultWhere(al => al.Id == albumId);

            string property = Data[2];
            string value = Data[3];
            switch (property)
            {
                case "Name":
                    album.Name = value;
                    resultOfTheOperation = $"Name of the album was updated to {value}";
                    break;
                case "BackgroundColor":
                    album.BackgroundColor = (Color?) Enum.Parse(typeof (Color), value);
                    resultOfTheOperation = $"Color of the album was updated in database to {value}";
                    break;
                case "IsPublic":
                    album.IsPublic = bool.Parse(value);
                    resultOfTheOperation = $"Album`s status 'IsPublic' was updated to {value}";
                    break;
            }

            unit.Save();
            return resultOfTheOperation;

        }
    }
}
