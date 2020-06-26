using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Business.ServiceBase;
using Data.Entity;
using Data.Respository;
using DomainResource.Resource;
using Nelibur.ObjectMapper;
using Utility.Enum;
using Utility.Helper;

namespace Business.Services
{
    public class OrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Order PlaceOrder(PizzaDto pizzaDto)
        {
            var pizza = TinyMapper.Map<Pizza>(pizzaDto);

            var order = new Order
            {
                Id = OrderIdGenereHelper.RandomId(),
                OrderCreatedOn = DateTime.UtcNow,
                OrderStatus = OrderStatusEnum.Received,
                StatusUpdatedOn = DateTime.UtcNow,
                Pizza = pizza
            };

            return _dataContext.Orders.Create(order);
        }

        public Order GetOrder(string orderId)
        {
            return _dataContext.Orders.Find(x => x.Id == orderId);
        }

        public List<Order> GetUnassignedOrders()
        {
            return _dataContext.Orders.Get(x => x.OrderStatus == OrderStatusEnum.Received);
        }
    }
}
