using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
        {
            //to do check if to see if employee is logged in 

            var LeaveRequestReturnObject = await _leaveRequestRepository.GetLeaveRequestWithDeatails();
            var leaveRequests = _mapper.Map<List<LeaveRequestListDto>>(LeaveRequestReturnObject);


            // fill the requests with employee information 

            return leaveRequests;
        }
    }
}
