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
    public class BaseCampaignDAL
    {
        public static List<CampaignDataModel> GetAll()
        {
            List<CampaignDataModel> campaigns = new List<CampaignDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetCampaigns", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                CampaignDataModel campaign = new CampaignDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    campaign.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    campaign.Name = Convert.ToString(item["Name"]);
                }
                if (item["WorkflowID"].GetType() != typeof(DBNull))
                {
                    campaign.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    campaign.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    campaign.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }
                if (item["DateStarted"].GetType() != typeof(DBNull))
                {
                    campaign.DateStarted = Convert.ToDateTime(item["DateStarted"]);
                }
                if (item["OwnerID"].GetType() != typeof(DBNull))
                {
                    campaign.OwnerID = Convert.ToInt32(item["OwnerID"]);
                }

                campaigns.Add(campaign);
            }

            return campaigns;
        }

        public static CampaignDataModel Get(int id)
        {
            CampaignDataModel campaign = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetCampaignByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                campaign = new CampaignDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    campaign.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    campaign.Name = Convert.ToString(item["Name"]);
                }
                if (item["WorkflowID"].GetType() != typeof(DBNull))
                {
                    campaign.WorkflowID = Convert.ToInt32(item["WorkflowID"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    campaign.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    campaign.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }
                if (item["DateStarted"].GetType() != typeof(DBNull))
                {
                    campaign.DateStarted = Convert.ToDateTime(item["DateStarted"]);
                }
                if (item["OwnerID"].GetType() != typeof(DBNull))
                {
                    campaign.OwnerID = Convert.ToInt32(item["OwnerID"]);
                }
            }

            return campaign;
        }

        public static void Update(CampaignDataModel campaign)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("UpdateCampaign", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", campaign.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", campaign.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramWorkflowID = new MySqlParameter("pWorkflowID", campaign.WorkflowID);
            paramWorkflowID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramWorkflowID);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", campaign.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", campaign.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);
            MySqlParameter paramDateStarted = new MySqlParameter("pDateStarted", campaign.DateStarted);
            paramDateStarted.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateStarted);
            MySqlParameter paramOwnerID = new MySqlParameter("pOwnerID", campaign.OwnerID);
            paramOwnerID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramOwnerID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(CampaignDataModel campaign)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("CreateCampaign", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", campaign.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", campaign.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramWorkflowID = new MySqlParameter("pWorkflowID", campaign.WorkflowID);
            paramWorkflowID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramWorkflowID);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", campaign.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", campaign.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);
            MySqlParameter paramDateStarted = new MySqlParameter("pDateStarted", campaign.DateStarted);
            paramDateStarted.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateStarted);
            MySqlParameter paramOwnerID = new MySqlParameter("pOwnerID", campaign.OwnerID);
            paramOwnerID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramOwnerID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
