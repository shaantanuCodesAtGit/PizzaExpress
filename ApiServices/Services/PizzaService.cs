using System;
using System.Collections.Generic;
using System.Text;
using Business.Decorator;
using Business.PizzaInterface;
using Business.ServiceBase;
using Data.Entity;
using DomainResource.Resource;
using Nelibur.ObjectMapper;
using Utility.Enum;
using Cheese = Data.Entity.Cheese;

namespace Business.Services
{
    public abstract class PizzaService : PizzaServiceBase, IPizza
    {
        public abstract Pizza GetPizza();
    }
}
