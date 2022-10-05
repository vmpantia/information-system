using Microsoft.EntityFrameworkCore;

namespace IS.Web.DataAccess
{
    public class ISDbContext : DbContext
    {
        public ISDbContext() : base() { }
        public ISDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Department> Department  { get; set; }
        public virtual DbSet<Department_TRN> Department_TRN { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Position_TRN> Position_TRN { get; set; }
        public virtual DbSet<Request> Request { get; set; }
    }
}
