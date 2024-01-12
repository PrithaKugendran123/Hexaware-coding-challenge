using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_management_system.Entity
{
    public class Users
    {
       public int userID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string role { get; set; }
    }
}
