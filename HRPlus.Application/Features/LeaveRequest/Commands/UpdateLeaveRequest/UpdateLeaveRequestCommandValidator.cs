using FluentValidation;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Features.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;

            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveRequestMustExit)
                .WithMessage("{PropertyName} must be present");
        }

        private async Task<bool> LeaveRequestMustExit(int Id, CancellationToken arg2)
        {
            var leaveAllocationRequest = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveAllocationRequest != null;
        }
    }
}
