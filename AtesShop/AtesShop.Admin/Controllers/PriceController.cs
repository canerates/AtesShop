using AtesShop.Admin.Models;
using AtesShop.Admin.ViewModels;
using AtesShop.Entities;
using AtesShop.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Admin.Controllers
{
    public class PriceController : Controller
    {
        private ApplicationRoleManager _roleManager;

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
        public ActionResult PriceTable(string search)
        {
            List<PriceListViewModel> model = new List<PriceListViewModel>();
            var keySet = PriceService.Instance.GetPriceDistinctKeys();

            foreach (var key in keySet)
            {
                PriceListViewModel modelElement = new PriceListViewModel();
                modelElement.ProductName = ResourceKeyService.Instance.GetProductKeySetByPriceKey(key).Product.Name;
                modelElement.ProductDescription = ResourceKeyService.Instance.GetProductKeySetByPriceKey(key).Product.Description;
                modelElement.PriceCount = PriceService.Instance.GetPriceCountByKey(key);
                modelElement.Prices = PriceService.Instance.GetPricesByKey(key);
                
                model.Add(modelElement);
            }
            
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewPriceViewModel model = new NewPriceViewModel();
            model.AvailableProducts = ProductService.Instance.GetProducts();

            var roles = new List<RoleViewModel>();

            foreach (var role in RoleManager.Roles)
            {
                roles.Add(new RoleViewModel(role));
            }
            model.AvailableRoles = roles;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewPriceViewModel model)
        {
            var newPrice = new Price();

            var productKeySet = ResourceKeyService.Instance.GetProductKeySetByProduct(model.ProductId);
            newPrice.Key = productKeySet.PriceKey;

            foreach (var role in RoleManager.Roles)
            {
                if (role.Id == model.RoleId)
                {
                    newPrice.RoleName = role.Name;
                }
            }

            newPrice.RoleId = model.RoleId;

            newPrice.Culture = model.Culture;
            newPrice.Value = model.Value;
            newPrice.PreValue = model.PreValue;

            PriceService.Instance.SavePrice(newPrice);
            
            return RedirectToAction("PriceTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditPriceViewModel model = new EditPriceViewModel();
            var currentPrice = PriceService.Instance.GetPriceById(id);

            model.Id = currentPrice.Id;
            model.ProductName = ResourceKeyService.Instance.GetProductKeySetByPriceKey(currentPrice.Key).Product.Name;
            model.Culture = currentPrice.Culture;
            model.Value = currentPrice.Value;
            model.PreValue = currentPrice.PreValue;
            model.RoleName = currentPrice.RoleName;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditPriceViewModel model)
        {
            var currentPrice = PriceService.Instance.GetPriceById(model.Id);
            currentPrice.Value = model.Value;
            currentPrice.PreValue = model.PreValue;

            PriceService.Instance.UpdatePrice(currentPrice);

            return RedirectToAction("PriceTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PriceService.Instance.DeletePrice(id);

            return RedirectToAction("PriceTable");
        }
    }
}