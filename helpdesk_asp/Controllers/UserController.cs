using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model = helpdesk_asp.Models;
using DapperLib;

namespace helpdesk_asp.Controllers
{
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        //TODO: 3 form order (computer,software, dan telp)

        private SQLConn db = new SQLConn(System.Configuration.ConfigurationManager.AppSettings["strCnn"].ToString());
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [Route("tes")]
        public ActionResult Tes()
        {
            var result = this.db.QuerySPtoIEnumerable<model.KonsulBagian>("Sp_GetKonsulBagian");
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}