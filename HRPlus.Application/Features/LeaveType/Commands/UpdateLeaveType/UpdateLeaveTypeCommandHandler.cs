﻿using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using MediatR;

namespace HRPlus.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var LeaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

            await _leaveTypeRepository.UpdateAsync(LeaveTypeToUpdate);

            return Unit.Value;
        }
    }
}
