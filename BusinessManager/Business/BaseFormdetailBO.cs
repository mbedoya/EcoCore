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
    public class BaseFormdetailBO
    {
        public virtual List<FormdetailDataModel> GetAll(int id=0)
        {
            return FormdetailDAL.GetAll();
        }

        public virtual FormdetailDataModel Get(int id)
        {
            return FormdetailDAL.Get(id);
        }

        public virtual void Update(FormdetailDataModel formdetail)
        {
            if (formdetail.ID > 0)
            {
                

                FormdetailDAL.Update(formdetail);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(FormdetailDataModel formdetail)
        {
            

            FormdetailDAL.Create(formdetail);
        }

        public virtual void Delete(int id)
        {
            FormdetailDAL.Delete(id);
        }

        public int GetCount(int formdetailID)
        {
            return FormdetailDAL.GetCount(formdetailID);
        }
    }
}