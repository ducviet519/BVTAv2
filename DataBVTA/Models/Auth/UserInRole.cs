using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models
{
    public class UserInRole
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public Users User { get; set; }
        public Roles Role { get; set; }
    }
}
