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
    public class CampaignBO : BaseCampaignBO
    {
        private static CampaignBO instance;

        public static CampaignBO GetInstance()
        {
            if(instance == null)
            {
                instance = new CampaignBO();
            }

            return instance;
        }

        public override void Create(CampaignDataModel campaign)
        {
            
	 if (!SecurityManager.SesionStarted())
	 {
	 throw new Exception("Session not started");
	 }
	 campaign.CreatedBy = SecurityManager.GetLoggedUser().ID;        
            
	 campaign.DateCreated = DateTime.Now;

            base.Create(campaign);
        }
        
    }
}
