using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public class Topping
    {
        public string Name { get; set; }

        public bool IsVeg { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
    }
}
