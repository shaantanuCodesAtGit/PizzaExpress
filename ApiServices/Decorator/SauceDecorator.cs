using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.PizzaInterface;
using Data.Entity;

namespace Business.Decorator
{
    public class SauceDecorator : PizzaDecorator
    {
        private readonly List<Sauce> _sauces;

        public SauceDecorator(IPizza pizza, List<Sauce> sauces) : base(pizza)
        {
            _sauces = sauces ?? new List<Sauce>();
        }

        public override Pizza GetPizza()
        {
            var pizza = base.GetPizza();
            pizza.Sauces = _sauces;
            pizza.TotalPrice = pizza.TotalPrice + _sauces.Sum(x => x.Price);

            return pizza;
        }
    }
}
