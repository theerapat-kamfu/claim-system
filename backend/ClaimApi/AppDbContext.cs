using Microsoft.EntityFrameworkCore;

namespace ClaimApi.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



    }
}