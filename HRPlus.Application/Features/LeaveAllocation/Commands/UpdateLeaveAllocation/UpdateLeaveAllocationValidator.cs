using FluentValidation;
using HRPlus.Application.Contracts.Presistence;

namespace HRPlus.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationValidator : AbstractValidator<UpdateLeaveAllocationCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            this._leaveAllocationRepository = leaveAllocationRepository;
          
            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than{ComparisonValue}");

            RuleFor(p =>p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .MustAsync(LeaveTypeMustExit)
                .WithMessage("{ProperyName} does not exit");
            
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveAllocationMustExit)
                .WithMessage("{ProperyName} does not exit");
        }

        private async Task<bool> LeaveAllocationMustExit(int id, CancellationToken arg2)
        {
            var leaveAllocationRequest = await _leaveAllocationRepository.GetByIdAsync(id);
            return leaveAllocationRequest != null;
        }

        private async Task<bool> LeaveTypeMustExit(int id, CancellationToken arg2)
        {
           var leaveTypeRequest = await _leaveTypeRepository.GetByIdAsync(id);
            return leaveTypeRequest != null;
        }

    }
}
