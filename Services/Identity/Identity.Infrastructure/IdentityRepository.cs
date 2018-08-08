using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Identity.Infrastructure
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IdentityContext _context;
        
        public IdentityRepository(IdentityContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User Add(User user)
        {
            return _context.Users.Add(user).Entity;
        }

        public async Task<User> GetAsync(string userName)
        {
            var user = await _context.Users
                .Include(o => o.Roles)
                .SingleOrDefaultAsync(o => o.UserName == userName);

            return user;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<bool> SaveEntitiesAsync()
        {
            return await _context.SaveEntitiesAsync();
        }
    }
}
