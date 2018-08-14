using MediatR;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using Provider.Domain.AggregatesModels.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // Add/Update the Buyer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate
            var order = new Order(message.UserId, message.ProviderId, message.OrderId, message.OrderDate);

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
