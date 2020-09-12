using System;

namespace currencyAppTwo.Classes {
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
}