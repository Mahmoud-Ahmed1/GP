

using WebApplication1.models;

namespace WebApplication1.Repository.Repository
{
    public interface ImangeprofileRepository : IRepository<applecationuser>
    {

       public Task<applecationuser> updatat(applecationuser entity);

    }
}
