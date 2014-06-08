using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers.Admin
{
    public class ManageWorkflowController : Controller
    {
        //
        // GET: /ManageWorkflow/

        public ActionResult Index()
        {
            return View(WorkflowBO.GetInstance().GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(WorkflowBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(WorkflowDataModel workflow)
        {
            WorkflowBO.GetInstance().Update(workflow);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(WorkflowDataModel workflow)
        {
            WorkflowBO.GetInstance().Create(workflow);

            return RedirectToAction("Index");
        }

        public ActionResult ActivityChildrenField(int id)
        {
            int count = WorkflowBO.GetInstance().GetActivityCount(id);

            ChildrenFieldUIModel model = new ChildrenFieldUIModel()
            {
                ID = id,
                Count = count,
                ClassName = "Activity"
            };

            return View("ChildrenField", model);
        }
    }
}
