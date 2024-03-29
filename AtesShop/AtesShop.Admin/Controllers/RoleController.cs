﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using AtesShop.Admin.Models;
using System.Threading.Tasks;

namespace AtesShop.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
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
        public ActionResult RoleTable()
        {
            List<RoleViewModel> model = new List<RoleViewModel>();

            foreach (var role in RoleManager.Roles)
            {
                model.Add(new RoleViewModel(role));
            }

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("RoleTable");
        } 

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return PartialView(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new ApplicationRole() { Id = model.Id, Name = model.Name };
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("RoleTable");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("RoleTable");
        }
        
    }
}