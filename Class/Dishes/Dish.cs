namespace Kaif
{
    public class Dish
    {
        private string name;
        private double price;

        public Dish(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
    }
}          