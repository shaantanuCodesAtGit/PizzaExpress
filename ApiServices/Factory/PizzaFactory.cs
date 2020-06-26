using System;
using System.Collections.Generic;
using System.Text;
using Business.Services;
using Data.Respository;
using Utility.Constant;

namespace Business.Factory
{
    public class PizzaFactory
    {
        private readonly DataContext _dataContext;

        public PizzaFactory(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public PizzaService ChoosenPizza(string pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaConstant.Exotic:
                    return new ExoticPizzaService(_dataContext);
                case PizzaConstant.Supreme:
                    return new SupremePizzaService(_dataContext);
                case PizzaConstant.Chicken:
                    return new ChickenPizzaService(_dataContext);
                case PizzaConstant.Custom:
                    return new CustomPizzaService();
                default:
                    return null;
            }
        }
    }
}
