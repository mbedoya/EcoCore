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
    public class ManageTaskController : Controller
    {
        //
        // GET: /ManageTask/

        public ActionResult Index(int id=0)
        {
            return View(TaskBO.GetInstance().GetAll(id));
        }

        public ActionResult Edit(int id)
        {
            return View(TaskBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(TaskDataModel task)
        {
            TaskBO.GetInstance().Update(task);

            if (Session["ParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(TaskDataModel task)
        {
            TaskBO.GetInstance().Create(task);

            if (Session["ParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["ParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            TaskBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChildrenField(int id)
        {
            int count = TaskBO.GetInstance().GetCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = ""
            };

            return View("ChildrenField", model);
        }
    }
}
