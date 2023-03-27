using System;
using System.Collections.Generic;
using System.Linq;

namespace Kaif
{
    public class MenuUI
    {
        public void DisplayLogo()
        {
            string logo = @"
 ___  __    ________  ___  ________ 
|\  \|\  \ |\   __  \|\  \|\  _____\
\ \  \/  /|\ \  \|\  \ \  \ \  \__/ 
 \ \   ___  \ \   __  \ \  \ \   __\
  \ \  \\ \  \ \  \ \  \ \  \ \  \_|
   \ \__\\ \__\ \__\ \__\ \__\ \__\ 
    \|__| \|__|\|__|\|__|\|__|\|__| 
";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(logo);
            Console.ResetColor();
        }

        public void ShowStartMenu()
        {
            DisplayLogo();
            Console.WriteLine("Witamy w restauracji!");

            Console.WriteLine("Naciśnij dowolny przycisk, aby rozpocząć!");
            Console.ReadKey();
        }

        public int ShowCategoryMenu(List<Category> categories, Order order)
        {
            Console.Clear();
            DisplayLogo();
            ShowOrderItem(order);
            Console.WriteLine("-------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Categories: ");
            Console.ResetColor();

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, categories[i].Name);
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("[{0}] Usunąć danie z zamówienia\n[{1}] Przejdź do podsumowania\n[{2}] Historia zamówień\n[0] Wyjść", categories.Count + 1, categories.Count + 2, categories.Count + 3);

            int selection = ReadCorrectNumber(categories.Count + 3);
            return selection;
        }

        public void ShowDishesMenu(int num, Category category, Order order)
        {
            int selectedCategoryIndex = num - 1;
            var selectedCategory = Category.categories[selectedCategoryIndex];

            num = category.SelectAge(num);
            while (num != 0)
            {            


                Console.Clear();
                Console.Write("-----------------------");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("{0}", selectedCategory.Name);
                Console.ResetColor();
                Console.Write("-----------------------\n");
                Console.WriteLine("Dishes:");
                category.ShowDishonCategoryList(selectedCategory.Dishes);
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("[0] Powrót do kategorii ");
                Console.Write("Wybierz: ");

                int selectedDishIndex = ReadCorrectNumber(selectedCategory.Dishes.Count);
                if (selectedDishIndex == 0)
                {
                    break;
                }
                else
                {
                    order.AddDishToOrder(selectedCategory.Dishes[selectedDishIndex - 1]);
                }
            }
        }

        public void ShowOrderItem(Order order)
        {
            if (order.OrdersList.Count() != 0)
            {
                int i = 1;

                Console.Write("----------------------");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Zamówienie");
                Console.ResetColor();
                Console.Write("-----------------------\n");
                
                foreach (Order ord in order.OrdersList)
                {
                    Console.WriteLine("  [{0}] {1} - {2} zl x {3} = {4} zl", i, ord.Name, ord.Price, ord.Quantity, ord.Price * ord.Quantity);
                    i++;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  Total: " + order.GetTotalPrice() + " zl");
                Console.ResetColor();
                Console.WriteLine("-------------------------------------------------------");
            }
        }

        public int ShowReceiptAndPayd(Order order)
        {
            Console.Clear();
            if (order.OrdersList.Count() == 0)
            {
                Console.WriteLine("Zamówienie jest puste");
                Console.WriteLine("Naciśnij dowolny klawisz, żeby wrócić do menu...");
                Console.ReadKey();
                return 1;
            }
            else
            {
                Console.WriteLine("--------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Zamówienie:");
                Console.ResetColor();
                int i = 1;
                foreach (Order ord in order.OrdersList)
                {
                    Console.WriteLine("#[{0}] {1} - {2} zl", i++, ord.Name, ord.Price);
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Total: {0} zl", order.GetTotalPrice());
                Console.ResetColor();
                Console.WriteLine("--------------------------------------------------");
                int state = PaydMethod(order);
                return state; ;
            }
        }

        public int PaydMethod(Order order)
        {
            Console.WriteLine("[1] Opłata kartą\n[2] Opłata gotówką\n[0] Wrócić do menu");
            Receipt r = new Receipt();

            int num = ReadCorrectNumber(2);
            switch (num)
            {
                case 1:
                    r.SaveToFile(order);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Przybliż kartu do terminała");
                    Console.ResetColor();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                    Console.WriteLine("Dziękujemy!");
                    return 0;

                case 2:
                    r.SaveToFile(order);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Podejdź do kasy i zapłać");
                    Console.ResetColor();
                    Console.WriteLine("Dziękujemy!");
                    return 0;

                case 0:
                    return 1;
            }
            return 0;
        }

        public void ShowHistoryOrder(Receipt receipt)
        {
            var orderHistory = receipt.LoadHistoryOrderFile();
            if (orderHistory.Count() == 0)
            {
                Console.WriteLine("Nie znaleziono historii zamówień");
            }
            else
            {
               Console.WriteLine(orderHistory);
            }
        }

        public void ShowSelectOrderId(Receipt receipt)
        {
            Console.WriteLine("Wpisz Potrzebny Id: ");
            int OrderId = Convert.ToInt32(Console.ReadLine());

            receipt.LoadSelectOrderId(OrderId);
        }

        public void ShowHisitory(Receipt receipt)
        {  

            Console.WriteLine("[1] Cała historia\n[2] Historia na Id");
            int option = ReadCorrectNumber(2);

            Console.Clear();
            if (option == 1)
            {
                ShowHistoryOrder(receipt);
            }
            else if (option == 2)
            {
                ShowSelectOrderId(receipt);
            }

            Console.WriteLine("\n\nNaciśnij dowolny przycisk, aby powrócić do poprzedniego menu");
            Console.ReadKey();
        }
        public int ReadCorrectNumber(int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int correctNum))
                {
                    if (correctNum >= 0 && correctNum <= max)
                    {
                        return correctNum;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Niewłaściwy znak. Proszę spróbować wybrać liczbę z listy!!!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Niewłaściwy znak. Proszę spróbować wybrać liczbę z listy!!!");
                    Console.ResetColor();
                }
            }
        }
    }
}
