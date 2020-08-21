using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Web.Controllers
{
    public class AgreementsController : BaseController
    {
        // GET: Agreements
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PrivacyPolicy()
        {

            return View();
        }
    }
}