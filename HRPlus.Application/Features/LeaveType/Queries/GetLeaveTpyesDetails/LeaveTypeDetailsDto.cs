namespace HRPlus.Application.Features.LeaveType.Queries.GetLeaveTpyesDetails
{
    public class LeaveTypeDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public DateTime? DaateCreated { get; set; }
        public DateTime? DaateModified { get; set; }
    }
}