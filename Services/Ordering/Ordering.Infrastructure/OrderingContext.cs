using MediatR;
using Mervi.SeedWork;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregatesModels.OrderAggregate;
using Ordering.Infrastructure.EntityConfigurations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class OrderingContext : DbContext, IUnitOfWork
    {
        public DbSet<Order> Orders { get; set; }

        private readonly IMediator _mediator;

        private OrderingContext(DbContextOptions<OrderingContext> options) : base(options) { }

        public OrderingContext(DbContextOptions<OrderingContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseSequenceHiLo("DBSequenceHiLo");
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
