using CourseWarehouse.Data.Dto;
using CourseWarehouse.Data.Entities;
using CourseWarehouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseWarehouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationsController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Course>>> GetRecommendations([FromBody] RecommendationsDto request)
        {
            var recommendations = new List<Course>();
            
            foreach (var tag in request.Tags)
            {
                var courses = await _recommendationService.GetRecommendationsAsync(tag, request.SkillLevel);
                recommendations.AddRange(courses);
            }
            
            recommendations = recommendations.DistinctBy(c => c.Id).ToList();
            
            return Ok(recommendations);
        }
    }
} 