using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Controllers;
using WebApplication1.Controllers;

using WebApplication1.models;

namespace WebApplication1.Repository
{
    public class Repositoryg <T>: IRepository<T> where T : class
    {
        private readonly appDbcontext1 _db;
        internal DbSet<T> dbset;
        private appDbcontext1 db;
 
        public Repositoryg(appDbcontext1 db )
        {
         
               _db = db;
            this.dbset = _db.Set<T>();
            this.db = db;
        }

     
        public async Task Create(T entity)
        {
            await dbset.AddAsync(entity);
            save();
        }
       
        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, bool track = true)
        {
            IQueryable<T> qurey = dbset;
            if (!track) { qurey = qurey.AsNoTracking(); }
            if (filter != null) { qurey = qurey.Where(filter); }
            return await qurey.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> qurey = dbset;
            if (filter != null) { qurey = qurey.Where(filter); }
            return await qurey.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            dbset.Remove(entity);

            await save();
        }

        public async Task save()
        {
            await _db.SaveChangesAsync();
        }
    }
}