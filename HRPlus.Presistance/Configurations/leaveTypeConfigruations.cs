using HRPlus.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HRPlus.Presistance.Configurations
{
    public class LeaveTypeConfigruations : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
                 builder.HasData(
                  new LeaveType
                  {
                      Id = 1,
                      Name = "Vaction",
                      DefaultDays = 25,
                      DaateCreated = DateTime.Now,
                      DaateModified = DateTime.Now,
                  }
                 );
            builder.Property(q => q.Name)
                 .IsRequired()
                 .HasMaxLength(100);
        }
    }
}
