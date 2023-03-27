using System;
using System.Collections.Generic;
using System.Linq;

namespace Kaif
{
    internal class Program
    {
        static void Main()
        {
            RunMenu();
            Console.ReadKey();
        }


        public static void RunMenu()
        {
            MenuUI menuUI = new MenuUI();
            Order order = new Order();
            Category category = new Category();
            Receipt receipt = new Receipt();

            int state = -1;

            FillMenu();            
            int counter = Category.categories.Count();

            menuUI.ShowStartMenu();

            while (state != 0)
            {
                state = menuUI.ShowCategoryMenu(Category.categories, order);
                if (state > 0 && state <= counter)
                {
                    menuUI.ShowDishesMenu(state, category, order);
                }
                if (state == counter + 1)
                {
                    order.VoidingRemoveDishFromOrder(order, menuUI);
                }
                else if (state == counter + 2)
                {
                    state = menuUI.ShowReceiptAndPayd(order);
                }
                else if (state == counter + 3)
                {
                    menuUI.ShowHisitory(receipt);
                }
            }
            Console.WriteLine("Dowidzinia! (^_^)");
        }

        public static void FillMenu() //////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            Category.categories = new List<Category>
            {
                new Category("Salatki", SaladsList.GetSaladsList()),
                new Category("Zupy", SoupsList.GetSoupsList()),
                new Category("Dania główne", MainDishesList.GetMainDishesList()),
                new Category("Deserty", DessertsList.GetDessertsList()),
                new Category("Napoje", DrinksList.GetDrinksList()),
                new Category("Napoje alkoholowe", AlcoholList.GetAlcoholList()),
            };

        }
    }
}