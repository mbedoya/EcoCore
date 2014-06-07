using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessManager.Models
{
    public class WorkflowDataModel
    {
        
	public int ID  { get; set; }
	public string Name  { get; set; }
	public int CreatedBy  { get; set; }
	public DateTime DateCreated  { get; set; }        
    }
}