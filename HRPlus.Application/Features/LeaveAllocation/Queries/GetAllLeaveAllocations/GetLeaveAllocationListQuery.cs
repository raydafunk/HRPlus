using MediatR;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public record GetLeaveAllocationListQuery : IRequest<List<GetAllLeaveAllocationDto>>;
