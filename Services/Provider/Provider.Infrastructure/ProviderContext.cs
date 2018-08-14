using MediatR;
using Mervi.Infrastructure;
using Mervi.SeedWork;
using Microsoft.EntityFrameworkCore;
using Provider.Domain.AggregatesModels.OrderAggregate;
using Provider.Infrastructure.EntityConfigurations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Provider.Infrastructure
{
    public class ProviderContext : DbContext, IUnitOfWork
    {
        public DbSet<Order> Orders { get; set; }

        private readonly IMediator _mediator;

        private ProviderContext(DbContextOptions<ProviderContext> options) : base(options) { }

        public ProviderContext(DbContextOptions<ProviderContext> options, IMediator mediator) : base(options)
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
