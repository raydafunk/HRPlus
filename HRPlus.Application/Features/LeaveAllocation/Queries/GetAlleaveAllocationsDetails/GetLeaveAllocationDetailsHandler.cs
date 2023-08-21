using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using MediatR;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAlleaveAllocationsDetails
{
    public class GetLeaveAllocationDetailsHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveTypeRepository;

        public GetLeaveAllocationDetailsHandler(IMapper mapper, ILeaveAllocationRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocationType = await _leaveTypeRepository.GetLeaveAllocationWithDetails(request.Id);
            return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocationType);
        }
    }
}
