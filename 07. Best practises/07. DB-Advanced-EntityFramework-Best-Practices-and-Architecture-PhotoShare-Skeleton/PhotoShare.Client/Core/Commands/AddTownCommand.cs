using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class AddTownCommand : Command
    {
        public AddTownCommand(string[] data) : base(data)
        {
        }

        //AddTown <townName> <countryName>
        public override string Execute()
        {
            string townName = Data[1];
            string country = Data[2];

            Town town = new Town()
            {
                Name = townName,
                Country = country
            };

            unit.Towns.Add(town);

            return townName + " was added to database in country " + country;
        }
    }
}
