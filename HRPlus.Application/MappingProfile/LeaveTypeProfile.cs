using AutoMapper;
using HRPlus.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRPlus.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HRPlus.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRPlus.Application.Features.LeaveType.Queries.GetLeaveTpyesDetails;
using HRPlus.Domain;

namespace HRPlus.Application.MappingProfile
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
