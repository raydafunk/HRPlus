using FluentValidation;
using HRPlus.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.Shared
{
    public class BaseLeaveRequestValidator : AbstractValidator<BaseLeaveRequest>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public BaseLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.StartDate)
                .LessThan(p=> p.EndDate).WithMessage("{PropertyName}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(LeaveTypeMustExist)
                .WithMessage("{{PropertyName} does not exist.}");

        }

        private async Task<bool> LeaveTypeMustExist(int Id, CancellationToken arg2)
        {
            var leaveTypeRequest = await _leaveTypeRepository.GetByIdAsync(Id);
            return leaveTypeRequest != null;

        }
    }
}
