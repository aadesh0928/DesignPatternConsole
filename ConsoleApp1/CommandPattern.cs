using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp112
{

    public class Product
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(double amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price of {Name} is increased  by: {amount}");
        }

        public void DecreasePrice(double amount)
        {
            if(amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price of {Name} is decreased  by: {amount}");
            }

        }

        public override string ToString()
        {
            return $"The current price of the {Name} is {Price}";
        }
    }


    public interface ICommand
    {
        void Execute();
    }

    public enum PriceAction
    {
        Increase,
        Decrease
    }


    public class ProductCommand: ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly double _amount;
        public ProductCommand(Product product, PriceAction priceAction, double amount)
        {
            _product = product;
            _priceAction = priceAction;
            _amount = amount;
        }

        public void Execute()
        {
            if(_priceAction == PriceAction.Increase)
            {
                _product.IncreasePrice(_amount);
            }
            else
            {
                _product.DecreasePrice(_amount);
            }
        }
    }


    public class ModifyPrice
    {
        private readonly IList<ICommand> _commands;
        private ICommand _command;
        public ModifyPrice()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => _command = command;


        public void Invoke()
        {
            _commands.Add(_command);
            _command.Execute();
        }
    }



    public class CommandPattern
    {
        public static void Main12(String[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Microsoft Windows 10", 2500.90f);
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 23.90f));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 13.90f));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 3.90f));
            Console.WriteLine(product);
            Console.ReadKey();
        }

        private static void Execute(ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
