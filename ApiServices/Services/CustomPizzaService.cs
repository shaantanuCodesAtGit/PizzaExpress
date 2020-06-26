using System;
using System.Collections.Generic;
using System.Text;
using Business.ServiceBase;
using Data.Entity;
using Utility.Constant;

namespace Business.Services
{
    public class CustomPizzaService : PizzaServiceBase
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
