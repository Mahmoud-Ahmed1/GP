
using WebApplication1.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    public class appDbcontext1 : IdentityDbContext<applecationuser>
    {  public appDbcontext1(DbContextOptions<appDbcontext1> options) : base(options) { }




        public DbSet<post> posts { get; set; }


    }
}