using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using DomainResource.Attribute;

namespace DomainResource.Resource
{
    [Mapper(typeof(Sauce))]
    public class SauceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
    }
}
