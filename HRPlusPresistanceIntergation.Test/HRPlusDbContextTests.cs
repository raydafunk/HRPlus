using HRPlus.Domain;
using HRPlus.Presistance.DatabaaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HRPlusPresistanceIntergation.Test
{
    public class HRPlusDbContextTests
    {
        private readonly HRPlusDbContext _hrPlusDatabaseContext;

        public HRPlusDbContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HRPlusDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;


            _hrPlusDatabaseContext = new HRPlusDbContext(dbOptions);
        }

        [Fact]
        public async Task Save_SetDateCreatedValue()
        {
            //Arrange 
            var leaveType = new LeaveType
            {
                Id = 2,
                DefaultDays = 11,
                Name = "Test Sick",
            };

            //Act
            await _hrPlusDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrPlusDatabaseContext.SaveChangesAsync();

            //assert
            leaveType.DaateCreated.ShouldNotBeNull();
        }
        [Fact]
        public async Task Save_SetModifiedValue()
        {
            //Arrange 
            var leaveType = new LeaveType
            {
                Id = 2,
                DefaultDays = 11,
                Name = "Test Sick",
            };

            //Act
            await _hrPlusDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrPlusDatabaseContext.SaveChangesAsync();

            //assert
            leaveType.DaateModified.ShouldNotBeNull();
        }
        [Fact]
        public async Task Save_SetModifiedDataValue()
        {
            //Arrange 
            var leaveType = new LeaveType
            {
                Id = 3,
                DefaultDays = 13,
                Name = "Test Sick",
            };

            //Act
            await _hrPlusDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrPlusDatabaseContext.SaveChangesAsync();

            //assert
            leaveType.DaateCreated.ShouldNotBeNull();
        }

    }
}