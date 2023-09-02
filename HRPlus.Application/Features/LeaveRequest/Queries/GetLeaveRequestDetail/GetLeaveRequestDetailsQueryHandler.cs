using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail
{
    public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequesDetailsQuery, GetLeaveRequestDetailsDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<GetLeaveRequestDetailsDTO> Handle(GetLeaveRequesDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveRequestObject = _mapper.Map<GetLeaveRequestDetailsDTO>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));

            if(leaveRequestObject == null)
              throw new NotFoundException(nameof(LeaveRequest), request.Id);
            // Add Employee details as needed

            return leaveRequestObject;
        }
    }
}
