using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataBVTA.Models
{
    public class UserMenuPermission
    {
        public string PermissionID { get; set; }
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string NavigationMenuID { get; set; }
        public string NavigationMenuName { get; set; }
    }
}
