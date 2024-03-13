using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using Persistence.Repository.Abstract;

namespace Persistence.Repository.Concrete;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator,int,BaseDbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(BaseDbContext context) : base(context)
    {
    }
}