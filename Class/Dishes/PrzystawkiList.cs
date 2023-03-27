using System.Collections.Generic;

namespace Kaif
{
    public class PrzystawkiList
    {
        public static List<Dish> GetPrzystawkiList()
        {
            List<Dish> Przystawki = new List<Dish>()
            {
                new Dish("stripsy z kurczaka", 28.99),
                new Dish("krążki cebulowe", 20.99),
                 new Dish("krążki kalmarów", 22.99),
                  new Dish("pałeczki serowe", 22.99),
                   new Dish("skrzydełka z kurczaka ", 27.99),
                    new Dish("deska serów", 35.99),
                     new Dish("deska mięsna", 35.99),
                      new Dish("deska owocowa", 30.99),

            };
            return Przystawki;
        }
    }
}
