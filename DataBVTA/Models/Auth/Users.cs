using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models
{
    public class Users
    {
        public string UserID { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

    }
}
