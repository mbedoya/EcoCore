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
    public class ManageFormController : Controller
    {
        //
        // GET: /ManageForm/

        public ActionResult Index(int id=0)
        {
            return View(FormBO.GetInstance().GetAll(id));
        }

        public ActionResult Edit(int id)
        {
            return View(FormBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(FormDataModel form)
        {
            FormBO.GetInstance().Update(form);

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
        public ActionResult Create(FormDataModel form)
        {
            FormBO.GetInstance().Create(form);

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
            FormBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FormdetailChildrenField(int id)
        {
            int count = FormBO.GetInstance().GetFormdetailCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = "Formdetail"
            };

            return View("ChildrenField", model);
        }
    }
}
