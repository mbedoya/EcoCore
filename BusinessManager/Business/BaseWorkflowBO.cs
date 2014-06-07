using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class BaseWorkflowBO
    {
        public List<WorkflowDataModel> GetAll()
        {
            return WorkflowDAL.GetAll();
        }

        public WorkflowDataModel Get(int id)
        {
            return WorkflowDAL.Get(id);
        }

        public virtual void Update(WorkflowDataModel workflow)
        {
            if (workflow.ID > 0)
            {                

                WorkflowDAL.Update(workflow);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(WorkflowDataModel workflow)
        {
            

            WorkflowDAL.Create(workflow);
        }
    }
}
