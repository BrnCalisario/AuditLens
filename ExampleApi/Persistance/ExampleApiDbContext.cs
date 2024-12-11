using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Persistance
{
    public class ExampleApiDbContext : DbContext
    {
        public ExampleApiDbContext(DbContextOptions<ExampleApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}