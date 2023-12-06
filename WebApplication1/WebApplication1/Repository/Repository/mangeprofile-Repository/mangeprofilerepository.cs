
using WebApplication1.Controllers;

using WebApplication1.models;

namespace WebApplication1.Repository.Repository
{
    public class mangeprofilerepository : Repositoryg<ApplicationUser>, ImangeprofileRepository
    {
        private readonly appDbcontext1 _db;

        public mangeprofilerepository(appDbcontext1 db) : base(db)
        {
            _db = db;

        }


        public async Task<ApplicationUser> updatat(ApplicationUser entity)
        {   
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}


