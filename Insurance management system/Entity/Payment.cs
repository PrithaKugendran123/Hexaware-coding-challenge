using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_management_system.Entity
{
    class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public int  ClientID { get; set; }
    }
}
