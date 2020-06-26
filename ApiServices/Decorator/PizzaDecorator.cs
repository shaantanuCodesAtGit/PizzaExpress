using System;
using System.Collections.Generic;
using System.Text;
using Business.PizzaInterface;
using Data.Entity;
using DomainResource.Resource;

namespace Business.Decorator
{
    public class PizzaDecorator : IPizza
    {
        private readonly IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual Pizza GetPizza()
        {
            return _pizza.GetPizza();
        }
    }
}
