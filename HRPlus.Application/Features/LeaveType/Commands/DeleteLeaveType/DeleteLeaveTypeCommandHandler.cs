using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
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

            // very the new records 
            if( LeaveTypeToDeleate == null)
               throw new NotFoundExpection(nameof(LeaveTypeToDeleate), request.Id);

            await _leaveTypeRepository.DeleteAsync(LeaveTypeToDeleate);

            return Unit.Value;
        }
    }
}
