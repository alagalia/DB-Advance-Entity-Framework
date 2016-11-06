using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.First_Letter_in_Gringotts_DB
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (GringottsContext context = new GringottsContext())
            {
                var wiz = context.WizzardDeposits.Where(w => w.DepositGroup == "Troll Chest").Select(w=>w.FirstName).Distinct();
                foreach (var w in wiz)
                {
                    Console.WriteLine(w[0]);
                }
            }
        }
    }
}
