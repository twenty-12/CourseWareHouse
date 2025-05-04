using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Data.Dto
{
    public class EnumsDto
    {
        public List<SkillLevelInfo> SkillLevels { get; set; } = new();
        public List<TagInfo> Tags { get; set; } = new();
    }

    public class SkillLevelInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TagInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
} 