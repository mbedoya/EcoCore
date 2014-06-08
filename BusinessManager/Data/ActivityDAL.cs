using BusinessManager.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessManager.Data
{
    public class ActivityDAL : BaseActivityDAL
    {
        public static List<Models.ActivityDataModel> GetByWorkflow(int id)
        {
            List<ActivityDataModel> activitys = new List<ActivityDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetActivitysByWorkflow", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;        
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                ActivityDataModel activity = new ActivityDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    activity.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    activity.Name = Convert.ToString(item["Name"]);
                }
                if (item["OwnerID"].GetType() != typeof(DBNull))
                {
                    activity.OwnerID = Convert.ToInt32(item["OwnerID"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    activity.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    activity.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["WorkflowID"].GetType() != typeof(DBNull))
                {
                    activity.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
                }
                if (item["ParentActivityID"].GetType() != typeof(DBNull))
                {
                    activity.ParentActivityID = Convert.ToInt32(item["ParentActivityID"]);
                }
                if (item["Approved"].GetType() != typeof(DBNull))
                {
                    activity.Approved = Convert.ToBoolean(item["Approved"]);
                }

                activitys.Add(activity);
            }

            return activitys;
        }
    }
}