using System.Collections.Generic;

namespace Kaif
{
    public class DesertyList
    {
        public static List<Dish> GetDesertyList()
        {
            List<Dish> Deserty = new List<Dish>()
            {
                new Dish("sernik", 19.99),
                new Dish("panna cotta z sosem porzeczkowym ", 24.99),
            };
            return Deserty;
        }
    }
}
