using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Web;

namespace BusinessManager.Business
{
    public class BaseActivityBO
    {
        public virtual List<ActivityDataModel> GetAll(int id=0)
        {
            return ActivityDAL.GetAll();
        }

        public virtual ActivityDataModel Get(int id)
        {
            return ActivityDAL.Get(id);
        }

        public virtual void Update(ActivityDataModel activity)
        {
            if (activity.ID > 0)
            {
                

                ActivityDAL.Update(activity);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(ActivityDataModel activity)
        {
            

            ActivityDAL.Create(activity);
        }

        public virtual void Delete(int id)
        {
            ActivityDAL.Delete(id);
        }

        public int GetTaskCount(int activityID)
        {
            return ActivityDAL.GetTaskCount(activityID);
        }
    }
}