using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace isucorp.testApp.Controllers
{
    using System.Globalization;
    using System.Threading;

    public class LanguageController : Controller
    {
        // GET: Languaje

        public ActionResult ChangeLanguage(string language)
        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            var cookie = new HttpCookie("language") { Value = language };
            this.Response.Cookies.Add(cookie);

            var urlReferrer = this.Request.UrlReferrer;
            if (urlReferrer != null)
            {
                return this.Redirect(urlReferrer.ToString());
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}