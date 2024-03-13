using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using Persistence.Repository.Abstract;

namespace Persistence.Repository.Concrete;

public class UserRepository : EfRepositoryBase<User,int,BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
}