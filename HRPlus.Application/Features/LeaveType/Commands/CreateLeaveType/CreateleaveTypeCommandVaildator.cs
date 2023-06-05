using FluentValidation;
using HRPlus.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateleaveTypeCommandVaildator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateleaveTypeCommandVaildator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Name)
                   .NotEmpty().WithMessage("{PropertityName} is required")
                   .NotNull()
                   .MaximumLength(70).WithMessage("{PropertityName} must be fewer then 70 characters");

            RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnigue).WithMessage("Leave type already exists");
            this._leaveTypeRepository = leaveTypeRepository;
        }

        private Task<bool> LeaveTypeNameUnigue(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.ILeaveTypeUnique(command.Name);
        }
    }
}
