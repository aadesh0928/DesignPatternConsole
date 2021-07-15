using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public abstract class Order
    {
        protected List<Product> products = new List<Product>
        {
            new Product { Name = "ABC", Price = 23.34f },
            new Product { Name = "ABC", Price = 23.34f },
            new Product { Name = "ABC", Price = 23.34f },
            new Product { Name = "ABC", Price = 23.34f }
        };

        public abstract double CalculateOrderTotal();
    }

    class NormalOrder: Order
    {
        public override double CalculateOrderTotal()
        {
            Console.WriteLine("Calculating the total price of a regular order");
            return products.Sum(product => product.Price);
        }
    }

    class DiscountedOrder : Order
    {
        private double _discount { get; set; }
        public DiscountedOrder(double discount)
        {
            _discount = discount;
        }
        public override double CalculateOrderTotal()
        {
            Console.WriteLine("Calculating the total price of a regular order");
            return products.Sum(product => product.Price) * _discount;
        }
    }

    public class OrderDecorator : Order
    {
        protected Order _order;
        public OrderDecorator(Order order)
        {
            _order = order;
        }
        public override double CalculateOrderTotal()
        {
            Console.WriteLine("Calculating the total price as per advance discouting logic");
            return _order.CalculateOrderTotal();
        }
    }

    public class PremiumOrder: OrderDecorator
    {
        private double _premiumDisCount;
        public PremiumOrder(Order order, double premiumDiscoumt): base (order)
        {
            _premiumDisCount = premiumDiscoumt;
        }

        public override double CalculateOrderTotal()
        {
            var discountedProce = base.CalculateOrderTotal();

            return discountedProce * _premiumDisCount;
        }

    }
    class DecoratorPattern
    {
        public static void Main199898989(string[] args)
        {
            var discountedOrder = new DiscountedOrder(.9);


            var premiumOrder = new PremiumOrder(discountedOrder, .11);
        }
    }
}
