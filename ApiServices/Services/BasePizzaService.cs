using System;
using System.Collections.Generic;
using System.Text;
using Business.PizzaInterface;
using Data.Entity;
using Utility.Enum;

namespace Business.Services
{
    public class BasePizzaService : IPizza
    {
        private readonly PizzaSizeEnum _size;

        public BasePizzaService(PizzaSizeEnum size)
        {
            _size = size;
        }

        public Pizza GetPizza()
        {
            return new Pizza
            {
                Size = _size
            };
        }
    }
}
