using HRPlus.Domain;

namespace HRPlus.Application.Contracts.Presistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);

        Task<List<LeaveRequest>> GetLeaveRequestWithDeatails();

        Task<List<LeaveRequest>> GeetLeaveRequestWithDetails(string userId);
    }
}

