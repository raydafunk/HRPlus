using HRPlus.Application.Features.LeaveType.Queries.GetLeaveTpyesDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAlleaveAllocationsDetails
{
    public record GetLeaveAllocationDetailsQuery(int Id) : IRequest<LeaveAllocationDetailsDto>;
}
