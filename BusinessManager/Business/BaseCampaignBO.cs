using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class BaseCampaignBO
    {
        public List<CampaignDataModel> GetAll()
        {
            return CampaignDAL.GetAll();
        }

        public CampaignDataModel Get(int id)
        {
            return CampaignDAL.Get(id);
        }

        public virtual void Update(CampaignDataModel campaign)
        {
            if (campaign.ID > 0)
            {
                

                CampaignDAL.Update(campaign);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(CampaignDataModel campaign)
        {
            

            CampaignDAL.Create(campaign);
        }
    }
}
