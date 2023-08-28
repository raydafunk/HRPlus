using FluentValidation;
using HRPlus.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            this._leaveAllocationRepository = leaveAllocationRepository;
            RuleFor(p => p.Id)
                 .NotNull()
                 .MustAsync(LeaveTypeMustExit);

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("{PropertityName} is required")
                .NotNull();

            RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(q => q)
           .MustAsync(LeaveTypeNameUnique)
          .WithMessage("Leave type already exists");
        }

      
        private async Task<bool> LeaveTypeMustExit(int id, CancellationToken arg)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }
        private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return await _leaveTypeRepository.ILeaveTypeUnique(command.Name);
        }

    }
}
