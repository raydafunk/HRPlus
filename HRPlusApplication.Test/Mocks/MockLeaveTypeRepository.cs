﻿using HRPlus.Application.Contracts.Presistence;
using HRPlus.Domain;
using Moq;

namespace HRPlusApplication.Test.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = " Test Vaction",
                },
            new LeaveType
            {
                Id = 2,
                DefaultDays = 11,
                Name = "Test Sick",
            },
            new LeaveType
            {
                Id= 3,
                DefaultDays = 12,
                Name = "Test Maternity"
            }

            };
            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(r => r.GetAsync())
                .ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
                .Returns((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return Task.CompletedTask;
                });
            return mockRepo;
        }
    }
}
