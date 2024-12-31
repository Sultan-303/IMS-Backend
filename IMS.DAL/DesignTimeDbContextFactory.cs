using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace IMS.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IMSContext>
    {
        public IMSContext CreateDbContext(string[] args)
{
    var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
    
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddEnvironmentVariables()
        .Build();

    var optionsBuilder = new DbContextOptionsBuilder<IMSContext>();
    optionsBuilder
        .UseNpgsql(connectionString)
        .ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

    return new IMSContext(optionsBuilder.Options, configuration);
}
    }
}