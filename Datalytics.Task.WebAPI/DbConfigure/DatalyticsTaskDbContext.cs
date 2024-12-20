using Datalytics.Task.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datalytics.Task.WebAPI.DbConfigure
{
    public class DatalyticsTaskDbContext : DbContext
    {
        public DatalyticsTaskDbContext(DbContextOptions<DatalyticsTaskDbContext> options) : base(options)
        {

        }
        public DatalyticsTaskDbContext()
        {

        }

        public virtual DbSet<EventManagementModel> Events { get; set; }
    }
}
