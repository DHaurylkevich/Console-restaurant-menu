using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaif
{
    public class AlcoholList
    {
        public static List<Dish> GetAlcoholList()
        {
            List<Dish> Alcohol = new List<Dish>()
            {
                new Dish("piwo jasne", 25.99),
                new Dish("piwo ciemne", 25.99),
                new Dish("piwo pszeniczne", 25.99),
                new Dish("whiski&cola", 25.99),
                new Dish("gin&tonik", 25.99),
                new Dish("rum&cola", 25.99),



            };
            return Alcohol;
        }
    }
}
