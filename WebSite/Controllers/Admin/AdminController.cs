using BusinessManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers.Admin
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View(MenuBO.GetInstance().GetAll());
        }

        public ActionResult FileDisplay(string url)
        {
            FileUIModel model = new FileUIModel();
            model.URL = url;

            return View(model);
        }
    }
}
