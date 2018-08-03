using Basket.BL.Mappers;
using Basket.DTOs.Requests;
using Basket.Infrastructure;
using EventBus.Abstractions;
using EventBus.Events;
using Factory;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Basket.BL.Tests
{
    [TestFixture]
    public class BasketServiceTests
    {
        [Test]
        public async Task Checkout_Should_Success()
        {
            var repository = new Mock<IBasketRepository>();
            var eventBus = new Mock<IEventBus>();
            var service = new BasketService(repository.Object, eventBus.Object, new CustomerBasketMapper());
            var basket = CustomerBasketFactory.GetCustomerBasketWithItems();

            repository.Setup(x => x.GetBasketAsync(It.IsAny<string>())).ReturnsAsync(basket);
            eventBus.Setup(x => x.Publish(It.IsAny<IntegrationEvent>()));

            BasketCheckoutRequest basketCheckout = new Mock<BasketCheckoutRequest>().Object;
            await service.Checkout(basketCheckout);

            repository.Verify(mock => mock.GetBasketAsync(It.IsAny<string>()), Times.Once);
            eventBus.Verify(mock => mock.Publish(It.IsAny<IntegrationEvent>()), Times.Once);
        }
    }
}
