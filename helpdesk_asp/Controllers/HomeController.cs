using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model = helpdesk_asp.Models;

namespace helpdesk_asp.Controllers
{
    [RoutePrefix("Home")]
    [Route("{action=index}")]
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        [Route]
        [Route("~/", Name = "default")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Auth")]
        public ActionResult Auth([Bind(Include = "username,password")] model.LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                }
                return View("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}