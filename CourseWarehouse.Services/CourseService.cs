using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;
using CourseWarehouse.Data.Repositories;

namespace CourseWarehouse.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync(SkillLevel? skillLevel, string? tag)
        {
            var courses = await _courseRepository.GetCoursesAsync();
            
            if (skillLevel.HasValue)
            {
                courses = courses.Where(c => c.SkillLevel == skillLevel.Value);
            }

            if (!string.IsNullOrEmpty(tag))
            {
                courses = courses.Where(c => c.CourseTags.Any(ct => ct.Tag.Name == tag));
            }

            return courses;
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetCourseByIdAsync(id);
        }

        public async Task CreateCourseAsync(Course course)
        {
            await _courseRepository.AddAsync(course);
        }
    }
} 