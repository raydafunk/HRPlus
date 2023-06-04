using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using MediatR;

namespace HRPlus.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler( ILeaveTypeRepository leaveTypeRepository) => _leaveTypeRepository = leaveTypeRepository;
      
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var LeaveTypeToDeleate = await _leaveTypeRepository.GetByIdAsync(request.Id);

            await _leaveTypeRepository.DeleteAsync(LeaveTypeToDeleate.Id);

            return Unit.Value;
        }
    }
}
