using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using MediatR;

namespace HRPlus.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateLeaveAllocationCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var vaildator = new UpdateLeaveAllocationValidator(_leaveTypeRepository, _leaveAllocationRepository);
            var validationResult = await vaildator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation", validationResult);

            var LeaveAllocatonRequest = await _leaveAllocationRepository.GetByIdAsync(request.Id);

            if (LeaveAllocatonRequest is null)
                throw  new NotFoundExpection(nameof(LeaveAllocatonRequest), request.Id);

            _mapper.Map(request, LeaveAllocatonRequest);

            await _leaveAllocationRepository.UpdateAsync(LeaveAllocatonRequest);

            return Unit.Value;


        }
    }
}
