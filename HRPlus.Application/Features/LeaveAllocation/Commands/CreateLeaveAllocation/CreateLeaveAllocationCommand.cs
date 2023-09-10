﻿using MediatR;

namespace HRPlus.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommand : IRequest<Unit>
    {
        public int LeaveTypeId { get; set; }
    }
}