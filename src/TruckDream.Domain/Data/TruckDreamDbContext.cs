using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TruckDream.Domain.Data
{
    public class TruckDreamDbContext : DbContext
    {
        public TruckDreamDbContext(DbContextOptions<TruckDreamDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
