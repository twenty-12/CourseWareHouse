using CourseWarehouse.Data.Enums;

namespace CourseWarehouse.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public ICollection<UserTag>  UserTags { get; set; } = new List<UserTag>();
    }
}