using Insurance_management_system.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_management_system.Dao
{
     interface IInsuranceManagementService
    {

       
            
           bool CreatePolicy(Policy policy);

            
           List<Policy> GetPolicy(int policyId);

            
           List<Policy> GetAllPolicies();


           bool UpdatePolicy(int policyID, string details);



           bool DeletePolicy(int policyId);
        }

    }

