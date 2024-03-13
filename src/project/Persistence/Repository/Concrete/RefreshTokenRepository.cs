using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using Persistence.Repository.Abstract;

namespace Persistence.Repository.Concrete;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken,int,BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context) : base(context)
    {
    }
}