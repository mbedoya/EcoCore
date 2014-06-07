using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class BaseMenuBO
    {
        public List<MenuDataModel> GetAll()
        {
            return MenuDAL.GetAll();
        }

        public MenuDataModel Get(int id)
        {
            return MenuDAL.Get(id);
        }

        public virtual void Update(MenuDataModel menu)
        {
            if (menu.ID > 0)
            {
                MenuDAL.Update(menu);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public void Create(MenuDataModel menu)
        {
            MenuDAL.Create(menu);
        }
    }
}
