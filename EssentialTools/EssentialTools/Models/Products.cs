using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class Products
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
    }

    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscounthelper discounter;
        private static int counter = 0;

        public LinqValueCalculator(IDiscounthelper disc)
        {
            discounter = disc;
            System.Diagnostics.Debug.WriteLine($"Instance {++counter} created");
        }

        public decimal ValueProducts(IEnumerable<Products> prods)
        {
            return discounter.ApplyDiscount(prods.Sum(p => p.Price));
        }
    }

    public class ShoppingCart
    {
        private IValueCalculator calc;

        public ShoppingCart(IValueCalculator calcParap)
        {
            calc = calcParap;
        }

        public IEnumerable<Products> Prods { get; set; }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Prods);
        }
    }
}