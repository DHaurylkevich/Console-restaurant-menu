using System.Collections.Generic;

namespace Kaif
{
    public class NapojeList
    {
        public static List<Drinks> GetNapojeList()
        {
            List<Drinks> Napoje = new List<Drinks>()
            {
                new Drinks("cola", 6.99),
                new Drinks("cola zero", 6.99),
                 new Drinks("fanta", 6.99),
                  new Drinks("sprite", 6.99),
                   new Drinks("red bull", 8.99),
                    new Drinks("koktajl mleczny z Snickersa", 15.99),



            };
            return Napoje;
        }
    }
}
