using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Expections;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            this._leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocationRequest = await _leaveAllocationRepository.GetByIdAsync(request.Id);

            if (leaveAllocationRequest == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            await _leaveAllocationRepository.DeleteAsync(leaveAllocationRequest);
            return Unit.Value;
        }

    }
}
