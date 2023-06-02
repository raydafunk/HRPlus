using HRPlus.Domain.Common;

namespace HRPlus.Domain;

public class LeaveType : BaseEntity
{
    public string? Name { get; set; } = string.Empty;
    public string? DefaultDays { get; set; }
}
