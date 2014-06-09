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
            List<MenuDataModel> menus = MenuBO.GetInstance().GetParentMenus();
            List<MenuUIModel> model = new List<MenuUIModel>();
            foreach (var item in menus)
            {
                model.Add(new MenuUIModel()
                {
                    Item = item
                    ,Children = MenuBO.GetInstance().GetByMenu(item.ID)
                });
            }

            return View(model);
        }

        public ActionResult FileDisplay(string url)
        {
            FileUIModel model = new FileUIModel();
            model.URL = url;

            return View(model);
        }
    }
}
