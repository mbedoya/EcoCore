using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.Security;

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

            base.Create(activity);
        }

    }
}
