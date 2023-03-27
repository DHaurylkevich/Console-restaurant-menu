using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaif
{
    public class MainDishesList
    {
        public static List<Dish> GetMainDishesList()
        {
            List<Dish> MainDishes = new List<Dish>()
            {
                new Dish("owoce morza w sosie śmietankowym", 40.99),
                new Dish("pasta z kurczakiem i pieczarkami  ", 32.99),
                new Dish("pasta z łososiem i małżami", 32.99),
                new Dish("grillowane żeberka w sosie barbecue", 40.99),
                new Dish("stek z łososia z pomidorkami koktajlowymi", 32.99),
            };
            return MainDishes;
        }
    }
}
