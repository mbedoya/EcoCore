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
    public class BaseFormdetailDAL
    {
        public static List<FormdetailDataModel> GetAll()
        {
            List<FormdetailDataModel> formdetails = new List<FormdetailDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetFormdetails", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                FormdetailDataModel formdetail = new FormdetailDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 formdetail.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 formdetail.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["FieldType"].GetType() != typeof(DBNull))
	 {
	 formdetail.FieldType = Convert.ToString(item["FieldType"]);
	 }
	 if (item["TableName"].GetType() != typeof(DBNull))
	 {
	 formdetail.TableName = Convert.ToString(item["TableName"]);
	 }
	 if (item["FormID"].GetType() != typeof(DBNull))
	 {
	 formdetail.FormID = Convert.ToInt32(item["FormID"]);
	 }

                formdetails.Add(formdetail);                 
            }            

            return formdetails;
        }

        public static FormdetailDataModel Get(int id)
        {
            FormdetailDataModel formdetail = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetFormdetailByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if(results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                formdetail = new FormdetailDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 formdetail.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 formdetail.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["FieldType"].GetType() != typeof(DBNull))
	 {
	 formdetail.FieldType = Convert.ToString(item["FieldType"]);
	 }
	 if (item["TableName"].GetType() != typeof(DBNull))
	 {
	 formdetail.TableName = Convert.ToString(item["TableName"]);
	 }
	 if (item["FormID"].GetType() != typeof(DBNull))
	 {
	 formdetail.FormID = Convert.ToInt32(item["FormID"]);
	 }                
            }

            return formdetail;
        }

        public static void Update(FormdetailDataModel formdetail)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateFormdetail", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",formdetail.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",formdetail.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramFieldType = new MySqlParameter("pFieldType",formdetail.FieldType);
	 paramFieldType.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramFieldType);
	 MySqlParameter paramTableName = new MySqlParameter("pTableName",formdetail.TableName);
	 paramTableName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramTableName);
	 MySqlParameter paramFormID = new MySqlParameter("pFormID",formdetail.FormID);
	 paramFormID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramFormID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(FormdetailDataModel formdetail)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateFormdetail", connection);                        
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",formdetail.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",formdetail.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramFieldType = new MySqlParameter("pFieldType",formdetail.FieldType);
	 paramFieldType.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramFieldType);
	 MySqlParameter paramTableName = new MySqlParameter("pTableName",formdetail.TableName);
	 paramTableName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramTableName);
	 MySqlParameter paramFormID = new MySqlParameter("pFormID",formdetail.FormID);
	 paramFormID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramFormID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static List<FormdetailDataModel> GetForm(int id)
        {

            List<FormdetailDataModel> formdetails = new List<FormdetailDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetByFormID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                FormdetailDataModel formdetail = new FormdetailDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 formdetail.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 formdetail.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["FieldType"].GetType() != typeof(DBNull))
	 {
	 formdetail.FieldType = Convert.ToString(item["FieldType"]);
	 }
	 if (item["TableName"].GetType() != typeof(DBNull))
	 {
	 formdetail.TableName = Convert.ToString(item["TableName"]);
	 }
	 if (item["FormID"].GetType() != typeof(DBNull))
	 {
	 formdetail.FormID = Convert.ToInt32(item["FormID"]);
	 }

                formdetails.Add(formdetail);                 
            }            

            return formdetails;
        }

        public static List<FormdetailDataModel> GetByForm(int id)
        {
            List<FormdetailDataModel> formdetails = new List<FormdetailDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetFormdetailsByForm", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;        
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                FormdetailDataModel formdetail = new FormdetailDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 formdetail.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 formdetail.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["FieldType"].GetType() != typeof(DBNull))
	 {
	 formdetail.FieldType = Convert.ToString(item["FieldType"]);
	 }
	 if (item["TableName"].GetType() != typeof(DBNull))
	 {
	 formdetail.TableName = Convert.ToString(item["TableName"]);
	 }
	 if (item["FormID"].GetType() != typeof(DBNull))
	 {
	 formdetail.FormID = Convert.ToInt32(item["FormID"]);
	 }

                formdetails.Add(formdetail);                 
            }            

            return formdetails;
        }

        public static int GetCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetFormdetailCount", connection);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteFormdetail", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);            

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
