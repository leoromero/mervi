using MediatR;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.Commands
{
    public class SetOrderItemsAsConfirmedCommandHandler : IRequestHandler<SetOrderItemsAsConfirmedCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public SetOrderItemsAsConfirmedCommandHandler(IMediator mediator, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(SetOrderItemsAsConfirmedCommand message, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetAsync(message.OrderId);

            foreach (var item in message.OrderItems)
            {
                orderToUpdate.SetItemAsSubmitted(item.ProductId, message.ProviderId);
            }

            _orderRepository.Update(orderToUpdate);

            return await _orderRepository
                .UnitOfWork.SaveEntitiesAsync();
        }
    }
}
