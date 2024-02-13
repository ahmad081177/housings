using HousingModels;
using Microsoft.EntityFrameworkCore;

namespace HousingDB.DB
{
    public class HousingDBContext : DbContext
    {
        public HousingDBContext(DbContextOptions<HousingDBContext> options) : base(options)
        {
               
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<House> Houses { get; set; }

    }
}
