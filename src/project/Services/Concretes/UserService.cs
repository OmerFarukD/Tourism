using Core.CrossCuttingConcerns.Types;
using Core.Security.Entities;
using Persistence.Repository.Abstract;
using Services.Abstracts;
using Services.Constants;

namespace Services.Concretes;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }


    public async Task<User> AddAsync(User user)
    {
        var created = await _repository.AddAsync(user);
        return created;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _repository.GetAsync(x => x.Email == email);
        if (user is null)
        {
            throw new NotFoundException(Messages.UserNotFoundMessage);
        }

        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _repository.GetListAsync();
        return users;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _repository.GetAsync(predicate: x => x.Id == id);
        if (user is null)
        {
            throw new NotFoundException(Messages.UserNotFoundMessage);
        }

        return user;

    }

    public async Task<User> DeleteUserAsync(int id)
    {
        var user = await _repository.GetAsync(predicate: x => x.Id == id);
        if (user is null)
        {
            throw new NotFoundException(Messages.UserNotFoundMessage);
        }

        var deleted= await _repository.DeleteAsync(user);
        return deleted;

    }
}