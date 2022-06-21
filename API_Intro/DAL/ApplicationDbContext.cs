using API_Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Intro.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
