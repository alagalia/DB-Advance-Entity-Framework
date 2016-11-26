using System.Collections.Generic;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class AddTagToCommand : Command
    {
        public AddTagToCommand(string[] data) : base(data)
        {
        }

        //AddTagTo <albumName> <tag>
        public override string Execute()
        {
            string albumName = Data[2];
            string tagName = Data[2].ValidateOrTransform();

            Album album = unit.Albums.FirstOrDefaultWhere(a => a.Name == albumName);
            Tag tag = new Tag() {Name = tagName};
            if (album == null)
            {
                unit.Albums.Add(new Album()
                {
                    Name = albumName,
                    Tags = new List<Tag>() {tag}
                });
            }
            else
            {
                album.Tags.Add(tag);
            }
            

            return $" {albumName} was added secessful in album database and {tagName} was added sucessfully to tag database.";
        }
    }
}
