using Catalog.Domain.AggregatesModels.ProductAggregate;
using Catalog.Infrastructure.EntityConfigurations;
using MediatR;
using Mervi.Infrastructure;
using Mervi.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products{ get; set; }

        private readonly IMediator _mediator;

        private CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        public CatalogContext(DbContextOptions<CatalogContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseSequenceHiLo("DBSequenceHiLo");
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
