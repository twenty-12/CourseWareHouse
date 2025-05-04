using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        // Task<IEnumerable<Course>> GetCoursesByTagAsync(string tag, SkillLevel? skillLevel); // пока не знаю как брать
        Task AddAsync(Course course);
    }
}