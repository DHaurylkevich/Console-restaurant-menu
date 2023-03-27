using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaif
{
    public class NapojeAlkoholoweList
    {
        public static List<Drinks> GetNapojeAlkoholoweList()
        {
            List<Drinks> NapojeAlkoholowe = new List<Drinks>()
            {
                new Drinks("piwo jasne", 25.99),
                new Drinks("piwo ciemne", 25.99),
                 new Drinks("piwo pszeniczne", 25.99),
                  new Drinks("whiski&cola", 25.99),
                   new Drinks("gin&tonik", 25.99),
                    new Drinks("rum&cola", 25.99),



            };
            return NapojeAlkoholowe;
        }
    }
}
