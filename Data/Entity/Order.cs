using System;
using System.Collections.Generic;
using System.Text;
using Utility.Enum;

namespace Data.Entity
{
    public class Order
    {
        public string Id { get; set; }

        public Pizza Pizza { get; set; }

        public DateTime OrderCreatedOn { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        public DateTime StatusUpdatedOn { get; set; }

        public string Address { get; set; }
    }
}
