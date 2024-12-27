using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IMS.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IMSContext>
{
    public IMSContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? 
            "Host=localhost;Database=ims_db;Username=postgres;Password=Watchdogs1!";
            
        var optionsBuilder = new DbContextOptionsBuilder<IMSContext>();
        optionsBuilder
            .UseNpgsql(connectionString)
            .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));

        return new IMSContext(optionsBuilder.Options);
    }
}
}