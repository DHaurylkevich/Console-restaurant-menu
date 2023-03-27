using System.Collections.Generic;

namespace Kaif
{
    public class DrinksList
    {
        public static List<Dish> GetDrinksList()
        {
            List<Dish> Drinks = new List<Dish>()
            {
                new Dish("cola", 6.99),
                new Dish("cola zero", 6.99),
                new Dish("fanta", 6.99),
                new Dish("sprite", 6.99),
                new Dish("red bull", 8.99),
                new Dish("koktajl mleczny z Snickersa", 15.99),



            };
            return Drinks;
        }
    }
}
