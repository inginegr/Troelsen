using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscounthelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
    public class DefaultDiscountHelper : IDiscounthelper
    {
        public decimal DiscountSize { get; set; }
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - totalParam * (DiscountSize / 100m));
        }
    }

    public class FlexibleDiscountHelper : IDiscounthelper
    {
        public decimal DiscountSize { get; set; }
        public decimal ApplyDiscount(decimal totalParam)
        {
            DiscountSize = 100 > totalParam ? 25 : 75;
            return (totalParam - totalParam * (DiscountSize / 100m));
        }
    }
}