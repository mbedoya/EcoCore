using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class BaseTaskBO
    {
        public virtual List<TaskDataModel> GetAll(int id)
        {
            return TaskDAL.GetAll();
        }

        public virtual TaskDataModel Get(int id)
        {
            return TaskDAL.Get(id);
        }

        public virtual void Update(TaskDataModel task)
        {
            if (task.ID > 0)
            {
                
	 if (task.fileTemplate != null){
	 string filePath = FileManager.SaveFile(task.fileTemplate);
	 if (!String.IsNullOrEmpty(filePath))
		 {
	task.Template = filePath;
		 };
	 }

                TaskDAL.Update(task);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(TaskDataModel task)
        {
            
	 if (task.fileTemplate != null){
	 string filePath = FileManager.SaveFile(task.fileTemplate);
	 if (!String.IsNullOrEmpty(filePath))
		 {
	task.Template = filePath;
		 };
	 }

            TaskDAL.Create(task);
        }
    }
}