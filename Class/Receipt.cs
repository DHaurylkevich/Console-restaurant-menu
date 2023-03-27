using System;
using System.IO;

namespace Kaif
{
    public class Receipt
    {

        private int OrderId;
        public const string fileHistory = "HistoryOrder.txt";
        public const string fileLastId = "LastId.txt";


        public Receipt() { }

        public int NewOrderId { get => OrderId; set => OrderId = value; }

        public void PrintReceipt(Order order)
        {
            Console.WriteLine("Receipt:");
            foreach (Order ord in order.OrdersList)
            {
                Console.WriteLine("|{0}) {1} |", ord.Name, ord.Price);
            }
        }

        public void SaveToFile(Order Orders)
        {
            LoadAndUpdateLastId();
            using (StreamWriter writer = new StreamWriter(File.Open(fileHistory, FileMode.Append)))
            {

                writer.WriteLine("Order Number: " + NewOrderId);

                foreach (Order ord in Orders.OrdersList)
                {
                    writer.WriteLine(" - " + ord.Name + " (x" + ord.Quantity + ") - " + ord.Price + " zł");
                }

                writer.WriteLine("Total: " + Orders.GetTotalPrice());

                writer.WriteLine("###########################");
            }
            SaveLastId();
        }

        public void SaveLastId()
        {
            using (StreamWriter writer = new StreamWriter(File.Open(fileLastId, FileMode.OpenOrCreate)))
            {
                writer.WriteLine("Last_Order_id " + NewOrderId);
            }
        }

        public void LoadAndUpdateLastId()
        {
            SaveLastId();
            int orderId;
            using (StreamReader Reader = new StreamReader(File.Open(fileLastId, FileMode.OpenOrCreate)))
            {
                int num = CheckFile(fileLastId);
                if (num == 1)
                {
                    string receipt = Reader.ReadLine();
                    orderId = Convert.ToInt32(receipt.Split(' ')[1]);
                    NewOrderId = orderId + 1;
                }
            }
            
        }

        public string LoadHistoryOrderFile()// вывод всей истории заказа
        {
            string text;
            using (StreamReader Reader = new StreamReader(File.Open(fileHistory, FileMode.OpenOrCreate)))
            {
                int num = CheckFile(fileHistory);
                if (num == 1)
                {
                    text = Reader.ReadToEnd();
                }
                else
                {
                    text = "Empty";
                }
            }
            return text;
        }
        public int CheckFile(string FileName)
        {
            FileInfo fileinfo = new FileInfo(FileName);
            if (fileinfo.Length == 0)
            {
                return 0;
            }
            else return 1;
        }

        public void LoadSelectOrderId(int OrderNumber)// вывод нужной истории заказа
        {

            string NeedIdLine = "Order Number: " + OrderNumber;

            string separator = "###########################";
            string line;
            int i = 0;

            using (StreamReader Reader = new StreamReader(fileHistory))
            {
                while (!Reader.EndOfStream)
                {
                    line = Reader.ReadLine();
                    if (line == NeedIdLine)
                    {
                        Console.WriteLine(line);
                        while (line != separator)
                        {
                            line = Reader.ReadLine();
                            Console.WriteLine(line);

                        }
                        i++;
                    }
                }
            }
            if (i == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Nie ma takiego Id");
                Console.ResetColor();
            }
        }
    }
}
