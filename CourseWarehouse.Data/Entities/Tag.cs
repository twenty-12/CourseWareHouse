using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TagCategory Category { get; set; }
        public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
        public ICollection<UserTag> UserTags { get; set; } = new List<UserTag>();
    }
}