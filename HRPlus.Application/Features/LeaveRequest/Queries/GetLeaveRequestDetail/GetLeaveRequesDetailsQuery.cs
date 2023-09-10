using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequesDetailsQuery : IRequest<GetLeaveRequestDetailsDTO>
    {
        public int Id { get; set; }
    }
}
