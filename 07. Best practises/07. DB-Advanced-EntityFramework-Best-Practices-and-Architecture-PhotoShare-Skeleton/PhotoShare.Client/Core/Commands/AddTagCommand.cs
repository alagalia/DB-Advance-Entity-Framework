using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class AddTagCommand : Command
    {
        
        public AddTagCommand(string[] data) : base(data)
        {
        }

        //AddTag <tag>
        public override string Execute()
        {
            string tag = Data[1].ValidateOrTransform();

            unit.Tags.Add(new Tag
            {
                Name = tag
            });

            return tag + " was added sucessfully to database";
        }
    }
}
