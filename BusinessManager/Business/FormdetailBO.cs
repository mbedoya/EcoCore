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
    public class FormdetailBO : BaseFormdetailBO
    {
        private static FormdetailBO instance;

        public static FormdetailBO GetInstance()
        {
            if(instance == null)
            {
                instance = new FormdetailBO();
            }

            return instance;
        }

        public override void Create(FormdetailDataModel formdetail)
        {
                    
            

            if (HttpContext.Current.Session["formdetailParentID"] != null)
            {
                formdetail.FormID = Convert.ToInt32(HttpContext.Current.Session["formdetailParentID"]);
            }

            base.Create(formdetail);
        }    

        
	 public override List<FormdetailDataModel> GetAll(int id=0)
	 {
	 if(id > 0)
	 {
	  HttpContext.Current.Session["formdetailParentID"] = id;
	 return GetByForm(id);
	 }else 
	 { 
	 HttpContext.Current.Session["formdetailParentID"] = null;
	 return base.GetAll(id);
	 }
	 }
	 public List<FormdetailDataModel> GetByForm(int id)
	 {
	 return FormdetailDAL.GetByForm(id);
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
