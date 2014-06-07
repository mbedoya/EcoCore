using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers.Admin
{
    public class ManageMenuController : Controller
    {
        //
        // GET: /ManageMenu/

        public ActionResult Index()
        {
            return View(MenuBO.GetInstance().GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(MenuBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(MenuDataModel menu)
        {
            MenuBO.GetInstance().Update(menu);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(MenuDataModel menu)
        {
            MenuBO.GetInstance().Create(menu);

            return RedirectToAction("Index");
        }
    }
}
