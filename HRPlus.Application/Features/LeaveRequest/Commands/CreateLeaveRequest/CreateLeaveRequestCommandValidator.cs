using FluentValidation;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Features.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository )
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveRequestValidator(_leaveTypeRepository))
        }
    }
}
