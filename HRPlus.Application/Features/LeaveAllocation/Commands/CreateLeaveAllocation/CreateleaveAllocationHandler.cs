using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using MediatR;

namespace HRPlus.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateleaveAllocationHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateleaveAllocationHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        

        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation Request");

            var leaveTypeRequest = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

            //Todo Get Employees

            // Todo Get Period

            var LeaveAllocationRequest = _mapper.Map<Domain.LeaveAllocation>(request);
            await _leaveAllocationRepository.CreateAsync(LeaveAllocationRequest);
            return Unit.Value;


        }
    }
}
