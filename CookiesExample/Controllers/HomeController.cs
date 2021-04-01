using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string NewGuid = System.Guid.NewGuid().ToString();
            string key = "CookiesExample";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.SameSite = SameSiteMode.Lax;
            Response.Cookies.Append(key, NewGuid, cookieOptions);

            return View();
        }
        public IActionResult CookiesPage()
        {
            string key = "CookiesExample";
            var cookieValue = Request.Cookies[key];
            if (!String.IsNullOrEmpty(cookieValue))
            {
                ViewBag.CookiesData = cookieValue;
            }
            return View();
        }
        public IActionResult CookiesClear()
        {
            string key = "CookiesExample";
            string value = "";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Path = "/";
            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            cookieOptions.SameSite = SameSiteMode.Lax;
            Response.Cookies.Append(key, value, cookieOptions);
            return RedirectToAction("Index", "Home");
        }
    }
}
