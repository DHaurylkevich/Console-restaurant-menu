using System.Collections.Generic;

namespace Kaif
{
    public class BourgersList
    {
        public static List<Dish> GetBourgerList()
        {
            List<Dish> Bourgers = new List<Dish>()
            {
                new Dish("Bourger", 11),                
                new Dish("Chees Bourder", 12)
            };
            return Bourgers;
        }
    }
}
