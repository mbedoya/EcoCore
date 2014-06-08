using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace BusinessManager.Data
{
    public class WorkflowDAL : BaseWorkflowDAL
    {
        public ActivityDataModel GetNextWorkflowActivity(int workflowID)
        {
            ActivityDataModel activity = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetNextWorkflowActivity", connection);
            MySqlParameter paramID = new MySqlParameter("pId", workflowID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                activity = new ActivityDataModel();

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
            }

            return activity;           
        }

        public static int GetActivityCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetWorkflowActivityCount", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];                

                if (item["count"].GetType() != typeof(DBNull))
                {
                    count = Convert.ToInt32(item["count"]);
                }                
            }

            return count;       
        }
    }
}
