using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_management_system.Exception
{
    public class PolicyNotFoundException : System.Exception
    {
        public PolicyNotFoundException(string message) : base(message)
        {
        }
    }
}
