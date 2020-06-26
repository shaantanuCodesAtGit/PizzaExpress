using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entity;

namespace Data.Respository
{
    /// <summary>
    /// Implementation of file context which exposes a way to connect to our file system.
    /// </summary>
    public class DataContext : FileContext
    {
        public DataContext(string connectionString) : base(connectionString)
        {
        }

        public Respository<Cheese> Cheeses { get; set; }

        public Respository<Topping> Toppings { get; set; }

        public Respository<Sauce> Sauces { get; set; }

        public Respository<Pizza> Pizzas { get; set; }

        public Respository<Order> Orders { get; set; }
    }
}
