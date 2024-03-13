using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Persistence.Repository.Abstract;

public interface IOtpAuthenticatorRepository : IAsyncRepository<OtpAuthenticator,int>,IRepository<OtpAuthenticator,int>
{
    
}