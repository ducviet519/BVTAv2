using Dapper;
using DataBVTA.Models;
using DataBVTA.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        #region Connection Database

        private readonly IConfiguration _configuration;
        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            provideName = "System.Data.SqlClient";
        }
        public string ConnectionString { get; }
        public string provideName { get; }
        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        #endregion

        #region Delete Item

        public async Task<string> DeleteNavigationMenu(string id)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync("sp_Auth_NavigationMenu", new { Action = "Delete", MenuID = id }, commandType: CommandType.StoredProcedure);
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> DeleteRole(string id)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync("sp_Auth_Roles", new { RoleID = id, Action = "Delete" }, commandType: CommandType.StoredProcedure);
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> DeleteUserRole(string id) 
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync("sp_Auth_Users", new { UserID = id, Action = "DeleteRoleUse" }, commandType: CommandType.StoredProcedure);
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> DeleteUserMenuPermissions(string id)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync("sp_Auth_NavigationMenu", new { UserID = id, Action = "DeleteUserMenuPermission" }, commandType: CommandType.StoredProcedure);
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }
        #endregion

        #region Get List Item
        public async Task<List<ModuleAction>> GetActions()
        {
            List<ModuleAction> data = new List<ModuleAction>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<ModuleAction>("sp_Auth_ModuleActions", new { Action = "GetAll" }, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<ModuleController>> GetControllers()
        {
            List<ModuleController> data = new List<ModuleController>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<ModuleController>("sp_Auth_ModuleControllers", new { Action = "GetAll" }, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<NavigationMenu>> GetNavigationMenus()
        {
            List<NavigationMenu> data = new List<NavigationMenu>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<NavigationMenu>("sp_Auth_NavigationMenu", new { Action = "GetAll"}, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<Roles>> GetRoles()
        {
            List<Roles> data = new List<Roles>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<Roles>("sp_Auth_Roles", new { Action = "GetAll" }, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<UserInRole>> GetRoleInUser(string search = null)
        {
            List<UserInRole> data = new List<UserInRole>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<UserInRole>("sp_Auth_Users",
                        new
                        {
                            Search = search,
                            Action = "GetRoleInUse",
                        },
                        commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<UserMenuPermission>> GetMenuPermissionsInUser(string search = null)
        {
            List<UserMenuPermission> data = new List<UserMenuPermission>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<UserMenuPermission>("sp_Auth_NavigationMenu",
                        new
                        {
                            Search = search,
                            Action = "GetMenuPermissionInUser"
                        },
                        commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<Users>> GetUsers()
        {
            List<Users> data = new List<Users>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<Users>("sp_Auth_Users", new { Action = "GetAll" }, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<Users> GetUsersByNameOrID(string search)
        {
            Users data = new Users();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryFirstOrDefaultAsync<Users>("sp_Auth_Users", new { Action = "GetByNameOrID", Search = search }, commandType: CommandType.StoredProcedure));
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }
        #endregion

        #region Add Item
        public async Task<string> InsertAction(ModuleAction action, string user = null)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.QueryAsync<ModuleAction>("sp_Auth_ModuleActions"
                        , new
                        {
                            ActionName = action.ActionName,
                            User = user,
                            Action = "Add"

                        }
                        , commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> InsertController(ModuleController controller, string user = null)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.QueryAsync<ModuleAction>("sp_Auth_ModuleControllers"
                        , new
                        {
                            ControllerName = controller.ControllerName,
                            User = user,
                            Action = "Add"

                        }
                        , commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> InsertNavigationMenu(NavigationMenu menu, string user = null)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.QueryAsync<NavigationMenu>("sp_Auth_NavigationMenu"
                        , new
                        {
                            MenuName = menu.Name,
                            Area = menu.Area,
                            ControllerID = menu.ControllerID,
                            ActionID = menu.ActionID,
                            Visiable = menu.Visible,
                            User = user,
                            Action = "Add"

                        }
                        , commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> InsertRole(Roles role, string user = null)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.QueryAsync<Roles>("sp_Auth_Roles"
                        , new
                        {
                            Action = "Add",
                            RoleName = role.RoleName,
                            Description = role.Description,
                            Status = role.Status,
                            User = user

                        }
                        , commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> InsertUsers(Users users)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var data = await dbConnection.QueryAsync<Users>("sp_Auth_Users",
                        new
                        {
                            DisplayName = users.DisplayName,
                            UserName = users.UserName,
                            Password = users.Password,
                            Source = users.Source,
                            Email = users.Email,
                            Status = users.Status,
                            Action = "Add"
                        },
                        commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> InsertUserMenuPermissions(UserMenuPermission menu, string user = null)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var data = await dbConnection.QueryAsync<UserMenuPermission>("sp_Auth_NavigationMenu",
                        new
                        {
                            UserID = menu.UserID,
                            UserName = menu.UserName,
                            RoleID = menu.RoleID,
                            RoleName = menu.RoleName,
                            MenuID = menu.NavigationMenuID,
                            MenuName = menu.NavigationMenuName,
                            User = user,
                            Action = "AddUserMenuPermission"
                        },
                        commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> InsertUserRole(UserInRole userInRole)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var data = await dbConnection.QueryAsync<UserInRole>("sp_Auth_Users",
                        new
                        {
                            UserID = userInRole.UserID,
                            UserName = userInRole.UserName,
                            RoleID   = userInRole.RoleID,
                            RoleName = userInRole.RoleName,
                            Action = "InsertRoleUse"
                        },
                        commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }
        #endregion

        #region Check Exist
        public async Task<bool> IsUserHasPermission(string UserName = null, string MenuName = null)
        {
            List<UserMenuPermission> data = new List<UserMenuPermission>();
            string query = "SELECT CAST(UserID AS varchar(60)) AS UserID, UserName, CAST(NavigationMenuID AS varchar(60)) AS NavigationMenuID, NavigationMenuName FROM DBO.RoleMenuPermission WHERE UserName = @UserName AND NavigationMenuName = @MenuName";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<UserMenuPermission>(query, new { UserName = UserName, MenuName = MenuName })).ToList();
                    dbConnection.Close();
                }
                if (data.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return false;
            }
        }

        public async Task<bool> IsUserHasRole(string UserName = null, string RoleName = null)
        {
            List<UserInRole> data = new List<UserInRole>();
            string query = "SELECT CAST(UserID AS varchar(60)) AS UserID, UserName, CAST(RoleID AS varchar(60)) AS RoleID, RoleName FROM DBO.UserRoles WHERE UserName = @UserName AND RoleName = @RoleName";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<UserInRole>(query, new { UserName = UserName, RoleName = RoleName })).ToList();
                    dbConnection.Close();
                }
                if(data.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
