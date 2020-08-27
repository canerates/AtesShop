using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AtesShop.Web.Models;
using AtesShop.Web.ViewModels;
using AtesShop.Web.Code;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using AtesShop.Web.Helpers;
using static AtesShop.Web.Helpers.SharedHelper;
using System.Collections.Generic;
using AtesShop.Services;
using System.Web.Hosting;

namespace AtesShop.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private CustomEmailService emailService = new CustomEmailService();
        private HostingEnvironment _env;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationRoleManager roleManager, HostingEnvironment env)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
            _env = env;
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

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByNameAsync(model.EmailOrUserName) ?? await UserManager.FindByEmailAsync(model.EmailOrUserName);

            var username = user != null ? user.UserName : model.EmailOrUserName;

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(username, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", Resources.Resources.InvalidLoginAttempt);
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber, CompanyName = model.CompanyName, TaxNumber = model.TaxNumber, Subscription = model.Subscription };
                var result = await UserManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "User");
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    
                    var subject = "Confirm your Power Active email";
                    
                    var body = emailService.PopulateNewAccountMail(user.FirstName, user.LastName, user.UserName, user.Email, callbackUrl);

                    await UserManager.SendEmailAsync(user.Id, subject, body);

                    //Role request email
                    if (model.CompanyName != null)
                    {
                        var toAddress = ConfigurationManager.AppSettings["PAEditorEmail"];
                        //var fromAddress = model.Email.ToString();
                        var subject2 = "Role upgrade request";
                        var messageBody = new StringBuilder();
                        messageBody.Append("<p>Name: " + user.FirstName + " " + user.LastName +  "</p>");
                        messageBody.Append("<p>Email: " + user.Email + "</p>");
                        messageBody.Append("<p>Phone: " + user.PhoneNumber + "</p>");
                        messageBody.Append("<p>Role request: " + model.BusinessType + "</p>");
                        var message = messageBody.ToString();

                        await emailService.SendEmail(toAddress, subject2, message);
                    }
                    
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
                return View(model);
            }
            // If we got this far, something failed, redisplay form
            return RedirectToAction("Error", "Home");
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (await UserManager.IsEmailConfirmedAsync(userId))
            {
                return RedirectToAction("Error", "Generic", new { e = ErrorType.invalidcode });
            }
            
            var tokenExpired = false;
            var unprotectedData = UserManager.Protector.Unprotect(Convert.FromBase64String(code));
            var ms = new MemoryStream(unprotectedData);

            using (BinaryReader reader = new BinaryReader(ms))
            {
                var creationTime = new DateTimeOffset(reader.ReadInt64(), TimeSpan.Zero);
                var expirationTime = creationTime + UserManager.TokenLifeSpan;
                if (expirationTime < DateTimeOffset.UtcNow)
                {
                    tokenExpired = true;
                }
            }

            if (tokenExpired || userId == null || code == null)
            {
                return RedirectToAction("Error", "Generic", new { e = ErrorType.invalidcode });
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                return RedirectToAction("Success", "Generic", new { s = SuccessType.emailconfirmation });
            }

            return RedirectToAction("Error", "Generic", new { e = ErrorType.emailconfirmation });
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("Error", "Generic", new { e = ErrorType.invalidemail });
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                var subject = "Reset your Power Active Password";
                //var body = "<p> Hi " + user.FirstName + " " + user.LastName + ",</p><p> Please reset your password by clicking the link below. </p><p> <a href=\"" + callbackUrl + "\"> Yes, reset my password </a> </p>" ;
                var body = emailService.PopulateResetPasswordMail(user.FirstName, user.LastName, callbackUrl);
                
                await UserManager.SendEmailAsync(user.Id, subject, body);
                return RedirectToAction("Success", "Generic", new { s = SuccessType.passwordresetemailsent });
            }

            // If we got this far, something failed, redisplay form
            //return View(model); //CHECKAGAIN
            return RedirectToAction("Error", "Home");
        }
        
        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public async Task<ActionResult> ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Error", "Generic", new { e = ErrorType.invalidcode });
            }
            else
            {
                var tokenExpired = false;
                var unprotectedData = UserManager.Protector.Unprotect(Convert.FromBase64String(code));
                var ms = new MemoryStream(unprotectedData);

                using (BinaryReader reader = new BinaryReader(ms))
                {
                    var creationTime = new DateTimeOffset(reader.ReadInt64(), TimeSpan.Zero);
                    var expirationTime = creationTime + UserManager.TokenLifeSpan;
                    if (expirationTime < DateTimeOffset.UtcNow)
                    {
                        tokenExpired = true;
                    }
                }

                if (tokenExpired)
                {
                    return RedirectToAction("Error", "Generic", new { e = ErrorType.invalidcode });
                }

                var result = await UserManager.VerifyUserTokenAsync(userId, "ResetPassword", code);
                if (!result)
                {
                    return RedirectToAction("Error", "Generic", new { e = ErrorType.invalidcode });
                }
            }
            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("Error", "Generic", new { e = ErrorType.invalidemail });
            }
            
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Success", "Generic", new { s = SuccessType.passwordreset });
            }
            return RedirectToAction("Error", "Home");
        }
        
        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        //
        // GET: /Account/Subscribe
        [AllowAnonymous]
        public ActionResult Subscribe()
        {
            return PartialView();
        }

        //
        // POST: /Account/Subscribe
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Subscribe(SubscriptionViewModel model)
        {
            
            return new EmptyResult();
            
        }

        [HttpGet]
        [NoDirectAccess]
        [CustomAuthorizeAttribute]
        public ActionResult Legal()
        {
            return View();
        }

        public ActionResult LegalTable(string search)
        {
            List<ResourceKeyViewModel> model = new List<ResourceKeyViewModel>();
            var resourceKeys = ResourceService.Instance.GetResourceDistinctKeys();

            foreach (var key in resourceKeys)
            {
                ResourceKeyViewModel elem = new ResourceKeyViewModel();
                elem.ResourceKey = key;
                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(key);

                var resources = ResourceService.Instance.GetResourcesByKey(key);

                elem.Resources = resources;

                if (!string.IsNullOrEmpty(search))
                {
                    resources = resources.Where(r => r.Value != null && r.Value.ToLower().Contains(search.ToLower())).ToList();
                }

                if (resources.Count != 0)
                {
                    model.Add(elem);
                }
            }

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult LegalEdit(int id)
        {
            ResourceViewModel model = new ResourceViewModel();
            var currentResource = ResourceService.Instance.GetResourceById(id);

            model.Id = id;
            model.Key = currentResource.Key;
            model.Culture = currentResource.Culture;
            model.Value = currentResource.Value;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult LegalEdit(ResourceViewModel model)
        {
            var currentResource = ResourceService.Instance.GetResourceById(model.Id);
            currentResource.Value = model.Value;

            ResourceService.Instance.UpdateResource(currentResource);

            return RedirectToAction("LegalTable");
        }

        [HttpGet]
        [NoDirectAccess]
        [CustomAuthorizeAttribute]
        public ActionResult Role()
        {
            return View();
        }

        public ActionResult RoleTable(string search)
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
        public ActionResult RoleEdit(string userName)
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
        public ActionResult RoleEdit(EditUserViewModel model)
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

            return RedirectToAction("RoleTable");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                    _roleManager = null;
                }
            }

            base.Dispose(disposing);
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

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}