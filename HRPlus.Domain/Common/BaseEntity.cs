using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DaateCreated { get; set; }
        public DateTime? DaateModified { get; set; }
    }
}
