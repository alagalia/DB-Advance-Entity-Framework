using System.Data.Entity;
using System.Linq;

namespace _03.HotelDatabase
{
    class HotelMain
    {
        static void Main()
        {
            HotelContext context = new HotelContext();
            context.Rooms.Count();
        }
    }
}
