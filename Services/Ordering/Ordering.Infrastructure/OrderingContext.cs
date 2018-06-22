using Microsoft.EntityFrameworkCore;
using Ordering.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class OrderingContext : DbContext, IUnitOfWork
    {
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
