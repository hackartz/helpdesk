using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model = helpdesk_asp.Models;
using DapperLib;
using Newtonsoft.Json;
using System.Web.Security;
using helpdesk_asp.Utility;

namespace helpdesk_asp.Controllers
{
    [RoutePrefix("Home")]
    [Route("{action=index}")]
    public class HomeController : Controller
    {
        private SQLConn db = new SQLConn(System.Configuration.ConfigurationManager.AppSettings["strCnn"].ToString());

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
                    string sql = "select count(userid) from PharSec_user where"
                        + " username=@username and password=@password";
                    object retVal = this.db.executeScalarSQL(sql, new { login.username, password = Helper.Encrypt(login.password) });
                    
                    if((int)retVal > 0)
                    {
                        var value = this.db.QuerySQLtoIEnumerable<model.UserModel>("").FirstOrDefault();
                        string data = string.Empty;
                        data = JsonConvert.SerializeObject(value);

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                            String.Format("{0}", value.username),
                            DateTime.Now,
                            DateTime.Now.AddMinutes(30),
                            false, data,
                            FormsAuthentication.FormsCookiePath);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(authTicket));

                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        ModelState.AddModelError("", "login failed ");
                    }
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