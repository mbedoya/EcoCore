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
    public class ManageFormdetailController : Controller
    {
        //
        // GET: /ManageFormdetail/

        public ActionResult Index(int id=0)
        {
            return View(FormdetailBO.GetInstance().GetAll(id));
        }

        public ActionResult Edit(int id)
        {
            return View(FormdetailBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(FormdetailDataModel formdetail)
        {
            FormdetailBO.GetInstance().Update(formdetail);

            if (Session["formdetailParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["formdetailParentID"]) });
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
        public ActionResult Create(FormdetailDataModel formdetail)
        {
            FormdetailBO.GetInstance().Create(formdetail);

            if (Session["formdetailParentID"] != null)
            {
                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["formdetailParentID"]) });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            FormdetailBO.GetInstance().Delete(id);

            return Json(new { success=true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChildrenField(int id)
        {
            int count = FormdetailBO.GetInstance().GetCount(id);

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
