using System.Linq.Expressions;
using WebApplication1.models;

namespace WebApplication1.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        public Task save();
        Task Remove(T entity);

        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> Get(Expression<Func<T, bool>>? filter = null, bool track = true);


    }
}