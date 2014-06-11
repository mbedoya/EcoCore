using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.Security;
using System.Web;

namespace BusinessManager.Business
{
    public class FormBO : BaseFormBO
    {
        private static FormBO instance;

        public static FormBO GetInstance()
        {
            if (instance == null)
            {
                instance = new FormBO();
            }

            return instance;
        }

        public override void Create(FormDataModel form)
        {



            if (HttpContext.Current.Session["ParentID"] != null)
            {
                form.WorkflowID = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            }

            base.Create(form);
        }


        public override List<FormDataModel> GetAll(int id = 0)
        {
            if (id > 0)
            {
                HttpContext.Current.Session["ParentID"] = id;
                return GetByWorkflow(id);
            }
            else
            {
                HttpContext.Current.Session["ParentID"] = null;
                return base.GetAll(id);
            }
        }
        public List<FormDataModel> GetByWorkflow(int id)
        {
            return FormDAL.GetByWorkflow(id);
        }

        public override void Delete(int id)
        {
            if (!SecurityManager.SesionStarted() || SecurityManager.GetLoggedUser().Role != UserRole.Admin)
            {
                throw new Exception("Action not allowed");
            }

            base.Delete(id);
        }

    }
}
