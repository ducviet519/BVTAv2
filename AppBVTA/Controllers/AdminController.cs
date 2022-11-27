using AppBVTA.Models;
using DataBVTA.Models;
using DataBVTA.Models.ViewModels;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _services;
        public AdminController(IUnitOfWork services)
        {
            _services = services;
        }
        public async Task<IActionResult> Permission()
        {
            PermissionViewModel model = new PermissionViewModel();
            model.ListUsers = await _services.Permission.GetUsers();
            model.ListRoles = await _services.Permission.GetRoles();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetRoles(string UserName)
        {
            var roles = (await _services.Permission.GetRoles()).ToList();
            List<Roles> data = new List<Roles>();
            foreach (var item in roles)
            {
                Roles role = new Roles();
                role.RoleID = item.RoleID;
                role.RoleName = item.RoleName;
                role.Description = item.Description;
                if (await _services.Permission.IsUserHasRole(UserName, item.RoleName))
                {
                    role.Checked = true;
                }
                else { role.Checked = false; }
                data.Add(role);
            }
            data = data.ToList();
            return Json(new { data });
        }

        [HttpPost]
        public async Task<JsonResult> InsertOrUpdateRole(Roles role)
        {
            string message = "";
            string title = "";
            string result = "";
            try
            {
                string user = User.Identity.Name;
                result = await _services.Permission.InsertRole(role, user);
                if (result == "OK")
                {
                    message = $"Thành công! Đã thêm mới role: {role.RoleName}";
                    title = "Thành công!";
                    result = "success";
                }
                else
                {
                    message = $"Lỗi! {result}";
                    title = "Lỗi!";
                    result = "error";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        [HttpGet]
        public async Task<JsonResult> DeleteRole(string roleID, string roleName)
        {
            string message = "";
            string title = "";
            string result = "";
            try
            {
                if (!String.IsNullOrEmpty(roleID) || roleName == "Admin" || roleName == "User" || roleName == "Manager")
                {
                    result = await _services.Permission.DeleteRole(roleID);
                    if (result == "OK")
                    {
                        message = $"Đã xóa thành công role: {roleName}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"{result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }
                else
                {
                    message = $"Lỗi! Không thể xóa Role mặc định";
                    title = "Lỗi!";
                    result = "error";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        [HttpPost]
        public async Task<JsonResult> AddAction(string actionName)
        {
            string message = "";
            string title = "";
            string result = "";
            try
            {
                ModuleAction action = new ModuleAction()
                {
                    ActionName = actionName,
                };
                string user = User.Identity.Name;
                if (!String.IsNullOrEmpty(action.ActionName))
                {
                    result = await _services.Permission.InsertAction(action, user);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã thêm thành công action: {action.ActionName}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        [HttpPost]
        public async Task<JsonResult> AddController(string controllerName)
        {

            string message = "";
            string title = "";
            string result = "";
            try
            {
                ModuleController controller = new ModuleController()
                {
                    ControllerName = controllerName,
                };
                string user = User.Identity.Name;
                if (!String.IsNullOrEmpty(controller.ControllerName))
                {
                    result = await _services.Permission.InsertController(controller, user);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã thêm thành công controller: {controller.ControllerName}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        [HttpGet]
        public async Task<JsonResult> GetController()
        {
            var data = (await _services.Permission.GetControllers()).ToList();
            return Json(new { data });
        }

        [HttpGet]
        public async Task<JsonResult> GetAction()
        {
            var data = (await _services.Permission.GetActions()).ToList();
            return Json(new { data });
        }

        [HttpPost]
        public async Task<JsonResult> AddMenu(NavigationMenu menu)
        {
            string message = "";
            string title = "";
            string result = "";
            try
            {
                string user = User.Identity.Name;
                if (!String.IsNullOrEmpty(menu.Name))
                {
                    result = await _services.Permission.InsertNavigationMenu(menu, user);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã thêm thành công controller: {menu.Name}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        [HttpGet]
        public async Task<JsonResult> GetMenu(string UserName)
        {
            var menus = (await _services.Permission.GetNavigationMenus()).ToList();
            List<NavigationMenu> data = new List<NavigationMenu>();
            foreach (var item in menus)
            {
                NavigationMenu menu = new NavigationMenu();
                menu.MenuID = item.MenuID;
                menu.Name = item.Name;
                menu.ControllerID = item.ControllerID;
                menu.ActionID = item.ActionID;
                if (await _services.Permission.IsUserHasPermission(UserName, item.Name))
                {
                    menu.Checked = true;
                }
                else { menu.Checked = false; }
                data.Add(menu);
            }
            data = data.ToList();
            return Json(new { data });
        }

        [HttpGet]
        public async Task<JsonResult> DeleteMenu(string menuID, string menuName)
        {
            string message = "";
            string title = "";
            string result = "";
            try
            {
                if (!String.IsNullOrEmpty(menuID))
                {
                    result = await _services.Permission.DeleteNavigationMenu(menuID);
                    if (result == "OK")
                    {
                        message = $"Đã xóa thành công role: {menuName}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"{result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        public async Task<IActionResult> AddRoleUser(string UserID)
        {
            PermissionViewModel model = new PermissionViewModel();
            var data = await _services.Permission.GetUsers();
            if (!String.IsNullOrEmpty(UserID))
            {
                data = data.Where(s => s.UserID != null && s.UserID.Contains(UserID)).ToList();
                model.User = data.FirstOrDefault();
            }
            return PartialView("_AddRoleUser", model);
        }

        [HttpPost]
        public async Task<JsonResult> AddRoleUser(UserInRole userInRole)
        {
            Int32.TryParse(Request.Form["count"], out int count);
            string message = "";
            string title = "";
            string result = "";
            try
            {
                await _services.Permission.DeleteUserRole(Request.Form["UserID"]);
                for (var i = 0; i <= count; i++)
                {
                    if (!String.IsNullOrEmpty(Request.Form["RoleName-" + i]))
                    {
                        UserInRole data = new UserInRole()
                        {
                            RoleID = Request.Form["RoleID-" + i],
                            RoleName = Request.Form["RoleName-" + i],
                            UserID = Request.Form["UserID"],
                            UserName = Request.Form["UserName"]
                        };
                        var test = data;
                        result = await _services.Permission.InsertUserRole(data);
                    }
                }
                if (result == "OK")
                {
                    message = $"Thành công! Đã thêm thành công";
                    title = "Thành công!";
                    result = "success";
                }
                else
                {
                    message = $"Lỗi! {result}";
                    title = "Lỗi!";
                    result = "error";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        public async Task<IActionResult> AddPermissionUser(string UserID)
        {
            PermissionViewModel model = new PermissionViewModel();
            var data = await _services.Permission.GetUsers();
            if (!String.IsNullOrEmpty(UserID))
            {
                data = data.Where(s => s.UserID != null && s.UserID.Contains(UserID)).ToList();
                model.User = data.FirstOrDefault();
            }
            return PartialView("_AddPermissionUser", model);
        }

        [HttpPost]
        public async Task<JsonResult> AddPermissionUser(UserMenuPermission menu)
        {
            Int32.TryParse(Request.Form["count"], out int count);
            string message = "";
            string title = "";
            string result = "";
            try
            {
                string user = User.Identity.Name;
                await _services.Permission.DeleteUserMenuPermissions(Request.Form["UserID"]);
                for (var i = 0; i <= count; i++)
                {
                    if (!String.IsNullOrEmpty(Request.Form["NavigationMenuName-" + i]))
                    {
                        UserMenuPermission data = new UserMenuPermission()
                        {
                            NavigationMenuID = Request.Form["NavigationMenuID-" + i],
                            NavigationMenuName = Request.Form["NavigationMenuName-" + i],
                            UserID = Request.Form["UserID"],
                            UserName = Request.Form["UserName"],
                        };
                        result = await _services.Permission.InsertUserMenuPermissions(data, user);
                    }
                }
                if (result == "OK")
                {
                    message = $"Thành công! Đã thêm thành công";
                    title = "Thành công!";
                    result = "success";
                }
                else
                {
                    message = $"Lỗi! {result}";
                    title = "Lỗi!";
                    result = "error";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }
    }
}
