using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Persistence.Repository.Abstract;

public interface IEmailAuthenticatorRepository : IRepository<EmailAuthenticator,int>,IAsyncRepository<EmailAuthenticator,int>
{
    
}