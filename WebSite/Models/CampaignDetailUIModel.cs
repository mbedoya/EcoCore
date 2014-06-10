using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class CampaignDetailUIModel
    {
        public CampaignDataModel Campaign { get; set; }
        public List<ActivityDataModel> ActivitiesToExecute { get; set; }
    }
}