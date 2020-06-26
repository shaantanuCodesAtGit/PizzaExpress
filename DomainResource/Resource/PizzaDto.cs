using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using DomainResource.Attribute;
using Utility.Enum;

namespace DomainResource.Resource
{
    [Mapper(typeof(Pizza))]
    public class PizzaDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVeg { get; set; }
        public string Image { get; set; }
        public float TotalPrice { get; set; }
        public PizzaSizeEnum Size { get; set; }

        public List<CheeseDto> Cheeses { get; set; }

        public List<SauceDto> Sauces { get; set; }

        public List<ToppingDto> Toppings { get; set; }
    }
}
