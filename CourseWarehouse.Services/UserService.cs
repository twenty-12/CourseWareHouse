using CourseWarehouse.Data.Dto;
using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Repositories;

namespace CourseWarehouse.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;

        public UserService(IUserRepository userRepository, ITagRepository tagRepository)
        {
            _userRepository = userRepository;
            _tagRepository = tagRepository;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {userId} not found");
            }

            return user;
        }

        public async Task UpsertAsync(int userId, UserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(userId) ?? new User 
            { 
                Id = userId,
                Name = $"User_{userId}", // переделай
                Email = $"user_{userId}@example.com" // temporary
            };
            
            user.SkillLevel = dto.SkillLevel;
            
            var existingTags = (await _tagRepository.GetAllAsync())
                .ToDictionary(t => t.Name, t => t);

            user.UserTags.Clear();
            foreach (var tagName in dto.Tags)
            {
                if (existingTags.TryGetValue(tagName, out var existingTag))
                {
                    user.UserTags.Add(new UserTag { UserId = userId, Tag = existingTag });
                }
                else
                {
                    var newTag = new Tag { Name = tagName };
                    await _tagRepository.AddAsync(newTag);
                    existingTags[tagName] = newTag;
                    user.UserTags.Add(new UserTag { UserId = userId, Tag = newTag });
                }
            }

            await _userRepository.UpsertAsync(user);
        }
    }
}