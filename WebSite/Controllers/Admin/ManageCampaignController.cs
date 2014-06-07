using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers.Admin
{
    public class ManageCampaignController : Controller
    {
        //
        // GET: /ManageCampaign/

        public ActionResult Index()
        {
            return View(CampaignBO.GetInstance().GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(CampaignBO.GetInstance().Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(CampaignDataModel campaign)
        {
            CampaignBO.GetInstance().Update(campaign);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CampaignDataModel campaign)
        {
            CampaignBO.GetInstance().Create(campaign);

            return RedirectToAction("Index");
        }
    }
}
