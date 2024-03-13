using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using Persistence.Repository.Abstract;

namespace Persistence.Repository.Concrete;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim,int,BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}