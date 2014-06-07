using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers.Admin
{
    public class ManageActivityController : Controller
    {
        //
        // GET: /ManageActivity/

        public ActionResult Index()
        {
            return View(ActivityBO.GetInstance().GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(ActivityBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ActivityDataModel activity)
        {
            ActivityBO.GetInstance().Update(activity);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ActivityDataModel activity)
        {
            ActivityBO.GetInstance().Create(activity);

            return RedirectToAction("Index");
        }
    }
}
