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
    public class TaskBO : BaseTaskBO
    {
        private static TaskBO instance;

        public static TaskBO GetInstance()
        {
            if (instance == null)
            {
                instance = new TaskBO();
            }

            return instance;
        }

        public override void Create(TaskDataModel task)
        {

            if (!SecurityManager.SesionStarted())
            {
                throw new Exception("Session not started");
            }
            task.CreatedBy = SecurityManager.GetLoggedUser().ID;

            task.DateCreated = DateTime.Now;

            base.Create(task);
        }


        public override List<TaskDataModel> GetAll(int id)
        {
            if (id > 0)
            {
                HttpContext.Current.Session["ParentID"] = id;
                return GetByActivity(id);
            }
            else
            {
                HttpContext.Current.Session["ParentID"] = null;
                return base.GetAll(id);
            }
        }
        public List<TaskDataModel> GetByActivity(int id)
        {
            return null;
        }

    }
}
