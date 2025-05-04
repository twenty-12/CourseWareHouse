using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
    }
}