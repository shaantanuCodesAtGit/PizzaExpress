using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.PizzaInterface;
using Data.Entity;

namespace Business.Decorator
{
    public class ToppingDecorator : PizzaDecorator
    {
        private readonly List<Topping> _toppings;

        public ToppingDecorator(IPizza pizza, List<Topping> toppings) : base(pizza)
        {
            _toppings = toppings ?? new List<Topping>();
        }

        public override Pizza GetPizza()
        {
            var pizza = base.GetPizza();
            pizza.Toppings = _toppings;
            pizza.TotalPrice = pizza.TotalPrice + _toppings.Sum(x => x.Price);
            pizza.IsVeg = _toppings.All(x => x.IsVeg);

            return pizza;
        }
    }
}
