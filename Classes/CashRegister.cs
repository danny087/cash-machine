using System;
using System.Collections.Generic;

namespace currencyAppTwo.Classes {
public class CashRegister
    {

        static double onePence = 0.01;
        static double twoPence = 0.02;
        static double fivePence = 0.05;
        static double tenPence = 0.10;
        static double twentyPence = 0.20;
        static double fivtyPence = 0.50;
        static double onePound = 1;
        static double twoPound = 2;
        static double fivePound = 5;
        static double tenPound = 10;
        static double twentyPound = 20;
        public List<double> TotalOrderAmount(double total, double customerPayment, Customer customer)
        {
            if (total > customerPayment)
            {
                throw new Exception("you need to pay more!");
            }
            else
            {
                var payBack = customerPayment - total;
                customer.Money -= payBack;
                List<double> change = this.Change(payBack);
                return change;

            }


        }

        private List<double> Change(double payBack)
        {

            
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
                return changeCount;
            }






        }


    }
}