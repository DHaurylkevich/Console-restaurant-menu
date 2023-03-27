using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaif
{
    public class KawaList
    {
        public static List<Dish> GetKawaList()
        {
            List<Dish> Kawa = new List<Dish>()
            {
                new Dish("americano", 11.99),
                new Dish("espresso", 9.99),
                 new Dish("capuccino", 12.99),
                  new Dish("latte", 15.99),



            };
            return Kawa;
        }
    }
}
