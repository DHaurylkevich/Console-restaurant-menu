using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaif
{
    public class DaniaGłówneList
    {
        public static List<Dish> GetDaniaGłówneList()
        {
            List<Dish> DaniaGłówne = new List<Dish>()
            {
                new Dish("owoce morza w sosie śmietankowym", 40.99),
                new Dish("pasta z kurczakiem i pieczarkami  ", 32.99),
                 new Dish("pasta z łososiem i małżami", 32.99),
                 new Dish("grillowane żeberka w sosie barbecue", 40.99),
                 new Dish("stek z łososia z pomidorkami koktajlowymi", 32.99),
            };
            return DaniaGłówne;
        }
    }
}
