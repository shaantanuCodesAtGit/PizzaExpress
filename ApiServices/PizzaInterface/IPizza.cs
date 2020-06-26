using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using DomainResource.Resource;

namespace Business.PizzaInterface
{
    public interface IPizza
    {
        Pizza GetPizza();
    }
}
