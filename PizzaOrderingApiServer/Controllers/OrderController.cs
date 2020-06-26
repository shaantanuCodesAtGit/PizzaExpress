using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Services;
using Data.Respository;
using DomainResource.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using Utility.Helper;

namespace PizzaOrderingApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OrderController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<OrderDto> Get(string id)
        {
            var order = new OrderService(_dataContext).GetOrder(id);
            if (order == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Order does not exists.");
            }

            return TinyMapper.Map<OrderDto>(order);
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<OrderDto> Post([FromBody] PizzaDto pizza)
        {
            var order = new OrderService(_dataContext).PlaceOrder(pizza);

            return TinyMapper.Map<OrderDto>(order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
