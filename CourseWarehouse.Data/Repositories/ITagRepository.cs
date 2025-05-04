using CourseWarehouse.Data.Entities;

namespace CourseWarehouse.Data.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int id);
        Task AddAsync(Tag tag);
    }
}