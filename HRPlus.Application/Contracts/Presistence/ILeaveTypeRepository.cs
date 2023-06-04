using HRPlus.Domain;

namespace HRPlus.Application.Contracts.Presistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> ILeaveTypeUnique(string name);
    }
}

