using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.PizzaInterface;
using Data.Entity;

namespace Business.Decorator
{
    public class CheeseDecorator : PizzaDecorator
    {
        private readonly List<Cheese> _cheeses;

        public CheeseDecorator(IPizza pizza, List<Cheese> cheeses) : base(pizza)
        {
            _cheeses = cheeses ?? new List<Cheese>();
        }

        public override Pizza GetPizza()
        {
            var pizza = base.GetPizza();
            pizza.Cheeses = _cheeses;
            pizza.TotalPrice = pizza.TotalPrice + _cheeses.Sum(x => x.Price);

            return pizza;
        }
    }
}
