using HRPlus.Domain;
using HRPlus.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HRPlus.Presistance.DatabaaseContext
{
    public  class HRPlusDbContext : DbContext
    {
        public HRPlusDbContext(DbContextOptions<HRPlusDbContext> opitons) : base(opitons)
        {

        }
        public DbSet<LeaveType> LeaveTypes{ get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRPlusDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DaateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DaateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
