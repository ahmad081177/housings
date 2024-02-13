using HousingModel;
using Microsoft.EntityFrameworkCore;

namespace HousingDB.DBModels
{
    public class HousingDBContext : DbContext
    {
        public HousingDBContext(DbContextOptions<HousingDBContext> options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<House> Houses{ get; set; }
        public DbSet<HouseLocation> HouseLocations { get; set; }
        public DbSet<HouseBuildingDetail> HouseBuildingDetails { get; set; }
    }
}
