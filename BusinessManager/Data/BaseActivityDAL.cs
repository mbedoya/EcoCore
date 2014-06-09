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
    public class BaseActivityDAL
    {
        public static List<ActivityDataModel> GetAll()
        {
            List<ActivityDataModel> activitys = new List<ActivityDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetActivitys", connection);
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
                if (item["WorkflowID"].GetType() != typeof(DBNull))
                {
                    activity.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
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

        public static ActivityDataModel Get(int id)
        {
            ActivityDataModel activity = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetActivityByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
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
                if (item["WorkflowID"].GetType() != typeof(DBNull))
                {
                    activity.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
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
                if (item["ParentActivityID"].GetType() != typeof(DBNull))
                {
                    activity.ParentActivityID = Convert.ToInt32(item["ParentActivityID"]);
                }
                if (item["Approved"].GetType() != typeof(DBNull))
                {
                    activity.Approved = Convert.ToBoolean(item["Approved"]);
                }
            }

            return activity;
        }

        public static void Update(ActivityDataModel activity)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateActivity", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", activity.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", activity.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramWorkflowID = new MySqlParameter("pWorkflowID", activity.WorkflowID);
            paramWorkflowID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramWorkflowID);
            MySqlParameter paramOwnerID = new MySqlParameter("pOwnerID", activity.OwnerID);
            paramOwnerID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramOwnerID);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", activity.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", activity.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramParentActivityID = new MySqlParameter("pParentActivityID", activity.ParentActivityID);
            paramParentActivityID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramParentActivityID);
            MySqlParameter paramApproved = new MySqlParameter("pApproved", activity.Approved);
            paramApproved.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramApproved);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(ActivityDataModel activity)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateActivity", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", activity.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", activity.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramWorkflowID = new MySqlParameter("pWorkflowID", activity.WorkflowID);
            paramWorkflowID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramWorkflowID);
            MySqlParameter paramOwnerID = new MySqlParameter("pOwnerID", activity.OwnerID);
            paramOwnerID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramOwnerID);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", activity.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", activity.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramParentActivityID = new MySqlParameter("pParentActivityID", activity.ParentActivityID);
            paramParentActivityID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramParentActivityID);
            MySqlParameter paramApproved = new MySqlParameter("pApproved", activity.Approved);
            paramApproved.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramApproved);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static List<ActivityDataModel> GetWorkflow(int id)
        {

            List<ActivityDataModel> activitys = new List<ActivityDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetByWorkflowID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

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
                if (item["WorkflowID"].GetType() != typeof(DBNull))
                {
                    activity.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
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

        public static List<ActivityDataModel> GetByWorkflow(int id)
        {
            List<ActivityDataModel> activitys = new List<ActivityDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetActivitysByWorkflow", connection);

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
                if (item["WorkflowID"].GetType() != typeof(DBNull))
                {
                    activity.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
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

        public static int GetTaskCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetActivityTaskCount", connection);
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

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteActivity", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
