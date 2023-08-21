using AutoMapper;
using HRPlus.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRPlus.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRPlus.Application.Features.LeaveAllocation.Queries.GetAlleaveAllocationsDetails;
using HRPlus.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HRPlus.Domain;

namespace HRPlus.Application.MappingProfile
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<GetAllLeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveType>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveType>();
        }

    }
}
