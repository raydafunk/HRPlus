using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveRequest.Commands.ChangeLeaveRequest
{
    public class ChangeLeaveRequestApprovalCommandValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestApprovalCommandValidator()
        {
             RuleFor(p => p.Apporved)
            .NotNull()
            .WithMessage("Approval status cannot be null");
        }
    }
}
