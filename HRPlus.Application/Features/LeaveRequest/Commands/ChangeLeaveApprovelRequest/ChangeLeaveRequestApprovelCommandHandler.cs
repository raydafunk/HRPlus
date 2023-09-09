using AutoMapper;
using HRPlus.Application.Contracts.Email;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using HRPlus.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HRPlus.Application.Models.Email;
using HRPlus.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveRequest.Commands.ChangeLeaveRequest
{
    public class ChangeLeaveRequestApprovelCommandHandler : IRequest<ChangeLeaveRequestApprovelCommandHandler, Unit>
    {

        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ChangeLeaveRequestApprovelCommandHandler(IMapper mapper, IEmailSender emailSender, ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;   
            this._emailSender = emailSender;
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequestType = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequestType == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            leaveRequestType.Approved = request.Apporved;
            await _leaveRequestRepository.UpdateAsync(leaveRequestType);

            //Todo if request is approved, get and update the employee's allocations

            await SendEmployeeEmail(leaveRequestType);
            return Unit.Value;

        }

        private async Task SendEmployeeEmail(Domain.LeaveRequest leaveRequestType)
        {
            //sending an email
            var email = new EmailMessage
            {
                To = string.Empty, /* Get email from employee record */
                Body = $"The approval status for your leave request for {leaveRequestType.StartDate:D} to {leaveRequestType.EndDate:D} " +
                    $"has been updated.",
                Subject = "Leave Request Approval Status Updated"
            };

            await _emailSender.SendEmail(email);
        }
    }
}

