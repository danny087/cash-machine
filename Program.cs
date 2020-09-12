using System;
using System.Collections.Generic;

namespace currencyAppTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            // string value = "";
            // if(value != "pay") {
              var customer =  new Customer();
              
            Program.addBasketMenu(customer);
            // if(value == "pay") {
            //     Program.CustomerPayMenu();
            // }
            // }   
            // else if(value == "pay") {
            //     Program.CustomerPayMenu();
            // }


        }

        static void addBasketMenu(Customer customer)
        {
            Basket basket = new Basket();
            List<string> consoleMenu = new List<string>() { "Cheese", "Milk", "Newspaper", "Bread", "Pay" };
            
            Console.CursorVisible = false;
            var index = 0;
            while (true)
            {
                for (int i = 0; i < consoleMenu.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"{consoleMenu[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"{consoleMenu[i]}");
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();

                Console.Clear();
                Console.WriteLine($"You curenlty have £{customer.Money}");
                Console.WriteLine("Welcome to my store what would you like to buy?");
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == consoleMenu.Count - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = consoleMenu.Count - 1;
                    }
                    else
                    {
                        index--;
                    }


                }
                else if (ckey.Key == ConsoleKey.Enter)
                {

                    var choosenItem = consoleMenu[index];

                    if (choosenItem == "Cheese")
                    {
                        basket.addToBasket("1.27");
                    }
                    if (choosenItem == "Milk")
                    {
                        basket.addToBasket("1.29");
                    }
                    if (choosenItem == "Newspaper")
                    {
                        basket.addToBasket("1.28");
                    }
                    if (choosenItem == "Bread")
                    {
                        basket.addToBasket("1.24");
                    }
                    if (choosenItem == "Pay")
                    {
                        //var till = new CashRegister();
                        //till.TotalOrderAmount(basket.Total);
                        Program.CustomerPayMenu(basket,customer);
                        //return "pay";
                    }

                }
                Console.WriteLine($"Your basket total {basket.Total}");
            }
        }

        static string CustomerPayMenu(Basket basket,Customer customer) 
        {
            List<string> consoleMenu = new List<string>() { "1", "2", "5", "10", "20" };
            Console.CursorVisible = false;
            var index = 0;
            while (true)
            {
                for (int i = 0; i < consoleMenu.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"{consoleMenu[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"£{consoleMenu[i]}");
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("What would you like to pay with?");
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == consoleMenu.Count - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = consoleMenu.Count - 1;
                    }
                    else
                    {
                        index--;
                    }


                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    var customerPayment = Convert.ToDouble(consoleMenu[index]);
                    Console.WriteLine(customerPayment);
                    var till = new CashRegister();
                    till.TotalOrderAmount(basket.Total, customerPayment,customer);
                }
            }
        }
    }


    public class Basket
    {
        public double Total { get; set; }

        public void addToBasket(string item)
        {
            var convertToDouble = Convert.ToDouble(item);
            this.Total += convertToDouble;
            this.Total = Math.Round(this.Total, 2);
        }
    }

    public class Customer
    {
        public double Money { get; set; } = 20.00;
    }

    public class CashRegister
    {

        static double onePence = 0.01;
        static double twoPence = 0.02;
        static double fivePence = 0.05;
        static double tenPence = 0.10;
        static double twentyPence = 0.20;
        static double fivtyPence = 0.50;
        static byte onePound = 1;
        static byte twoPound = 2;
        static byte fivePound = 5;
        static byte tenPound = 10;
        static byte twentyPound = 20;
        public void TotalOrderAmount(double total, double customerPayment,Customer customer)
        {
            if (total > customerPayment)
            {
                throw new Exception("you need to pay more!");
            }
            else
            {
                customer.Money -= customerPayment;
                List<double> change = this.Change(total, customerPayment);
                
            }

            
        }

        private List<double> Change(double total, double amountPaid)
        {

            var payBack = amountPaid - total;
            var changeCount = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            while (true)
            {
                while (payBack >= CashRegister.twentyPound) { changeCount[10] += 1; payBack -= CashRegister.twentyPound; }
                while (payBack >= CashRegister.tenPound) { changeCount[9] += 1; payBack -= CashRegister.tenPound; }
                while (payBack >= CashRegister.fivePound) { changeCount[8] += 1; payBack -= CashRegister.fivePound; }
                while (payBack >= CashRegister.twoPound) { changeCount[7] += 1; payBack -= CashRegister.twoPound; }
                while (payBack >= CashRegister.onePound) { changeCount[6] += 1; payBack -= CashRegister.onePound; }
                while (payBack >= CashRegister.fivtyPence) { changeCount[5] += 1; payBack -= CashRegister.fivtyPence; }
                while (payBack >= CashRegister.twentyPence) { changeCount[4] += 1; payBack -= CashRegister.twentyPence; }
                while (payBack >= CashRegister.tenPence) { changeCount[3] += 1; payBack -= CashRegister.tenPence; }
                while (payBack >= CashRegister.fivePence) { changeCount[2] += 1; payBack -= CashRegister.fivePence; }
                while (payBack >= CashRegister.twoPence) { changeCount[1] += 1; payBack -= CashRegister.twoPence; }
                while (payBack >= CashRegister.onePence) { changeCount[0] += 1; payBack -= CashRegister.onePence; }
                Console.WriteLine(payBack);
                changeCount.ForEach(Console.WriteLine);
                return changeCount;
            }






        }


    }
}
