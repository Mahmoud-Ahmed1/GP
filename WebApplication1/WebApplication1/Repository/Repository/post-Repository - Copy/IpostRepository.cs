

using WebApplication1.models;

namespace WebApplication1.Repository.Repository
{
    public interface IpostRepository : IRepository<post>
    {

        Task<post> updatat(post entity);

    }
}
