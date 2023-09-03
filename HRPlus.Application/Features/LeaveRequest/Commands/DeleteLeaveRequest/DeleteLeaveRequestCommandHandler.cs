using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using MediatR;

namespace HRPlus.Application.Features.LeaveRequest.Commands.DeleteLeaveRequet
{
    public class DeleteLeaveRequestCommandHandler : IRequest<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequestObject = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequestObject == null)
               throw new NotFoundException(nameof(LeaveRequest), request.Id);

            await _leaveRequestRepository.DeleteAsync(leaveRequestObject);
             return Unit.Value;
        }
    }
}
