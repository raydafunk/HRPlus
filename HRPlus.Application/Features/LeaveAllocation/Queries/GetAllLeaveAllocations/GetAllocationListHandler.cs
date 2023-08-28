using AutoMapper;
using HRPlus.Application.Contracts.Presistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations
{
    public class GetAllocationListHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetAllocationListHandler(
            ILeaveAllocationRepository 
            leaveAllocationRepository,
                  IMapper mapper)
        {
            this._leaveAllocationRepository = leaveAllocationRepository;
           this._mapper = mapper;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocationTypes = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();
            var allications = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocationTypes);

            return allications;
        }
    }
}
