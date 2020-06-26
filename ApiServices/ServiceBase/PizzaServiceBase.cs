using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Decorator;
using Business.PizzaInterface;
using Business.Services;
using Utility.Enum;
using Utility.Helper;
using Cheese = Data.Entity.Cheese;

namespace Business.ServiceBase
{
    public abstract class PizzaServiceBase : IPizza
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public PizzaSizeEnum Size { get; set; }

        public List<Cheese> Cheeses { get; set; }

        public List<Sauce> Sauces { get; set; }

        public List<Topping> Toppings { get; set; }

        protected Pizza AssemblePizza()
        {
            var pizzaSize = Size == PizzaSizeEnum.Default ? PizzaSizeEnum.Medium : Size;

            var basePizza = new BasePizzaService(pizzaSize);
            var pizzaDecorator = new PizzaDecorator(basePizza);

            PizzaDecorator sauceDecorator = new SauceDecorator(pizzaDecorator, Sauces);
            PizzaDecorator toppingDecorator = new ToppingDecorator(sauceDecorator, Toppings);
            PizzaDecorator cheeseDecorator = new CheeseDecorator(toppingDecorator, Cheeses);

            var bakedPizza = cheeseDecorator.GetPizza();

            bakedPizza.Description = Description;

            bakedPizza.Name = Name;

            bakedPizza.Image = $"data:image/jpg;base64,{ImageHelper.Read(Name)}";

            return bakedPizza;
        }

        public abstract Pizza GetPizza();
    }
}
