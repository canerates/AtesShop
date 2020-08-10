using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AtesShop.Web.Models;
using AtesShop.Services;
using AtesShop.Entities;
using System.Collections.Generic;
using AtesShop.Web.Code;
using AtesShop.Web.Helpers;
using System.Configuration;
using System.Text;

namespace AtesShop.Web.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private CustomEmailService emailService = new CustomEmailService();

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
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

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message, ActiveTab? activeTab)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";


            if (activeTab.HasValue)
            {
                ViewBag.ActiveTab = activeTab;
            }
            else
            {
                ViewBag.ActiveTab = ActiveTab.Dashboard;
            }
            
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId),
                FullName = user.FirstName + " " + user.LastName,
                
            };
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Failed to verify phone");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Orders()
        {
            OrdersViewModel model = new OrdersViewModel();
            var orders = OrderService.Instance.GetOrders();

            foreach (var order in orders)
            {
                OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), order.Status);
                order.Status = status.GetDisplayDescription();
            }


            model.Orders = orders;

            return PartialView(model);
        }
        
        [HttpGet]
        public ActionResult Downloads()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Downloads(DownloadsViewModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Address()
        {
            AddressViewModel model = new AddressViewModel();

            var userId = User.Identity.GetUserId();
            model.AddressList = UserService.Instance.GetUserAddressList(userId);

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Address(AddressViewModel model)
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult AddAddress()
        {
            AddressFieldViewModel model = new AddressFieldViewModel();

            List<string> countries = new List<string>();

            countries.Add(Resources.Resources.Taiwan);
            countries.Add(Resources.Resources.Vietnam);
            countries.Add(Resources.Resources.Turkey);
            countries.Add(Resources.Resources.USA);

            model.CountryList = countries;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddAddress(AddressFieldViewModel model)
        {

            if (ModelState.IsValid)
            {
                var newAddress = new UserAddress();
                newAddress.Country = model.Country;
                newAddress.FirstName = model.FirstName;
                newAddress.LastName = model.LastName;
                newAddress.CompanyName = model.CompanyName;
                newAddress.Line1 = model.Line1;
                newAddress.Line2 = model.Line2;
                newAddress.City = model.City;
                newAddress.State = model.State;
                newAddress.ZipCode = model.ZipCode;
                newAddress.Email = model.Email;
                newAddress.Phone = model.PhoneNumber;
                newAddress.UserId = User.Identity.GetUserId();

                UserService.Instance.SaveUserAddress(newAddress);
            }
            
            return RedirectToAction("Address");
        }

        [HttpGet]
        public ActionResult EditAddress(int addressId)
        {
            var address = UserService.Instance.GetUserAddress(addressId);

            AddressFieldViewModel model = new AddressFieldViewModel();
            model.Id = address.Id;
            model.FirstName = address.FirstName;
            model.LastName = address.LastName;
            model.CompanyName = address.CompanyName;
            model.Line1 = address.Line1;
            model.Line2 = address.Line2;
            model.City = address.City;
            model.State = address.State;
            model.Country = address.Country;
            model.ZipCode = address.ZipCode;
            model.Email = address.Email;
            model.PhoneNumber = address.Phone;

            List<string> countries = new List<string>();

            countries.Add(Resources.Resources.Taiwan);
            countries.Add(Resources.Resources.Vietnam);
            countries.Add(Resources.Resources.Turkey);
            countries.Add(Resources.Resources.USA);

            model.CountryList = countries;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditAddress(AddressFieldViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Submit == "Back")
                {
                    return RedirectToAction("Address");
                }

                var currentAddress = UserService.Instance.GetUserAddress(model.Id);

                currentAddress.FirstName = model.FirstName;
                currentAddress.LastName = model.LastName;
                currentAddress.CompanyName = model.CompanyName;
                currentAddress.Line1 = model.Line1;
                currentAddress.Line2 = model.Line2;
                currentAddress.City = model.City;
                currentAddress.State = model.State;
                currentAddress.ZipCode = model.ZipCode;
                currentAddress.Email = model.Email;
                currentAddress.Phone = model.PhoneNumber;

                UserService.Instance.UpdateUserAddress(currentAddress);
            }
            
            return RedirectToAction("Address");
        }

        [HttpPost]
        public ActionResult DeleteAddress(int addressId)
        {
            UserService.Instance.DeleteUserAddress(addressId);

            return RedirectToAction("Address");
        }
        
        [HttpGet]
        public ActionResult AccountDetails()
        {
            return PartialView();
        }


        [HttpGet]
        public ActionResult Details()
        {
            DetailsViewModel model = new DetailsViewModel();

            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            var role = UserManager.GetRoles(userId).FirstOrDefault();

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Gender = user.Gender;
            model.PhoneNumber = user.PhoneNumber;
            model.isSubscribed = user.Subscription;
            model.BusinessType = role;
            model.CompanyName = user.CompanyName;
            model.TaxNumber = user.TaxNumber;
            
            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> Details(DetailsViewModel model)
        {
            if (!model.UpdatePassword)
            {
                ModelState["OldPassword"].Errors.Clear();
                ModelState["NewPassword"].Errors.Clear();
                ModelState["ConfirmPassword"].Errors.Clear();
            }

            if (!model.UpdateRole && model.BusinessType == "User")
            {
                ModelState["CompanyName"].Errors.Clear();
                ModelState["TaxNumber"].Errors.Clear();
            }
            if (model.BusinessType != "User")
            {
                ModelState["NewBusinessType"].Errors.Clear();
            }

            if (!ModelState.IsValid)
            {
                return PartialView("Details", model);
            }


            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Gender = model.Gender;
                user.PhoneNumber = model.PhoneNumber;
                user.Subscription = model.isSubscribed;

                if (model.UpdateRole)
                {
                    var toAddress = ConfigurationManager.AppSettings["PAEditorEmail"];
                    var fromAddress = model.Email.ToString();
                    var subject2 = "Role upgrade request";
                    var messageBody = new StringBuilder();
                    messageBody.Append("<p>Name: " + user.FirstName + " " + user.LastName + "</p>");
                    messageBody.Append("<p>Email: " + user.Email + "</p>");
                    messageBody.Append("<p>Phone: " + user.PhoneNumber + "</p>");
                    messageBody.Append("<p>Role request: " + model.NewBusinessType + "</p>");
                    var message = messageBody.ToString();

                    await emailService.SendEmail(toAddress, fromAddress, subject2, message);
                    

                    TempData["RoleRequest"] = Resources.Resources.RoleRequestMailSent;
                }

                if (model.CompanyName != null && model.TaxNumber != null)
                {
                    user.CompanyName = model.CompanyName;
                    user.TaxNumber = model.TaxNumber;
                }

                var result1 = await UserManager.UpdateAsync(user);

                if (!result1.Succeeded)
                {
                    AddErrors(result1);
                }
                
                if (model.UpdatePassword && model.OldPassword != null && model.NewPassword != null && model.ConfirmPassword != null)
                {
                    var result2 = await UserManager.ChangePasswordAsync(user.Id, model.OldPassword, model.NewPassword);

                    if (result2.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        TempData["PasswordChangedSuccess"] = Resources.Resources.PasswordChangedSuccess;
                        return PartialView("Details", model);
                    }
                    AddErrors(result2);
                }
            }
            return PartialView("Details", model);
            
        }



#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        public enum ActiveTab
        {
            Dashboard,
            Orders,
            Downloads,
            Addresses,
            Details
        }

#endregion
    }
}