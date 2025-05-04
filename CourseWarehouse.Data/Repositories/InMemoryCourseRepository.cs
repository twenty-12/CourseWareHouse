using CourseWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseWarehouse.Data.Repositories
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private readonly InMemoryContext _context;

        public InMemoryCourseRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.CourseTags)
                .ThenInclude(ct => ct.Tag)
                .ToListAsync();
        }

        public Task<Course?> GetCourseByIdAsync(int id)
        {
            return _context.Courses
                .Include(c => c.CourseTags)
                .ThenInclude(ct => ct.Tag)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    
        // get course by tags

        public async Task AddAsync(Course course)
        {
            await _context.AddAsync(course);
            await _context.SaveChangesAsync();
        }
    }
}