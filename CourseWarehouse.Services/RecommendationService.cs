using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;
using CourseWarehouse.Data.Repositories;

namespace CourseWarehouse.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ICourseRepository _courseRepository;

        public RecommendationService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetRecommendationsAsync(string tag, SkillLevel? skillLevel)
        {
            var courses = await _courseRepository.GetCoursesAsync();
            
            // фильтр по тегу
            courses = courses.Where(c => c.CourseTags.Any(ct => ct.Tag.Name == tag));
            
            // фильтр по скилу
            if (skillLevel.HasValue)
            {
                courses = courses.Where(c => c.SkillLevel == skillLevel.Value);
            }

            return courses;
        }
    }
} 