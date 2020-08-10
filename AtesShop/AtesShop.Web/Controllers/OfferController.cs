using AtesShop.Entities;
using AtesShop.Resources;
using AtesShop.Services;
using AtesShop.Web.Helpers;
using AtesShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Web.Controllers
{
    public class OfferController : BaseController
    {

        private static IResourceProvider resourceProvider = new DbResourceProvider();
        // GET: Offer
        public ActionResult Index()
        {
            var productsAll = ProductService.Instance.GetProductSets(CultureInfo.CurrentUICulture.Name, "User");
            productsAll = CommonHelper.FormatCurrency(productsAll, CultureInfo.CurrentUICulture.Name);

            var products = productsAll.Where(x => !x.isHidden).ToList();
            var productsExra = productsAll.Where(x => x.isHidden).ToList();

            List<ProductSetsViewModel> model = new List<ProductSetsViewModel>();

            foreach (var extra in productsExra)
            {
                ProductSetsViewModel element = new ProductSetsViewModel();
                var setItems = ProductService.Instance.GetProductSetItems(extra.Id);
                foreach (var product in products)
                {
                    var result = setItems.Where(x => x.ItemProductID == product.Id).FirstOrDefault();
                    if (result != null)
                    {
                        element.Product = product;
                        element.ProductExtra = extra;
                        model.Add(element);
                    }
                    
                }
            }
            
            return View(model);
        }

        public ActionResult  PackageProducts(int productId, string incItems)
        {
            OfferPackageViewModel model = new OfferPackageViewModel();

            List<ProductSetItemViewModel> packageItems = new List<ProductSetItemViewModel>();
            List<OptionalSetItemViewModel> extraItems = new List<OptionalSetItemViewModel>();

            List<string> includedItems = new List<string>();

            if (incItems != null)
            {
                includedItems = incItems.Split('-').ToList();
            }
            
            var setItems = ProductService.Instance.GetProductSetItems(productId);

            foreach (var item in setItems)
            {
                ProductSetItemViewModel packageItem = new ProductSetItemViewModel();
                packageItem.ProductSetItem = item;
                var itemPro = ProductService.Instance.GetProductForSet(item.ItemProductID);
                if (itemPro != null)
                {
                    packageItem.ImageId = itemPro.Images.FirstOrDefault().Id;
                    packageItem.ProductSetItem.ItemProductName = resourceProvider.GetResource(item.ItemProductName, CultureInfo.CurrentUICulture.Name).ToString();
                    packageItem.ProductSetItem.ItemProductDescription = resourceProvider.GetResource(item.ItemProductDescription, CultureInfo.CurrentUICulture.Name).ToString();
                    packageItem.isVisible = !itemPro.isHidden;
                    packageItems.Add(packageItem);
                }
            }

            model.PackageItems = packageItems;

            var optionalSetItems = ProductService.Instance.GetOptionalProductSetItems(productId);

            var extraItemTotalPrice = 0;

            foreach (var item in optionalSetItems)
            {
                OptionalSetItemViewModel extraItem = new OptionalSetItemViewModel();
                var optionalProduct = ProductService.Instance.GetProductForSet(item.ItemProductID);
                var price = PriceService.Instance.GetPriceForUserByKeyAndCulture("ProductPrice" + optionalProduct.Id, CultureInfo.CurrentUICulture.Name);
                
                if (includedItems.Contains(item.ItemProductID.ToString()))
                {
                    extraItem.isIncluded = true;
                    extraItemTotalPrice = extraItemTotalPrice + Int32.Parse(price.Value);
                }
                else
                {
                    extraItem.isIncluded = false;
                }

                extraItem.Id = optionalProduct.Id;
                extraItem.ProductSetId = productId;
                extraItem.Name = resourceProvider.GetResource(item.ItemProductName, CultureInfo.CurrentUICulture.Name).ToString();
                extraItem.Description = resourceProvider.GetResource(item.ItemProductDescription, CultureInfo.CurrentUICulture.Name).ToString();
                extraItem.Price = CommonHelper.FormatCurrency(price.Value, CultureInfo.CurrentUICulture.Name);
                extraItems.Add(extraItem);
            }

            model.Extras = extraItems;

            var setProduct = ProductService.Instance.GetProductSet(productId, CultureInfo.CurrentUICulture.Name, "User");
            var total = Int32.Parse(setProduct.Price) + extraItemTotalPrice;

            model.SubTotal = CommonHelper.FormatCurrency(setProduct, CultureInfo.CurrentUICulture.Name).Price;
            model.Total = CommonHelper.FormatCurrency(total.ToString(), CultureInfo.CurrentUICulture.Name);

            model.IncItems = incItems == null ? String.Empty : incItems;
            model.SetId = productId;
            
            return PartialView(model);
        }

    }
}