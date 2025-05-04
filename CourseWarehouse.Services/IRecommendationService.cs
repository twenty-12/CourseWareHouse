using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Services;

public interface IRecommendationService
{
    Task<IEnumerable<Course>> GetRecommendationsAsync(string tag, SkillLevel? skillLevel);
}