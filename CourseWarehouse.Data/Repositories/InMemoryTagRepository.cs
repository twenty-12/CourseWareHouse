using CourseWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseWarehouse.Data.Repositories
{
    public class InMemoryTagRepository : ITagRepository
    {
        private readonly InMemoryContext _context;

        public InMemoryTagRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return _context.Tags.ToList();  // пересмотреть потом
        }

        public Task<Tag> GetByIdAsync(int id)
        {
            return _context.Tags
                .FindAsync(id).AsTask();  // ???
        }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }
    }
}