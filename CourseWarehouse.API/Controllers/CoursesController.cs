using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;
using CourseWarehouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseWareHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses(
            [FromQuery] string? skillLevel,
            [FromQuery] string? tag)
        {
            SkillLevel? parsedSkillLevel = null;
            if (!string.IsNullOrEmpty(skillLevel) && 
                Enum.TryParse<SkillLevel>(skillLevel, true, out var level))
            {
                parsedSkillLevel = level;
            }

            var courses = await _courseService.GetAllCoursesAsync(parsedSkillLevel, tag);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
    }
} 