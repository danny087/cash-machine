using System;
using System.Collections.Generic;

namespace currencyAppTwo.Classes
{
    public class CashRegister
    {
        static decimal onePence = 0.01m;
        static decimal twoPence = 0.02m;
        static decimal fivePence = 0.05m;
        static decimal tenPence = 0.10m;
        static decimal twentyPence = 0.20m;
        static decimal fivtyPence = 0.50m;
        static byte onePound = 1;
        static byte twoPound = 2;
        static byte fivePound = 5;
        static byte tenPound = 10;
        static byte twentyPound = 20;
        public dynamic TotalOrderAmount(decimal total, decimal customerPayment, Customer customer)
        {
            if (customer.Money < 1.25m)
            {
                Console.Error.Write("you need to pay more!");
                return 1;
            }
            else if (total > customerPayment)
            {
                Console.Error.Write("You are too poor for my store please leave!");
                return 2;
            }
            else if (customer.Money < customerPayment)
            {
                Console.Error.Write("You dont have that amount!");
                return 1;
            }
            else
            {

                if (customer.Money < total)
                {
                    Console.Error.Write("you need to pay more!");
                    return 1;
                }
                decimal payBack = customerPayment - total;
                customer.Money -= total;
                List<byte> change = this.Change(payBack);
                return change;

            }


        }

        private List<byte> Change(decimal payBack)
        {


            var changeCount = new List<byte>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
                return changeCount;
            }






        }


    }
}