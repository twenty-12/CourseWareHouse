using CourseWarehouse.Data.Dto;
using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;
using CourseWarehouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseWareHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnumsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public EnumsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public ActionResult<EnumsDto> GetEnums()
        {
            var skillLevels = Enum.GetValues(typeof(SkillLevel))
                .Cast<SkillLevel>()
                .Select(sl => new SkillLevelInfo
                {
                    Id = (int)sl,
                    Name = sl.ToString(),
                    Description = GetSkillLevelDescription(sl)
                })
                .ToList();

            var tags = _tagService.GetAllTagsAsync().Result
                .Select(t => new TagInfo
                {
                    Id = t.Id,
                    Name = t.Name,
                    Category = t.Category.ToString()
                })
                .ToList();

            return new EnumsDto
            {
                SkillLevels = skillLevels,
                Tags = tags
            };
        }

        private string GetSkillLevelDescription(SkillLevel skillLevel)
        {
            return skillLevel switch
            {
                SkillLevel.Beginner => "Для начинающих, без опыта программирования",
                SkillLevel.Middle => "Для тех, кто уже имеет опыт",
                SkillLevel.Advanced => "Для опытных разработчиков",
                SkillLevel.Basic => "Базовый уровень",
                _ => "Неизвестный уровень"
            };
        }
    }
} 