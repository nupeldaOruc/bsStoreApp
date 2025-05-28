using Microsoft.EntityFrameworkCore;
using webApi.Models;
using webApi.Repositories.Config;

namespace webApi.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
