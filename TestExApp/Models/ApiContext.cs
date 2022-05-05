using Microsoft.EntityFrameworkCore;

namespace TestExApp.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
           : base(options)
        { 
        }
    }
}
