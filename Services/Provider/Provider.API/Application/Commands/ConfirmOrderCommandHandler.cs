using MediatR;
using Provider.Domain.AggregatesModels.OrderAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Provider.API.Application.Commands
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, bool>
    {
        private readonly IOrderRepository _providerRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public ConfirmOrderCommandHandler(IMediator mediator, IOrderRepository orderRepository)
        {
            _providerRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(ConfirmOrderCommand message, CancellationToken cancellationToken)
        {
            var order = await _providerRepository.GetAsync(message.OrderId);
            order.SetConfirmedStatus();
            _providerRepository.Update(order);

            return await _providerRepository.UnitOfWork
                .SaveEntitiesAsync();
        }
    }
}
