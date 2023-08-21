using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
   public record GetLeaveAllocationListQuery : IRequest<List<GetAllLeaveAllocationDto>>;
}
