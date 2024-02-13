using HousingDB.DB;
using Microsoft.EntityFrameworkCore;

namespace HousingDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            string path = Directory.GetCurrentDirectory();
            builder.Services.AddDbContext<HousingDBContext>(options =>
                    options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                .Replace("[DataDirectory]", path)));



            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
