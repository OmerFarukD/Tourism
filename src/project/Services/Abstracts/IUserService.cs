using Core.Security.Entities;

namespace Services.Abstracts;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User> GetByEmailAsync(string email);
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> DeleteUserAsync(int id);
}