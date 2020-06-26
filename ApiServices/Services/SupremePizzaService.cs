using Business.PizzaInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Decorator;
using Business.ServiceBase;
using Data.Entity;
using Data.Respository;
using DomainResource.Resource;
using Utility.Constant;

namespace Business.Services
{
    public class SupremePizzaService : PizzaServiceBase
    {
        private readonly DataContext _dataContext;

        public SupremePizzaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public override Pizza GetPizza()
        {
            Name = PizzaConstant.Supreme;

            Description =
                "is a savory dish of Italian origin consisting of a usually round, flattened base of leavened wheat-based dough topped with tomatoes, cheese, and often various other ingredients";

            Cheeses = _dataContext.Cheeses.Get(x => x.Name == "Cheddar" || x.Name == "Parmesan");

            Sauces = _dataContext.Sauces.Get(x => x.Name == "BBQ Sauce" || x.Name == "Hot Sauce");

            Toppings = _dataContext.Toppings.Get(x => x.Name == "Pesto with white beans" || x.Name == "Mushrooms");

            return AssemblePizza();
        }
    }
}
