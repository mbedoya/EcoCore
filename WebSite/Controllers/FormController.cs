using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/

        public ActionResult Index()
        {
            return View(FormBO.GetInstance().GetAll());
        }

        public ActionResult View(int id)
        {
            FormDataModel form = FormBO.GetInstance().Get(id);

            FormUIModel model = new FormUIModel();
            model.Name = form.Name;
            model.Fields = FormdetailBO.GetInstance().GetByForm(id);

            return View(model);
        }

    }
}
