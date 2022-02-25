using DriverRegister.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DriverRegister.Database
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<DriverEntity> Drivers { get; set; }
        public DbSet<BusEntity> Buses { get; set; }
    }
}
