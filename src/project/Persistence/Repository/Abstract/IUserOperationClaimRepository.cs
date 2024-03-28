using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Persistence.Repository.Abstract;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim,int>,IRepository<UserOperationClaim,int>
{
    
}