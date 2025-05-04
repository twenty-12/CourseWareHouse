using CourseWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseWarehouse.Data.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly InMemoryContext _context;

        public InMemoryUserRepository(InMemoryContext context)
        {
            _context = context;
        }

        public Task<User?> GetByIdAsync(int userId)
        {
            return _context.Users
                .Include(u => u.UserTags)
                    .ThenInclude(ut => ut.Tag)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpsertAsync(User user)
        {
            var existingUser = await _context.Users
                .Include(u => u.UserTags)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser != null)
            {
                // update юзера
                _context.Entry(existingUser).CurrentValues.SetValues(user);
                existingUser.UserTags = user.UserTags;
            }
            else
            {
                // add нового 
                await _context.Users.AddAsync(user);
            }

            await _context.SaveChangesAsync();
        }
    }
}