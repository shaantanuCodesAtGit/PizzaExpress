using System;
using System.Collections.Generic;
using System.Text;
using Utility.Enum;

namespace Data.Entity
{
    public class Pizza
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVeg { get; set; }
        public string Image { get; set; }
        public float TotalPrice { get; set; }
        public PizzaSizeEnum Size { get; set; }

        public List<Topping> Toppings { get; set; }

        public List<Sauce> Sauces { get; set; }

        public List<Cheese> Cheeses { get; set; }
    }
}
