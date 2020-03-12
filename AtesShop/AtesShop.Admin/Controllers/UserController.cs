using AtesShop.Admin.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserTable()
        {
            List<UserViewModel> model = new List<UserViewModel>();

            foreach (var user in UserManager.Users)
            {
                UserViewModel elem = new UserViewModel();
                elem.Id = user.Id;
                elem.UserName = user.UserName;
                elem.FirstName = user.FirstName;
                elem.LastName = user.LastName;
                elem.Email = user.Email;
                model.Add(elem);
            }

            foreach (var user in model)
            {
                user.RoleNames = UserManager.GetRoles(user.Id).ToList();
            }

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string userName)
        {
            EditUserViewModel model = new EditUserViewModel();

            var user = UserManager.FindByName(userName);

            model.UserName = user.UserName;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.SelectedRoles = UserManager.GetRoles(user.Id).ToList();

            var availableRoles = RoleManager.Roles.ToList();

            List<string> roles = new List<string>();
            foreach (var role in availableRoles)
            {
                roles.Add(role.Name);
            }

            model.AvailableRoles = roles;
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            var user = UserManager.FindByName(model.UserName);
            
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;


            var oldRoles = UserManager.GetRoles(user.Id).ToList();

            foreach (var role in oldRoles)
            {
                UserManager.RemoveFromRole(user.Id, role);
            }

            foreach (var selected in model.SelectedRoles)
            {
                UserManager.AddToRole(user.Id, selected);
            }

            UserManager.Update(user);

            return RedirectToAction("UserTable");
        }

        [HttpGet]
        public ActionResult Delete(string userName)
        {
            

            return View();
        }
    }
}