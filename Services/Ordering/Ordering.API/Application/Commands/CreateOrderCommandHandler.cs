using MediatR;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateOrderCommandHandler(IMediator mediator, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateOrderCommand message, CancellationToken cancellationToken)
        {
            // Add/Update the Buyer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate
            var address = new Address(message.Street, message.City, message.State, message.Country, message.ZipCode, message.Comments);
            var order = new Order(message.UserId, address);

            foreach (var item in message.OrderItems)
            {
                order.AddOrderItem(item.ProductId, item.ProductId, item.ProductName, item.UnitPrice, item.Discount, item.PictureUrl, item.Units);
            }

            _orderRepository.Add(order);

            return await _orderRepository.UnitOfWork
                .SaveEntitiesAsync();
        }
    }
}
