using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using MediatR;

namespace HRPlus.Application.Features.LeaveType.Queries.GetLeaveTpyesDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveTypeDetails  = await _leaveTypeRepository.GetByIdAsync(request.Id);

            var leaveTypeDtailsData = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);

            return leaveTypeDtailsData;

        }
    }
}
