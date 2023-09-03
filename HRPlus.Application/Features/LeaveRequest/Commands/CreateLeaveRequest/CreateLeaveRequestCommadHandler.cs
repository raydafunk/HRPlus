using AutoMapper;
using HRPlus.Application.Contracts.Email;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using HRPlus.Application.Models.Email;
using MediatR;

namespace HRPlus.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommadHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
    {
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveRequestCommadHandler(IEmailSender emailSender, IMapper mapper, ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _emailSender = emailSender;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var vaildator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
            var VaildatorResult = await vaildator.ValidateAsync(request);

            if (VaildatorResult.Errors.Any())
              throw new BadRequestException("Invalid Leave Request", VaildatorResult);

            //Get requesting employee's id

            // Check on  employee allocation

            //if the allocation is not enough,return validation error with message 

            // Create LeaveRequest 

            var LeaveRequestObject = _mapper.Map<Domain.LeaveRequest>(request);
            await _leaveRequestRepository.CreateAsync(LeaveRequestObject);
            // send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                        $"has been submitted successfully.",
                    Subject = "Leave Request Submitted"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception)
            {
                //// Log or handle error,
            }
            return Unit.Value;
        }
    }
}
