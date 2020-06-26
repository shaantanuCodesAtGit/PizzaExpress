using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Ingredient;
using Data.Respository;
using DomainResource.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaOrderingApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public IngredientController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/Ingredient
        [HttpGet]
        public IngredientDto Get()
        {
            var ingredients = new IngredientService(_dataContext).GetIngredients();

            return ingredients;
        }
    }
}
