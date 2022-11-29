using Microsoft.EntityFrameworkCore;

namespace World.Cup.Simulator
{
    public class WorldCupContext : DbContext
    {
        public WorldCupContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        public DbSet<Team> Teams { get; set; }
    }
}
