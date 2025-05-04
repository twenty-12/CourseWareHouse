using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Services;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCoursesAsync(SkillLevel? skillLevel, string? tag);
    Task<Course?> GetCourseByIdAsync(int id);
    Task CreateCourseAsync(Course course);
}