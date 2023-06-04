using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using MediatR;

namespace HRPlus.Application.Features.LeaveType.Commands.CreateLeaveType
{
    internal class CreateLeaveTypeHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data 
            var validator = new CreateleaveTypeCommandVaildator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BedRequestExepection("Invalid leaveTypes please check the leave type", validationResult);
            // convert
            var leavetypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            // add to database
            await _leaveTypeRepository.CreateAsync(leavetypeToCreate);

            // return the id

            return leavetypeToCreate.Id;
        }
    }
}
