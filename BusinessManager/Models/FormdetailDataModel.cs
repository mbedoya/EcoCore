using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessManager.Models
{
    public class FormdetailDataModel
    {
        
	public int? ID  { get; set; }
	public string Name  { get; set; }
	public string FieldType  { get; set; }
	public string TableName  { get; set; }
	public int? FormID  { get; set; }        
    }
}