using System;
using System.Collections.Generic;
using System.Linq;
using currencyAppTwo.Classes;

namespace currencyAppTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            // string value = "";
            // if(value != "pay") {
            var customer = new Customer();

            var result = Program.addBasketMenu(customer);
            if(result == "yes") {
                Program.addBasketMenu(customer);
            }
            // if(value == "pay") {
            //     Program.CustomerPayMenu();
            // }
            // }   
            // else if(value == "pay") {
            //     Program.CustomerPayMenu();
            // }


        }

        static string addBasketMenu(Customer customer)
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
                        basket.addToBasket("1.25");
                    }
                    if (choosenItem == "Pay")
                    {
                        //var till = new CashRegister();
                        //till.TotalOrderAmount(basket.Total);
                        var changeAmount = Program.CustomerPayMenu(basket, customer);
                        basket.Total = 0;
                        var result = Program.payAgainMenu(changeAmount);
                        if(result == "no") {
                            return "no";
                        }
                        else{
                            return "yes";
                        }
                        //return "pay";
                    }

                }
                Console.WriteLine($"Your basket total {basket.Total}");
            }
        }

        static List<byte> CustomerPayMenu(Basket basket, Customer customer)
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
                    var customerPayment = Convert.ToDecimal(consoleMenu[index]);
                    Console.WriteLine(customerPayment);
                    var till = new CashRegister();
                    List<byte> changeAmount = till.TotalOrderAmount(basket.Total, customerPayment, customer);
                    //Console.Clear();
                    return changeAmount;

                }
            }
        }

        static string payAgainMenu(List<byte> changeAmount)
        {
            List<string> consoleMenu = new List<string>() { "yes", "no" };
            var list = new List<string>() { "1p:", "2p:", "5p:", "10p:", "20p:", "50p:", "£1:", "£2:", "£5:", "£10:", "£20:" };
            for (int i = 0; i < changeAmount.Count; i++)
            {
                
              list[i] = list[i] + changeAmount[i].ToString();
            }
            var displaychange = list.Where(x => !x.EndsWith('0')).ToList();
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
                displaychange.ForEach(Console.WriteLine);
                 ConsoleKeyInfo ckey = Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Would you like to shop again?");
            
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
                    
                   if(consoleMenu[index] == "no") {
                       return "no";
                   }
                   else {
                       return "yes";
                   }

                }

            }
           

        }

    }

}
