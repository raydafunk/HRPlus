using HRPlus.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public class GetAllLeaveAllocationDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveTypeDto? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
    }
}

