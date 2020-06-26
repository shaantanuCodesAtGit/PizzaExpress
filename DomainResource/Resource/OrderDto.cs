using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using DomainResource.Attribute;
using Utility.Enum;

namespace DomainResource.Resource
{
    [Mapper(typeof(Order))]
    public class OrderDto
    {
        public string Id { get; set; }

        public PizzaDto Pizza { get; set; }

        public DateTime OrderCreatedOn { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        public DateTime StatusUpdatedOn { get; set; }

        public string Address { get; set; }
    }
}
