using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class CampaignController : Controller
    {
        //
        // GET: /Campaign/

        public ActionResult Index()
        {
            return View(new CampaignUIModel()
            {
                Campaigns = CampaignBO.GetInstance().GetAll()
            });
        }

        public ActionResult Start(int id)
        {
            var input = new Dictionary<string, object> { { "CampaignID", id } };
            WorkflowInvoker.Invoke(new BusinessWorkflow.MainActivity(), input);

            CampaignDataModel model = CampaignBO.GetInstance().Get(id);

            return View("~/Views/Campaign/View.cshtml", model);
        }

        public ActionResult View(int id)
        {
            CampaignDetailUIModel model = new CampaignDetailUIModel();
            model.Campaign = CampaignBO.GetInstance().Get(id);
            model.ActivitiesToExecute = CampaignBO.GetInstance().GetCampaignActivities(id);

            return View(model);
        }

    }
}
