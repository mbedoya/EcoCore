using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessManager.Models
{
    public class TaskDataModel
    {
        
	public int ID  { get; set; }
	public string Name  { get; set; }
	public int CreatedBy  { get; set; }
	public DateTime DateCreated  { get; set; }
	public int AssignedTo  { get; set; }
	public string Template  { get; set; }
	public int ActivityID  { get; set; }
	public string Comments  { get; set; }
	 public HttpPostedFileBase fileTemplate { get; set; }        
    }
}