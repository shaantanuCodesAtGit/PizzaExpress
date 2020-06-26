using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Decorator;
using Business.PizzaInterface;
using Data.Entity;
using Data.Respository;
using DomainResource.Resource;
using Utility;
using Utility.Constant;
using Utility.Helper;

namespace Business.Services
{
    public class ExoticPizzaService : PizzaService
    {
        private readonly DataContext _dataContext;

        public ExoticPizzaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public override Pizza GetPizza()
        {
            Name = PizzaConstant.Exotic;

            Description =
                "is a savory dish of Italian origin consisting of a usually round, flattened base of leavened wheat-based dough topped with tomatoes, cheese, and often various other ingredients";

            Cheeses = _dataContext.Cheeses.Get(x => x.Name == "Mozzarella" || x.Name == "Feta");

            Sauces = _dataContext.Sauces.Get(x => x.Name == "Ranch Sauce" || x.Name == "Marinara Sauce");

            Toppings = _dataContext.Toppings.Get(x => x.Name == "Baby Spinach" || x.Name == "Jalapeño");

            return AssemblePizza();
        }
    }
}
