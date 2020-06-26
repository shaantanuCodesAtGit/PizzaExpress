using System;
using System.Collections.Generic;
using System.Text;
using Business.Factory;
using Data.Entity;
using Data.Respository;
using DomainResource.Resource;
using Nelibur.ObjectMapper;

namespace Business.Services
{
    public class AllPizzaService
    {
        private readonly DataContext _dataContext;

        public AllPizzaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<PizzaDto> GetAllPizzas()
        {
            var pizzaCollection = new List<Pizza>
            {
                new ExoticPizzaService(_dataContext).GetPizza(),
                new SupremePizzaService(_dataContext).GetPizza(),
                new ChickenPizzaService(_dataContext).GetPizza(),
            };

            return TinyMapper.Map<List<PizzaDto>>(pizzaCollection);
        }

        public PizzaDto GetPizza(string name)
        {
            var pizzaFactory = new PizzaFactory(_dataContext);
            var pizzaService = pizzaFactory.ChoosenPizza(name);

            return pizzaService == null 
                    ? null 
                    : TinyMapper.Map<PizzaDto>(pizzaService.GetPizza());
        }
    }
}
