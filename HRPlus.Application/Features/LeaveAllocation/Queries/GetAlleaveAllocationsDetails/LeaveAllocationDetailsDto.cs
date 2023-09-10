using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Features.LeaveAllocation.Queries.GetAlleaveAllocationsDetails
{
    public  class LeaveAllocationDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public DateTime? DaateCreated { get; set; }
        public DateTime? DaateModified { get; set; }
    }
}
