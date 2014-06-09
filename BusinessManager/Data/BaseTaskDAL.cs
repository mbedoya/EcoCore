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
    public class BaseTaskDAL
    {
        public static List<TaskDataModel> GetAll()
        {
            List<TaskDataModel> tasks = new List<TaskDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetTasks", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                TaskDataModel task = new TaskDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 task.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 task.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["CreatedBy"].GetType() != typeof(DBNull))
	 {
	 task.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
	 }
	 if (item["DateCreated"].GetType() != typeof(DBNull))
	 {
	 task.DateCreated = Convert.ToDateTime(item["DateCreated"]);
	 }
	 if (item["AssignedTo"].GetType() != typeof(DBNull))
	 {
	 task.AssignedTo = Convert.ToInt32(item["AssignedTo"]);
	 }
	 if (item["Template"].GetType() != typeof(DBNull))
	 {
	 task.Template = Convert.ToString(item["Template"]);
	 }
	 if (item["ActivityID"].GetType() != typeof(DBNull))
	 {
	 task.ActivityID = Convert.ToInt32(item["ActivityID"]);
	 }
	 if (item["Comments"].GetType() != typeof(DBNull))
	 {
	 task.Comments = Convert.ToString(item["Comments"]);
	 }

                tasks.Add(task);                 
            }            

            return tasks;
        }

        public static TaskDataModel Get(int id)
        {
            TaskDataModel task = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetTaskByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if(results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                task = new TaskDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 task.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 task.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["CreatedBy"].GetType() != typeof(DBNull))
	 {
	 task.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
	 }
	 if (item["DateCreated"].GetType() != typeof(DBNull))
	 {
	 task.DateCreated = Convert.ToDateTime(item["DateCreated"]);
	 }
	 if (item["AssignedTo"].GetType() != typeof(DBNull))
	 {
	 task.AssignedTo = Convert.ToInt32(item["AssignedTo"]);
	 }
	 if (item["Template"].GetType() != typeof(DBNull))
	 {
	 task.Template = Convert.ToString(item["Template"]);
	 }
	 if (item["ActivityID"].GetType() != typeof(DBNull))
	 {
	 task.ActivityID = Convert.ToInt32(item["ActivityID"]);
	 }
	 if (item["Comments"].GetType() != typeof(DBNull))
	 {
	 task.Comments = Convert.ToString(item["Comments"]);
	 }                
            }

            return task;
        }

        public static void Update(TaskDataModel task)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateTask", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",task.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",task.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy",task.CreatedBy);
	 paramCreatedBy.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramCreatedBy);
	 MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated",task.DateCreated);
	 paramDateCreated.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramDateCreated);
	 MySqlParameter paramAssignedTo = new MySqlParameter("pAssignedTo",task.AssignedTo);
	 paramAssignedTo.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramAssignedTo);
	 MySqlParameter paramTemplate = new MySqlParameter("pTemplate",task.Template);
	 paramTemplate.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramTemplate);
	 MySqlParameter paramActivityID = new MySqlParameter("pActivityID",task.ActivityID);
	 paramActivityID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramActivityID);
	 MySqlParameter paramComments = new MySqlParameter("pComments",task.Comments);
	 paramComments.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramComments);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(TaskDataModel task)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateTask", connection);                        
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",task.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",task.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy",task.CreatedBy);
	 paramCreatedBy.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramCreatedBy);
	 MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated",task.DateCreated);
	 paramDateCreated.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramDateCreated);
	 MySqlParameter paramAssignedTo = new MySqlParameter("pAssignedTo",task.AssignedTo);
	 paramAssignedTo.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramAssignedTo);
	 MySqlParameter paramTemplate = new MySqlParameter("pTemplate",task.Template);
	 paramTemplate.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramTemplate);
	 MySqlParameter paramActivityID = new MySqlParameter("pActivityID",task.ActivityID);
	 paramActivityID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramActivityID);
	 MySqlParameter paramComments = new MySqlParameter("pComments",task.Comments);
	 paramComments.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramComments);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static List<TaskDataModel> GetActivity(int id)
        {

            List<TaskDataModel> tasks = new List<TaskDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetByActivityID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                TaskDataModel task = new TaskDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 task.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 task.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["CreatedBy"].GetType() != typeof(DBNull))
	 {
	 task.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
	 }
	 if (item["DateCreated"].GetType() != typeof(DBNull))
	 {
	 task.DateCreated = Convert.ToDateTime(item["DateCreated"]);
	 }
	 if (item["AssignedTo"].GetType() != typeof(DBNull))
	 {
	 task.AssignedTo = Convert.ToInt32(item["AssignedTo"]);
	 }
	 if (item["Template"].GetType() != typeof(DBNull))
	 {
	 task.Template = Convert.ToString(item["Template"]);
	 }
	 if (item["ActivityID"].GetType() != typeof(DBNull))
	 {
	 task.ActivityID = Convert.ToInt32(item["ActivityID"]);
	 }
	 if (item["Comments"].GetType() != typeof(DBNull))
	 {
	 task.Comments = Convert.ToString(item["Comments"]);
	 }

                tasks.Add(task);                 
            }            

            return tasks;
        }

        public static List<TaskDataModel> GetByActivity(int id)
        {
            List<TaskDataModel> tasks = new List<TaskDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetTasksByActivity", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;        
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                TaskDataModel task = new TaskDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 task.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 task.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["CreatedBy"].GetType() != typeof(DBNull))
	 {
	 task.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
	 }
	 if (item["DateCreated"].GetType() != typeof(DBNull))
	 {
	 task.DateCreated = Convert.ToDateTime(item["DateCreated"]);
	 }
	 if (item["AssignedTo"].GetType() != typeof(DBNull))
	 {
	 task.AssignedTo = Convert.ToInt32(item["AssignedTo"]);
	 }
	 if (item["Template"].GetType() != typeof(DBNull))
	 {
	 task.Template = Convert.ToString(item["Template"]);
	 }
	 if (item["ActivityID"].GetType() != typeof(DBNull))
	 {
	 task.ActivityID = Convert.ToInt32(item["ActivityID"]);
	 }
	 if (item["Comments"].GetType() != typeof(DBNull))
	 {
	 task.Comments = Convert.ToString(item["Comments"]);
	 }

                tasks.Add(task);                 
            }            

            return tasks;
        }

        public static int GetCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetTaskCount", connection);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteTask", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);            

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
