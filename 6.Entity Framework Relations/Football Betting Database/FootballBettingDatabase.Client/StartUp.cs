
using FootballBettingdatabase.Database;

namespace FootballBettingDatabase.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            BetContext context = new BetContext();
            //context.Database.Initialize(true);
        }
    }
}
