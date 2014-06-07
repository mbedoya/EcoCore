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
    public class BaseMenuDAL
    {
        public static List<MenuDataModel> GetAll()
        {
            List<MenuDataModel> menus = new List<MenuDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetMenus", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                MenuDataModel menu = new MenuDataModel();                
                
	 menu.ID = Convert.ToInt32(item["ID"]);
	 menu.Name = Convert.ToString(item["Name"]);
	 menu.URL = Convert.ToString(item["URL"]);
	 menu.MenuOrder = Convert.ToInt32(item["MenuOrder"]);

                menus.Add(menu);                 
            }            

            return menus;
        }

        public static MenuDataModel Get(int id)
        {
            MenuDataModel menu = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetMenuByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if(results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                menu = new MenuDataModel();                
                
	 menu.ID = Convert.ToInt32(item["ID"]);
	 menu.Name = Convert.ToString(item["Name"]);
	 menu.URL = Convert.ToString(item["URL"]);
	 menu.MenuOrder = Convert.ToInt32(item["MenuOrder"]);                
            }

            return menu;
        }

        public static void Update(MenuDataModel menu)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("UpdateMenu", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",menu.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",menu.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramURL = new MySqlParameter("pURL",menu.URL);
	 paramURL.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramURL);
	 MySqlParameter paramMenuOrder = new MySqlParameter("pMenuOrder",menu.MenuOrder);
	 paramMenuOrder.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramMenuOrder);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(MenuDataModel menu)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("CreateMenu", connection);                        
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",menu.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",menu.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramURL = new MySqlParameter("pURL",menu.URL);
	 paramURL.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramURL);
	 MySqlParameter paramMenuOrder = new MySqlParameter("pMenuOrder",menu.MenuOrder);
	 paramMenuOrder.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramMenuOrder);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
