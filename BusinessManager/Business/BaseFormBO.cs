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
    public class BaseFormBO
    {
        public virtual List<FormDataModel> GetAll(int id=0)
        {
            return FormDAL.GetAll();
        }

        public virtual FormDataModel Get(int id)
        {
            return FormDAL.Get(id);
        }

        public virtual void Update(FormDataModel form)
        {
            if (form.ID > 0)
            {
                

                FormDAL.Update(form);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(FormDataModel form)
        {
            

            FormDAL.Create(form);
        }

        public virtual void Delete(int id)
        {
            FormDAL.Delete(id);
        }

        public int GetFormdetailCount(int formID)
        {
            return FormDAL.GetFormdetailCount(formID);
        }
    }
}