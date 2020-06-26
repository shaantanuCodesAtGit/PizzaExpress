using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Services;
using Data.Entity;
using Data.Respository;
using DomainResource.Resource;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using Utility;
using Utility.Helper;

namespace PizzaOrderingApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly AllPizzaService _allPizzaService;

        public PizzaController(DataContext dataContext)
        {
            _dataContext = dataContext;

            _allPizzaService = new AllPizzaService(_dataContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pizzas = _allPizzaService.GetAllPizzas();

            return Ok(pizzas);
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var pizza = _allPizzaService.GetPizza(name);

            // could do a direct return from here.
            // just in case we need to do logging that's why throwing error.
            if (pizza == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Pizza you are looking for is unavailable");
            }

            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
