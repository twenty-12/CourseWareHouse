using CourseWarehouse.Data.Entities;

namespace CourseWarehouse.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag?> GetTagByIdAsync(int id);
    }
} 