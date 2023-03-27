using System.Collections.Generic;

namespace Kaif
{
    public class SaladsList
    {
        public static List<Dish> GetSaladsList()
        {
            List<Dish> Salads = new List<Dish>()
            {
                new Dish("sałatka z kurczaka", 30.99),
                new Dish("sałatka z krewetek i grejpfrutem", 38.99),
                new Dish("sałatka z wołowiną i bakłażanem", 35.99),


            };
            return Salads;
        }
    }
}
