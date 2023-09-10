using AutoMapper;
using HRPlus.Application.Contracts.Logging;
using HRPlus.Application.Contracts.Presistence;
using MediatR;

namespace HRPlus.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{

    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }

        /// <summary>
        /// Handle the data for the leavetype 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            
            var leaveTypes = await _leaveTypeRepository.GetAsync();

           
           var leaveData =  _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            _logger.LogInformation("Leave types where retve sucessfull");
            return leaveData;
        }
    }
}
