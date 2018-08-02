using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.Domain;
using Basket.Infrastructure.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Basket.Infrastructure
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public BasketRepository(ConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public IEnumerable<string> GetUsers()
        {
            var server = GetServer();
            var data = server.Keys();
            return data?.Select(k => k.ToString());
        }

        public async Task<CustomerBasket> GetBasketAsync(string customerId)
        {
            var data = await _database.StringGetAsync(customerId);
            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            //Update basket for the client
            var oldBasket = await GetBasketAsync(basket.BuyerId);
            var created = await _database.StringSetAsync(basket.BuyerId, JsonConvert.SerializeObject(basket));
            if (!created)
            {
                //log
                return null;
            }
            //items in oldBasket that are not in the new basket
            var toRemove = oldBasket.Items.Where(x => !basket.Items.Select(i => i.Id).Contains(x.Id)).ToList();
            //items in new basket that are not in the old basket
            var toAdd = basket.Items.Where(x => !oldBasket.Items.Select(i => i.Id).Contains(x.Id)).ToList();

            toAdd.ForEach(async i =>
            {
                await AddProductBasketsAsync(i.ProductId, basket.BuyerId);
            });

            toRemove.ForEach(async i =>
            {
                await RemoveProductBasketsAsync(i.ProductId, basket.BuyerId);
            });

            return await GetBasketAsync(basket.BuyerId);
        }

        public ProductBasketsModel GetProductsBasketsAsync(string id)
        {
            var data = _database.SetMembers(id);
            if (data.Count() == 0)
            {
                return null;
            }

            var model = new ProductBasketsModel { Id = id, BasketsIds = data.Select(x => x.ToString()).ToList() };
            return model;
        }

        private Task<bool> AddProductBasketsAsync(string productId, string userId)
        {
            return _database.SetAddAsync(productId, userId);
        }

        private Task<bool> RemoveProductBasketsAsync(string productId, string userId)
        {
            return _database.SetRemoveAsync(productId, userId);
        }        

        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }
    }
}
