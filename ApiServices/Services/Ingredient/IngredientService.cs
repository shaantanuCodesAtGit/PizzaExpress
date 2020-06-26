using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Respository;
using DomainResource.Resource;
using Nelibur.ObjectMapper;

namespace Business.Services.Ingredient
{
    public class IngredientService
    {
        private readonly DataContext _dataContext;

        public IngredientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IngredientDto GetIngredients()
        {
            var cheeses = _dataContext.Cheeses.GetAll();
            var sauces = _dataContext.Sauces.GetAll();
            var toppings = _dataContext.Toppings.GetAll();

            return new IngredientDto
            {
                Cheeses = TinyMapper.Map<List<CheeseDto>>(cheeses),
                Sauces = TinyMapper.Map<List<SauceDto>>(sauces),
                Toppings = TinyMapper.Map<List<ToppingDto>>(toppings),
            };
        }
    }
}
