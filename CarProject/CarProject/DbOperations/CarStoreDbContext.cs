using CarProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CarProject.DbOperations
{
    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext(DbContextOptions<CarStoreDbContext> options):base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
