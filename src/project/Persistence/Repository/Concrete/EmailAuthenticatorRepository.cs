using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using Persistence.Repository.Abstract;

namespace Persistence.Repository.Concrete;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator,int,BaseDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(BaseDbContext context) : base(context)
    {
    }
}