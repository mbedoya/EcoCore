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
    public class WorkflowBO : BaseWorkflowBO
    {
        private static WorkflowBO instance;

        public static WorkflowBO GetInstance()
        {
            if(instance == null)
            {
                instance = new WorkflowBO();
            }

            return instance;
        }

        public int GetActivityCount(int workflowID)
        {
            return WorkflowDAL.GetActivityCount(workflowID);
        }

        public override void Create(WorkflowDataModel workflow)
        {
            if (!SecurityManager.SesionStarted())
            {
                throw new Exception("Session not started");
            }
            workflow.CreatedBy = SecurityManager.GetLoggedUser().ID;
            workflow.DateCreated = DateTime.Now;

            base.Create(workflow);
        }

        public ActivityDataModel GetNextWorkflowActivity(int workflowID)
        {
            return null;
        }
    }
}
