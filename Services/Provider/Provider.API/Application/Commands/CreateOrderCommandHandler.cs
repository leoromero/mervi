using MediatR;
using Provider.Domain.AggregatesModels.OrderAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Provider.API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _providerRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateOrderCommandHandler(IMediator mediator, IOrderRepository orderRepository)
        {
            _providerRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateOrderCommand message, CancellationToken cancellationToken)
        {
            var order = new Order( message.ProviderId, message.OrderId, message.OrderDate);

            foreach (var item in message.OrderItems)
            {
                order.AddOrderItem( item.ProductId, item.ProductName, item.UnitPrice, item.PictureUrl, item.Units);
            }

            _providerRepository.Add(order);

            return await _providerRepository.UnitOfWork
                .SaveEntitiesAsync();
        }
    }
}
