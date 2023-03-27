using System;
using System.Collections.Generic;


namespace Kaif
{
    public class Category // класс реализующий котегории
    {
        private string name;
        private List<Dish> dishes;
        public static List<Category> categories = new List<Category>();

        public Category()
        {
        }

        public Category(string name, List<Dish> dishes)
        {
            this.name = name;
            this.dishes = dishes;
        }

        public string Name { get => name; set => name = value; }
        public List<Dish> Dishes { get => dishes; set => dishes = value; }

        public void AddDish(string name, List<Category> categories, List<Dish> dishes)
        {
            categories.Add(new Category(name, dishes));
        }

        public void ShowDishonCategoryList(List<Dish> SelectCategory)
        {
            int i = 1;
            foreach (Dish dish in SelectCategory)
            {
                Console.WriteLine("{0}. {1} {2} zl", i, dish.Name, dish.Price);
                i++;
            }
        }

        public void ShowCategoryfromCategoryList(List<Category> SelectCategory)
        {
            int i = 1;
            foreach (Category drink in SelectCategory)
            {
                Console.WriteLine("{0}. {1}", i, drink.Name);
                i++;

            }

        }
        public int SelectAge(int num)
        {

            int age;
            if (categories[num-1].Name == "Napoje alkoholowe")
            {            
                Console.WriteLine("Ile ma masz lat?");
                while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Niewłaściwy znak. Proszę spróbować wybrać liczbę z listy!!!");
                    Console.ResetColor();

                }

                if (age < 18)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Przepraszamy, musisz mieć ukończone 18 lat, aby zobaczyć tę kategorię");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                    Console.ResetColor();
                    Console.ReadKey();
                    return 0;
                }
            }
            return 1;
        }
    }
}




