using System;
using System.Collections.Generic;
using System.Text;
using Business.PizzaInterface;
using Business.Services;
using Data.Respository;
using Utility.Constant;

namespace Business.Factory
{
    /// <summary>
    /// Returns a pizza of choice.
    /// </summary>
    public class PizzaFactory
    {
        private readonly DataContext _dataContext;

        public PizzaFactory(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IPizza ChoosenPizza(string pizzaType)
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
