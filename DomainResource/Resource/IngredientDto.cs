using System;
using System.Collections.Generic;
using System.Text;

namespace DomainResource.Resource
{
    public class IngredientDto
    {
        public List<CheeseDto> Cheeses { get; set; }

        public List<SauceDto> Sauces { get; set; }

        public List<ToppingDto> Toppings { get; set; }
    }
}
