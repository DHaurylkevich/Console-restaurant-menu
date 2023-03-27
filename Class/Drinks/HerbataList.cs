using System.Collections.Generic;

namespace Kaif
{
    public class HerbataList
    {
        public static List<Drinks> GetHerbataList()
        {
            List<Drinks> Herbata = new List<Drinks>()
            {
                new Drinks("czarna herbata", 14.99),
                new Drinks("zielona herbata ", 14.99),
                 new Drinks("herbata z jagód leśnych", 14.99),
                  new Drinks("herbata brzoskwinka - mango", 14.99),
                   new Drinks("herbata melon - mięta", 14.99),
            };
            return Herbata;
        }
    }
}
