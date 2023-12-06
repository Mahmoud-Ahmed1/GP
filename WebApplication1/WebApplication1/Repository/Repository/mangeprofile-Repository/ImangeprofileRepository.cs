

using WebApplication1.models;

namespace WebApplication1.Repository.Repository
{
    public interface ImangeprofileRepository : IRepository<ApplicationUser>
    {

       public Task<ApplicationUser> updatat(ApplicationUser entity);

    }
}
