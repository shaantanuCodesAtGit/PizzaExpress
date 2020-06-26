using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using Utility.Constant;

namespace Business.Services
{
    public class CustomPizzaService : PizzaService
    {
        public override Pizza GetPizza()
        {
            Name = PizzaConstant.Custom;

            Description =
                "Enjoy your custom made pizza.";

            return AssemblePizza();
        }
    }
}
