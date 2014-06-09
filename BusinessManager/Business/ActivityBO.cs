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
    public class ActivityBO : BaseActivityBO
    {
        private static ActivityBO instance;

        public static ActivityBO GetInstance()
        {
            if (instance == null)
            {
                instance = new ActivityBO();
            }

            return instance;
        }

        public override void Create(ActivityDataModel activity)
        {

            if (!SecurityManager.SesionStarted())
            {
                throw new Exception("Session not started");
            }
            activity.CreatedBy = SecurityManager.GetLoggedUser().ID;

            activity.DateCreated = DateTime.Now;

            if (HttpContext.Current.Session["ParentID"] != null)
            {
                activity.WorkflowID = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            }

            base.Create(activity);
        }


        public override List<ActivityDataModel> GetAll(int id = 0)
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
        public List<ActivityDataModel> GetByWorkflow(int id)
        {
            return ActivityDAL.GetByWorkflow(id);
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
