using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using MediatR;

namespace HRPlus.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{

    public class GetLeaveTypesHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypesHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // call the Database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //convert the data object to DTO
           var leaveData =  _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            // return a list of DTO objects 
            return leaveData;
        }
    }
}
