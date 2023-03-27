using System.Collections.Generic;

namespace Kaif
{
    public class SoupsList
    {
        public static List<Dish> GetSoupsList()
        {
            List<Dish> Soups = new List<Dish>()
            {
                new Dish("zupa pomidorowa", 16.99),
                new Dish("zupa grzybowa", 16.99),
                new Dish("zupa serowa", 16.99),
            };
            return Soups;
        }
    }
}
