using FootballBettingData;

namespace FootballBettingDatabase
{
    class Program
    {
        static void Main()
        {   
            FootballBettingContext context = new FootballBettingContext();
            context.Database.Initialize(true);
        }
    }
}
