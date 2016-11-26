using System;
using System.Data.Entity;
using PhotoShare.Client.Attributes;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class UploadPictureCommand : Command
    {
       

        public UploadPictureCommand(string[] data) : base(data)
        {
        }

        //UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public override string Execute()
        {
            string albumName = Data[1];
            string title = Data[2];
            string pictureFilePath = Data[3];
            Album album = unit.Albums.FirstOrDefaultWhere(al => al.Name == albumName);
            Picture pic = new Picture() {Title = title, Path = pictureFilePath};
            pic.Albums.Add(album);
            album.Pictures.Add(pic);
            unit.Save();
            return $"Picture with name {title} was added to the databse in album '{album.Name}'";
        }
    }
}
