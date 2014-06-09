using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessManager.Models
{
    public class ActivityDataModel
    {
        
	public int? ID  { get; set; }
	public string Name  { get; set; }
	public int? WorkflowID  { get; set; }
	public int? OwnerID  { get; set; }
	public int? CreatedBy  { get; set; }
	public DateTime DateCreated  { get; set; }
	public int? ParentActivityID  { get; set; }
	public bool Approved  { get; set; }        
    }
}