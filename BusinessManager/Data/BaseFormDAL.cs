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
    public class BaseFormDAL
    {
        public static List<FormDataModel> GetAll()
        {
            List<FormDataModel> forms = new List<FormDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetForms", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                FormDataModel form = new FormDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 form.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 form.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["WorkflowID"].GetType() != typeof(DBNull))
	 {
	 form.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
	 }

                forms.Add(form);                 
            }            

            return forms;
        }

        public static FormDataModel Get(int id)
        {
            FormDataModel form = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetFormByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if(results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                form = new FormDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 form.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 form.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["WorkflowID"].GetType() != typeof(DBNull))
	 {
	 form.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
	 }                
            }

            return form;
        }

        public static void Update(FormDataModel form)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateForm", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",form.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",form.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramWorkflowID = new MySqlParameter("pWorkflowID",form.WorkflowID);
	 paramWorkflowID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramWorkflowID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(FormDataModel form)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateForm", connection);                        
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",form.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",form.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramWorkflowID = new MySqlParameter("pWorkflowID",form.WorkflowID);
	 paramWorkflowID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramWorkflowID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static List<FormDataModel> GetWorkflow(int id)
        {

            List<FormDataModel> forms = new List<FormDataModel>();

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
                FormDataModel form = new FormDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 form.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 form.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["WorkflowID"].GetType() != typeof(DBNull))
	 {
	 form.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
	 }

                forms.Add(form);                 
            }            

            return forms;
        }

        public static List<FormDataModel> GetByWorkflow(int id)
        {
            List<FormDataModel> forms = new List<FormDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetFormsByWorkflow", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;        
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                FormDataModel form = new FormDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 form.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 form.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["WorkflowID"].GetType() != typeof(DBNull))
	 {
	 form.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
	 }

                forms.Add(form);                 
            }            

            return forms;
        }

        public static int GetFormdetailCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetFormFormdetailCount", connection);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteForm", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);            

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
