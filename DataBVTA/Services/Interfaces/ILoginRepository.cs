using DataBVTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    
    public interface ILoginRepository
    {
        public Task<List<Roles>> GetRoles();
        public Task<string> InsertRole(Roles role, string user = null);
        public Task<string> DeleteRole(string id);

        public Task<List<Users>> GetUsers();
        public Task<Users> GetUsersByNameOrID(string search);
        public Task<string> InsertUsers(Users users);

        public Task<List<ModuleController>> GetControllers();
        public Task<string> InsertController(ModuleController controller, string user = null);

        public Task<List<ModuleAction>> GetActions();
        public Task<string> InsertAction(ModuleAction action, string user = null);

        public Task<List<NavigationMenu>> GetNavigationMenus();
        public Task<string> InsertNavigationMenu(NavigationMenu menu, string user = null);
        public Task<string> DeleteNavigationMenu(string id);

        public Task<List<UserInRole>> GetRoleInUser(string search = null);
        public Task<string> InsertUserRole(UserInRole userInRole);
        public Task<string> DeleteUserRole(string id);

        public Task<List<UserMenuPermission>> GetMenuPermissionsInUser(string search = null);
        public Task<string> InsertUserMenuPermissions(UserMenuPermission menu, string user = null);
        public Task<string> DeleteUserMenuPermissions(string id);

        public Task<bool> IsUserHasRole(string UserName = null, string RoleName = null);
        public Task<bool> IsUserHasPermission(string UserName = null, string MenuName = null);

    }
}
