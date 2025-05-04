using CourseWarehouse.Data.Dto;
using CourseWarehouse.Data.Entities;

namespace CourseWarehouse.Services;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int userId);
    Task UpsertAsync(int userId, UserDto dto);
}