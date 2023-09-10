using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using MediatR;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAlleaveAllocationsDetails
{
    public class GetLeaveAllocationDetailsHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
    {
        private readonly ILeaveAllocationRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        
        public GetLeaveAllocationDetailsHandler(IMapper mapper, ILeaveAllocationRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            
        }

        public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocationTypeRequest = await _leaveTypeRepository.GetLeaveAllocationWithDetails(request.Id);
            if(leaveAllocationTypeRequest == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocationTypeRequest);
        }
    }
}
