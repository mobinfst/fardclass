using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace aminansari.Models
{
    public class AminDbContext : DbContext
    {
        public AminDbContext(DbContextOptions<AminDbContext> options) : base(options)
        {
      
        }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }

       
    }
}
