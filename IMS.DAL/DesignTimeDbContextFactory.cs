using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IMS.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IMSContext>
    {
        public IMSContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IMSContext>();
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=ims_db;Username=postgres;Password=Watchdogs1!")
                .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));

            return new IMSContext(optionsBuilder.Options);
        }
    }
}