using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Persistence.Repository.Abstract;

public interface IRefreshTokenRepository : IRepository<RefreshToken,int>, IAsyncRepository<RefreshToken,int>
{
    
}