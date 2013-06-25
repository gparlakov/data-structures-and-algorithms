using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _5.ShoppingCenter
{


    class Program
    {
        static void Main(string[] args)
        {
            var shoppingCenter = new ShoppingCenter();
            var commandsProcessor = new CommandProcessor(shoppingCenter);
           
            var results = CommandsProcess(commandsProcessor);

            Console.WriteLine(results.ToString());
        }
  
        private static StringBuilder CommandsProcess(CommandProcessor commandsProcessor)
        {
            var n = int.Parse(Console.ReadLine());
            var results = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var message = commandsProcessor.ProcessCommand(Console.ReadLine());
                results.Append(message);
            }

            //results.Append(commandsProcessor.ProcessCommand("AddProduct BMG;500067.2454;Mercedes"));
            //results.Append(commandsProcessor.ProcessCommand("AddProduct AMG;500000.2454;Mercedes"));
            //results.Append(commandsProcessor.ProcessCommand("AddProduct CMG;500000.2454;Mercedes"));
            //results.Append(commandsProcessor.ProcessCommand("AddProduct AMG;500067.2454;Mercedes"));
            //results.Append(commandsProcessor.ProcessCommand("AddProduct 124;12353;Mercedes"));
            //results.Append(commandsProcessor.ProcessCommand("FindProductsByPriceRange 500000;500070"));
            //results.Append(commandsProcessor.ProcessCommand("FindProductsByName AMG"));
            //results.Append(commandsProcessor.ProcessCommand("FindProductsByName 123"));
            //results.Append(commandsProcessor.ProcessCommand("FindProductsByName 124"));
            //results.Append(commandsProcessor.ProcessCommand("DeleteProducts AMG;Mercedes"));
            //results.Append(commandsProcessor.ProcessCommand("FindProductsByName AMG"));
            //results.Append(commandsProcessor.ProcessCommand("FindProductsByProducer Mercedes"));
            //results.Append(commandsProcessor.ProcessCommand("FindProductsByName 124"));

            return results;
        }
    }

    public class CommandProcessor
    {
        private const string ProductAdded = "Product added\n";
        private const string NoFound = "No products found\n";
        private const string Deleted = "{0} products deleted\n";
        private const char CommandNameBreak = ' ';
        private const char CommandArgumentsBreak = ';';

        public CommandProcessor(ShoppingCenter shoppingCenter)
        {
            this.shoppingCenter = shoppingCenter;
        }

        public ShoppingCenter shoppingCenter { get; private set; }

        public string ProcessCommand(string commandLine)
        {
            //var arguments = commandLine.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            var nameEnd = commandLine.IndexOf(CommandNameBreak);
            var name = commandLine.Substring(0, nameEnd);
            var commandName = GetCommandName(name);

            var commandArguments = commandLine.Substring(nameEnd + 1).Split(CommandArgumentsBreak);
           
            string result = "";

            switch (commandName)
            {
                case Commands.AddProduct:
                    {
                        result = this.AddProduct(commandArguments);
                        break;
                    }
                case Commands.DeleteProducts:
                    {
                        result = this.DeleteProducts(commandArguments);
                        break;
                    }
                case Commands.FindProductsByName:
                    {
                        result = this.FindProductsByName(commandArguments);
                        break;
                    }
                case Commands.FindProductsByPriceRange:
                    {
                        result = this.FindProductsByPriceRange(commandArguments);
                        break;
                    }
                case Commands.FindProductsByProducer:
                    {
                        result = this.FindProductsByProducer(commandArguments);
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("No such command can be handled");                        
                    }
            }

            return result;
        }

        private string FindProductsByProducer(string[] commandArguments)
        {
            var producer = commandArguments[0];
            var productsFoundByProducer = this.shoppingCenter.FindByProducer(producer);
            var foundMessage = new StringBuilder(NoFound);
            if (productsFoundByProducer.Count > 0)
            {
                foundMessage.Length = 0;

                foreach (var product in productsFoundByProducer)
                {
                    if (this.shoppingCenter.Products.Contains(product))
                    {
                        foundMessage.AppendLine(product.ToString());
                    }
                }

                if (foundMessage.Length == 0)
                {
                    foundMessage.Append(NoFound);
                }
            }

            return foundMessage.ToString();

        }

        private string FindProductsByPriceRange(string[] commandArguments)
        {
            var from = double.Parse(commandArguments[0]);
            var to = double.Parse(commandArguments[1]);

            var found = this.shoppingCenter.FindByPriceRange(from, to);

            var resultMessage = new StringBuilder(NoFound);

            if (found.Count > 0)
            {
                resultMessage.Length = 0;
                
                foreach (var product in found)
                {
                    if (this.shoppingCenter.Products.Contains(product))
                    {
                        resultMessage.AppendLine(product.ToString());
                    }
                }

                if (resultMessage.Length == 0)
                {
                    resultMessage.Append(NoFound);
                }
            }

            return resultMessage.ToString();
        }

        private string FindProductsByName(string[] commandArguments)
        {
            var name = commandArguments[0];
            var searchResults = this.shoppingCenter.FindByName(name);
            
            var foundByNameMessage = new StringBuilder(NoFound);

            if (searchResults.Count > 0)
            {
                foundByNameMessage.Length = 0;
                
                foreach (var product in searchResults)
                {
                    if (this.shoppingCenter.Products.Contains(product))
                    {
                        foundByNameMessage.AppendLine(product.ToString());
                    }
                }

                if (foundByNameMessage.Length == 0)
                {
                    foundByNameMessage.Append(NoFound);
                }
            }

            return foundByNameMessage.ToString();           
        }

        private string DeleteProducts(string[] commandArguments)
        {
            var countDeleted = 0;

            if (commandArguments.Length == 1)
            {
                countDeleted = this.shoppingCenter.DeleteByProducer(commandArguments[0]);
            }
            if (commandArguments.Length == 2)
            {
                var name = commandArguments[0];
                var producer = commandArguments[1];
                countDeleted = this.shoppingCenter.DeleteByNameAndProducer(name, producer);
            }

            var result = NoFound;

            if (countDeleted > 0)
            {
                result = string.Format(Deleted, countDeleted);
            }

            return result;
        }

        private string AddProduct(string[] commandArguments)
        {
            var name = commandArguments[0];
            var price = double.Parse(commandArguments[1]);
            var producer = commandArguments[2];
            this.shoppingCenter.Add(name, price, producer);

            return ProductAdded;
        }

        private Commands GetCommandName(string commandName)
        {
            Commands command = Commands.AddProduct;
            while (command <= Commands.FindProductsByProducer)
            {
                if (command.ToString() == commandName)
                {
                    break;
                }

                command++;
            }

            return command;
        }
    }

    public enum Commands
    {
        AddProduct = 1,
        DeleteProducts = 2,
        FindProductsByName = 3,
        FindProductsByPriceRange = 4,
        FindProductsByProducer = 5
    }

    public class ShoppingCenter
    {       
        public ShoppingCenter()
        {
            this.Prices = new MultiDictionary<double, Product>(true);
            this.Names = new Dictionary<string, OrderedBag<Product>>();
            this.Producers = new Dictionary<string, OrderedBag<Product>>();
            this.Products = new Bag<Product>();            
        }

        public MultiDictionary<double, Product> Prices { get; private set; }

        public Dictionary<string, OrderedBag<Product>> Names { get; private set; }

        public Dictionary<string, OrderedBag<Product>> Producers { get; private set; }

        public Bag<Product> Products { get; private set; }

        public void Add(string name, double price, string producer)
        {
            var newProduct = new Product(name, price, producer);
            if (!this.Names.ContainsKey(name))
            {
                this.Names.Add(name, new OrderedBag<Product>());
            }
            this.Names[name].Add(newProduct);

            this.Prices.Add(price, newProduct);

            if (!this.Producers.ContainsKey(producer))
            {
                this.Producers.Add(producer, new OrderedBag<Product>());
            }
            this.Producers[producer].Add(newProduct);

            this.Products.Add(newProduct);            
        }

        public int DeleteByProducer(string producer)
        {
            var found = this.FindByProducer(producer);

            int countDeleted = 0;
            foreach (var product in found)
            {
                if (this.Products.Contains(product))
                {                    
                    this.Products.Remove(product);
                    countDeleted++;
                }                                   
            }
            this.Producers.Remove(producer);

            return countDeleted;
        }

        public int DeleteByNameAndProducer(string name, string producer)
        {
            var foundByName = this.FindByName(name);
            var foundByProducer = this.FindByProducer(producer);

            var intersection = foundByName.Intersect(foundByProducer);

            var counterDeleted = 0;
            foreach (var item in foundByName)
            {
                if (foundByProducer.Contains(item) && this.Products.Contains(item))
                {
                    this.Products.Remove(item);
                    counterDeleted++;
                }
            }

            this.Names.Remove(name);
            this.Producers.Remove(producer);

            return counterDeleted;
        }
        
        public OrderedBag<Product> FindByName(string name)
        {
            var found = new OrderedBag<Product>();
            if (this.Names.ContainsKey(name))
            {
               found = this.Names[name];
            }
           
            return found;
        }

        public OrderedBag<Product> FindByProducer(string producer)
        {
            var found = new OrderedBag<Product>();
            if (this.Producers.ContainsKey(producer))
            {
                found = this.Producers[producer];
            }
            
            return found;
        }

        public OrderedBag<Product> FindByPriceRange(double from, double to)
        {
            var result = new OrderedBag<Product>();

            var found = this.Prices.FindAll(x => x.Key >= from && x.Key <= to);

            foreach (var price in found)
            {
                result.AddMany(price.Value);
            }

            return result;
        }               
    }

    public class Product : IEquatable<Product>, IComparable<Product>
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Producer { get; private set; }
        
        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public override string ToString()
        {
            var result = string.Format("{0};{2};{1:F2}", this.Name, this.Price, this.Producer);
            return '{' + result + '}';
        }
        
        public bool Equals(Product other)
        {
            bool areEqual = true;

            if (this.Name != other.Name || 
                this.Price != other.Price || 
                this.Producer != other.Producer) 
            {
                areEqual = false;                
            }

            return areEqual;
        }

        public int CompareTo(Product other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Producer.CompareTo(other.Producer);
            }

            return result;
        }
    }
}
