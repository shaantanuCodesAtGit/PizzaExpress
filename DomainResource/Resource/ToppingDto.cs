using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using DomainResource.Attribute;

namespace DomainResource.Resource
{
    [Mapper(typeof(Topping))]
    public class ToppingDto 
    {
        public string Name { get; set; }

        public bool IsVeg { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
    }
}
