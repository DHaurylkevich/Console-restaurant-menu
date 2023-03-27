using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kaif
{
    public class Order
    {
        private string name;
        private double price;
        private int quantity;
        public List<Order> OrdersList = new List<Order>();

        public Order() 
        { 
        }

        public Order(string name, double price)
        {
            this.name = name;
            this.price = price;
            quantity = 1;
        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public void AddDishToOrder(Dish DishsTotal)
        {
            if (AddQuantity(DishsTotal) != 1)
            {
                OrdersList.Add(new Order(DishsTotal.Name, DishsTotal.Price));
            }
        }

        public void VoidingRemoveDishFromOrder(Order orderMenuUI, MenuUI menuUI)
        {            
            int num = 1;

            while(num != 0)
            {
                Console.Clear();
                if (OrdersList.Count() == 0)
                {
                    Console.WriteLine("Order jest pusty!");
                    Console.WriteLine("Naciśnij dowolny klawisz ...");
                    Console.ReadLine();
                    num = 0;
                }
                else
                {
                    menuUI.DisplayLogo();
                    menuUI.ShowOrderItem(orderMenuUI);

                    Console.Write("[0] Powrót do kategorii\nWybierz: ");
                    

                    num = menuUI.ReadCorrectNumber(OrdersList.Count());
                    if (num == 0) { break;}
                    Order DishToRemove = OrdersList[num-1];

                    RemoveDishFromOrder(DishToRemove);
                }
            }
        }
        public void RemoveDishFromOrder(Order DishToRemove)
        {
            foreach (Order ord in OrdersList)
            {
                if (ord.Name == DishToRemove.Name)
                {
                    if (DishToRemove.Quantity != 1)
                    {
                        DishToRemove.Quantity--;
                    }
                    else 
                    { 
                        OrdersList.Remove(ord);
                        break;
                    }
                }
            }
        }
        public int AddQuantity(Dish dish)
        {
            foreach (Order ord in OrdersList)
            {
                if (ord.Name == dish.Name)
                {
                    ord.Quantity += 1;
                    return 1;
                }
            }
            return 0;
        }

        public double GetTotalPrice()
        {
            double TotalPrice = 0 ;

            foreach (Order ord in OrdersList)
            {
                TotalPrice = TotalPrice + ord.Price * ord.Quantity;
            }
            return TotalPrice;
        }

    }
}
