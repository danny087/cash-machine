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
            Program.addBasketMenu();
            // if(value == "pay") {
            //     Program.CustomerPayMenu();
            // }
            // }   
            // else if(value == "pay") {
            //     Program.CustomerPayMenu();
            // }


        }

        static void addBasketMenu()
        {
            Basket basket = new Basket();
            List<string> consoleMenu = new List<string>() { "Cheese", "Milk", "Newspaper", "Bread", "Pay" };
            Console.WriteLine("Hello World!");
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
                        Program.CustomerPayMenu(basket);
                        //return "pay";
                    }
                    
                }
                Console.WriteLine($"Your basket total {basket.Total}");
            }
        }

        static string CustomerPayMenu(Basket basket) {
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
                    till.TotalOrderAmount(basket.Total,customerPayment);
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
        public double Money { get; } = 20.00;
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
        static byte twoPounds = 2;
        static byte fivePounds = 5;
        static byte tenPounds = 10;
        static byte twentyPounds = 20;
        public double TotalOrderAmount(double total,double customerPayment)
        {
            if(total > customerPayment) {
                throw new Exception("you need to pay more!");
            } else{
                    this.Change(total, customerPayment);
            }
                
            

            return 0;
        }

        private double Change(double total, double amountPaid)
        {
            var payBack = amountPaid - total;
            Console.WriteLine(payBack);

            return 0;
        }


    }
}
