using AtesShop.Entities;
using AtesShop.Resources;
using AtesShop.Services;
using AtesShop.Web.Code;
using AtesShop.Web.Helpers;
using AtesShop.Web.ViewModels;
using Ionic.Zip;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static AtesShop.Web.Helpers.SharedHelper;

namespace AtesShop.Web.Controllers
{
    public class GenericController : BaseController
    {
        private static IResourceProvider resourceProvider = new DbResourceProvider();

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Authorize]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Wishlist()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult WishlistProducts()
        {
            WishlistViewModel model = new WishlistViewModel();
            List<Product> products = new List<Product>();

            var userId = User.Identity.GetUserId();

            var wishlist = UserService.Instance.GetAllWishlistForUser(userId).ToList();

            foreach (var wish in wishlist)
            {
                products.Add(ProductService.Instance.GetProduct(wish.ProductId, CultureInfo.CurrentUICulture.Name, "User"));
            }
            model.WishlistProducts = CommonHelper.FormatCurrency(products, CultureInfo.CurrentUICulture.Name);

            model.isPriceHidden = false;

            return PartialView(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult WishlistSideBar()
        {
            WishlistViewModel model = new WishlistViewModel();
            List<Product> products = new List<Product>();

            var userId = User.Identity.GetUserId();

            var wishlist = UserService.Instance.GetAllWishlistForUser(userId).ToList();

            foreach (var wish in wishlist)
            {
                products.Add(ProductService.Instance.GetProduct(wish.ProductId, CultureInfo.CurrentUICulture.Name, "User"));
            }
            model.WishlistProducts = CommonHelper.FormatCurrency(products, CultureInfo.CurrentUICulture.Name);

            model.isPriceHidden = true;

            return PartialView(model);
        }

        [Authorize]
        public void AddToWishlist(int productId)
        {
            var userId = User.Identity.GetUserId();
            var current = UserService.Instance.GetWishlist(userId, productId);

            if (current == null)
            {
                var newWish = new Wishlist();
                newWish.Product = ProductService.Instance.GetProduct(productId);
                newWish.UserId = Guid.Parse(userId);

                UserService.Instance.SaveWishlist(newWish);
            }
            
        }

        [Authorize]
        public void RemoveFromWishlist(int productId)
        {
            var userId = User.Identity.GetUserId();
            UserService.Instance.DeleteWishlist(userId, productId);
        }

        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        public ActionResult Compare()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CompareProducts()
        {
            CompareViewModel model = new CompareViewModel();

            var CompareProductsCookie = Request.Cookies["CompareProducts"];

            if (CompareProductsCookie != null && CompareProductsCookie.Value != "")
            {
                
                var idList = CompareProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                idList.RemoveAt(0);
                var products = ProductService.Instance.GetProductsByIdList(idList, CultureInfo.CurrentUICulture.Name, "User");
                products = CommonHelper.FormatCurrency(products, CultureInfo.CurrentUICulture.Name);

                var distinctSections = AttributeService.Instance.GetDistinctSectionsForProIdList(idList);

                var distinctAttrbuteTypes = AttributeService.Instance.GetDistinctAttrTypesForProIdList(idList);

                List<ProSecViewModel> productSpecs = new List<ProSecViewModel>();

                foreach (var sect in distinctSections)
                {
                    var prosec = new ProSecViewModel();
                    prosec.Section = AttributeService.Instance.GetAttributeSection(sect);
                    prosec.Section.Name = resourceProvider.GetResource("ASection" + prosec.Section.AttributeSectionId, CultureInfo.CurrentUICulture.Name) as string;
                    
                    var productAttrs = AttributeService.Instance.GetDistinctAttrTypesForProIdList(idList, sect);
                    var listOfAttributes = new List<Dictionary<int, ProductAttribute>>();

                    foreach (var attrT in productAttrs)
                    {
                        var dictAttr = new Dictionary<int, ProductAttribute>();
                        for (int i = 0; i < products.Count; i++)
                        {
                            var attr = AttributeService.Instance.GetProductAttribute(products[i].Id, attrT);
                            if (attr.AttributeTypeId != 0)
                            {
                                attr.AttributeType.Name = resourceProvider.GetResource("AType" + attr.AttributeTypeId, CultureInfo.CurrentUICulture.Name) as string;
                                attr.AttributeValue.Name = resourceProvider.GetResource("AValue" + attr.AttributeValueId, CultureInfo.CurrentUICulture.Name) as string;
                            }
                            
                            dictAttr.Add(i, attr);
                        }
                        listOfAttributes.Add(dictAttr);
                    }
                    prosec.AttributesOfProducts = listOfAttributes;

                    productSpecs.Add(prosec);
                }

                model.ProductSpecs = productSpecs;

                if (Request.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    model.CompareProducts = CommonHelper.WishlistCheck(products, userId);
                }
                else
                {
                    model.CompareProducts = products;
                }
                
                model.isPriceHidden = false;
            }

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult CompareSideBar()
        {
            CompareSideBarViewModel model = new CompareSideBarViewModel();

            var CompareProductsCookie = Request.Cookies["CompareProducts"];

            if (CompareProductsCookie != null && CompareProductsCookie.Value != "")
            {
                
                var idList = CompareProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                idList.RemoveAt(0);
                var products = ProductService.Instance.GetProductsByIdList(idList, CultureInfo.CurrentUICulture.Name, "User");

                model.CompareProducts = CommonHelper.FormatCurrency(products, CultureInfo.CurrentUICulture.Name);
                model.isPriceHidden = true;
            }
            

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Download()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DocumentList()
        {
            DocumentViewModel model = new DocumentViewModel();
            var documents = FileService.Instance.GetFiles();

            model.documents = documents;

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult ToolList()
        {

            return PartialView();
        }

        [NoDirectAccess]
        [HttpGet]
        public ActionResult Pdf(int id)
        {
            var pdf = FileService.Instance.GetFile(id);
            return File(pdf.Data, pdf.ContentType);
        }

        [NoDirectAccess]
        [HttpGet]
        public ActionResult Zip(int id)
        {
            object filename = "";

            switch (id)
            {
                case 1:
                    filename = "IMS300_V1.03.005.T.2019-06-20-20200131T011734Z-001.zip";
                    break;
                case 2:
                    filename = "MediaPlayer_ChnEng_ZD_V1.4.2.22.R.20190417_CHN.zip";
                    break;
                case 3:
                    filename = "TAMobile.V.2.12.5.1912040.apk.zip";
                    break;
                default:
                    break;
            }
            

            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/" + filename.ToString()));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename.ToString());
            
        }

        [HttpGet]
        public ActionResult Image(int id)
        {
            var image = ImageService.Instance.GetImgFile(id);
            return File(image.Data, image.ContentType);
        }

        [HttpGet]
        public ActionResult Error(ErrorType? e)
        {
            InfoViewModel model = new InfoViewModel();
            if (e.HasValue)
            {
                switch (e.Value)
                {
                    case ErrorType.invalidemail:
                        model.Title = Resources.Resources.InvalidEmail;
                        model.Message = Resources.Resources.InvalidEmailInfo;
                        break;
                    case ErrorType.invalidcode:
                        model.Title = Resources.Resources.InvalidCode;
                        model.Message = Resources.Resources.InvalidCodeInfo;
                        break;
                    case ErrorType.emailconfirmation:
                        model.Title = Resources.Resources.ConfirmationError;
                        model.Message = Resources.Resources.ConfirmationErrorInfo;
                        break;
                    default:
                        model.Title = "";
                        model.Message = "";
                        break;
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Success(SuccessType s)
        {
            InfoViewModel model = new InfoViewModel();

            switch (s)
            {
                case SuccessType.emailconfirmation:
                    model.Title = Resources.Resources.EmailConfirmed;
                    model.Message = Resources.Resources.EmailConfirmationInfo;
                    break;
                case SuccessType.passwordreset:
                    model.Title = Resources.Resources.SignWithNewPassword;
                    model.Message = Resources.Resources.PasswordChangedInfo;
                    break;
                case SuccessType.passwordresetemailsent:
                    model.Title = Resources.Resources.CheckYourEmail;
                    model.Message = Resources.Resources.EmailSentDescription;
                    break;
                default:
                    model.Title = "";
                    model.Message = "";
                    break;
            }
            
            return View(model);
        }
        
    }
}