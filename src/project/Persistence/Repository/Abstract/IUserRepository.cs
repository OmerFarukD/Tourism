using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Persistence.Repository.Abstract;

public interface IUserRepository : IAsyncRepository<User,int>, IRepository<User,int>
{
    
}