using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Data.Dto
{
    public class UserDto
    {
        public SkillLevel SkillLevel { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}