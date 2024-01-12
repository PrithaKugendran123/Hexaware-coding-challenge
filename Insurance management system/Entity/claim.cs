using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_management_system.Entity
{
    
        class Claim
        {
            public int claimID{ get; set; }
            public string ClaimNUmber { get; set; }
            public DateTime dateFiled { get; set; }
            public int claimAmount { get; set; }
        public string status { get; set; }

        public int policyID { get; set; }
        public int clientID { get; set; }
      
        }
    }

