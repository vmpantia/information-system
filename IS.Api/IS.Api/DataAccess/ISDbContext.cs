using Microsoft.EntityFrameworkCore;

namespace IS.Web.DataAccess
{
    public class ISDbContext : DbContext
    {
        public ISDbContext() : base() { }
        public ISDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Department_MST> Department_MST  { get; set; }
        public virtual DbSet<Department_TRN> Department_TRN { get; set; }
        public virtual DbSet<Position_MST> Position_MST { get; set; }
        public virtual DbSet<Position_TRN> Position_TRN { get; set; }
        public virtual DbSet<Request_LST> Request_LST { get; set; }
    }
}
