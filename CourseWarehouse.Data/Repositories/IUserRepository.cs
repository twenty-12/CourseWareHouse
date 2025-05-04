using CourseWarehouse.Data.Entities;

namespace CourseWarehouse.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int userId);
        Task UpsertAsync(User user);
    }
}