
using WebApplication1.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    public class appDbcontext1 : IdentityDbContext<ApplicationUser>
    {
        public appDbcontext1(DbContextOptions<appDbcontext1> options) : base(options)
        {

        }

        public DbSet<post> posts { get; set; }
        public DbSet<POSTSLIKES> PostLikes { get; set; }
        public DbSet<POSTSDISLIKES> PostdisLikes { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }

}