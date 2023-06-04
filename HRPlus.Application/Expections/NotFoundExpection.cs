using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPlus.Application.Expections
{
    public class NotFoundExpection : Exception
    {
        public NotFoundExpection(string name, object key) : base($"{name} ({key}) was not found)")
        {

        }
    }
}

