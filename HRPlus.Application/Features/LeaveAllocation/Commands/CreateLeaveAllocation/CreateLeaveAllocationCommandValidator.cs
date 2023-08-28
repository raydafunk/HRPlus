﻿using FluentValidation;
using HRPlus.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
    {
        private readonly ILeaveTypeRepository _LeaveTypeRepository;
        public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _LeaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(LeaveTypeMustExits)
                .WithMessage("{PropetyName} does not exit");
        }

        private async Task<bool> LeaveTypeMustExits(int id, CancellationToken arg2)
        {
           var leaveType = await _LeaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }
    }
}
