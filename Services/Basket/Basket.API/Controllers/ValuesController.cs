using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.Domain;
using Basket.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IBasketRepository basketRepository;

        public ValuesController(IBasketRepository repository)
        {
            this.basketRepository = repository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var basket = new CustomerBasket("123");
            basket.Items.Add(new BasketItem { Id = "1", OldUnitPrice = 12, PictureUrl = "", ProductId = "1", ProductName = "un producto", Quantity = 2, UnitPrice = 123 });
            Task.Run(() => basketRepository.UpdateBasketAsync(basket)).Wait();

            CustomerBasket result;

            var newBasket = new CustomerBasket("321");
            newBasket.Items.Add(new BasketItem { Id = "2", OldUnitPrice = 12, PictureUrl = "", ProductId = "1", ProductName = "otro producto", Quantity = 2, UnitPrice = 123 });
            Task.Run(() => basketRepository.UpdateBasketAsync(newBasket)).Wait();

            var products = Task.Run(() => basketRepository.GetProductsBasketsAsync("1")).Result;

            result = Task.Run(() => basketRepository.GetBasketAsync("123")).Result;

            return new string[] { products.BasketsIds.ToArray().ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
