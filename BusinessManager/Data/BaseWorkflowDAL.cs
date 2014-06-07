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
    public class BaseWorkflowDAL
    {
        public static List<WorkflowDataModel> GetAll()
        {
            List<WorkflowDataModel> workflows = new List<WorkflowDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetWorkflows", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                WorkflowDataModel workflow = new WorkflowDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    workflow.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    workflow.Name = Convert.ToString(item["Name"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    workflow.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    workflow.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }

                workflows.Add(workflow);
            }

            return workflows;
        }

        public static WorkflowDataModel Get(int id)
        {
            WorkflowDataModel workflow = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetWorkflowByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                workflow = new WorkflowDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    workflow.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    workflow.Name = Convert.ToString(item["Name"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    workflow.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    workflow.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
            }

            return workflow;
        }

        public static void Update(WorkflowDataModel workflow)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("UpdateWorkflow", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", workflow.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", workflow.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", workflow.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", workflow.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(WorkflowDataModel workflow)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("CreateWorkflow", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", workflow.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", workflow.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", workflow.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", workflow.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
