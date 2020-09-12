using System;

namespace currencyAppTwo.Classes {
    public class Basket
    {
        public decimal Total { get; set; }

        public void addToBasket(string item)
        {
            var convertToDouble = Convert.ToDecimal(item);
            this.Total += convertToDouble;
            this.Total = Math.Round(this.Total, 2);
        }
    }
}