using BusinessManager.Business;
using BusinessManager.Models;
using WebSite.Models;
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

        public ActionResult Index(int id=0)
        {
            return View(ActivityBO.GetInstance().GetAll(id));
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

        public ActionResult Delete(int id)
        {
            ActivityBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TaskChildrenField(int id)
        {
            int count = ActivityBO.GetInstance().GetTaskCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = "Task"
            };

            return View("ChildrenField", model);
        }
    }
}
