using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models
{
    public class Roles
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public bool Checked { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
