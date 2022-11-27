using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.ViewModels
{
    public class PermissionViewModel
    {
        public List<Roles> ListRoles { get; set; }

        public List<Users> ListUsers { get; set; }
        public Users User { get; set; }

        public List<UserInRole> UserInRoles { get; set; }

        public List<ModuleAction> ListAction { get; set; }

        public List<ModuleController> ListController { get; set; }

        public List<NavigationMenu> ListMenus { get; set; }        

    }
}
