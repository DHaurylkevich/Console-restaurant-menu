using System.Collections.Generic;

namespace Kaif
{
    public class DessertsList
    {
        public static List<Dish> GetDessertsList()
        {
            List<Dish> Desserts = new List<Dish>()
            {
                new Dish("sernik", 19.99),
                new Dish("panna cotta z sosem porzeczkowym ", 24.99),
            };
            return Desserts
               ;
        }
    }
}
