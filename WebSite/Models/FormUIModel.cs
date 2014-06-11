using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class FormUIModel
    {
        public string Name { get; set; }
        public List<FormdetailDataModel> Fields { get; set; }
    }
}