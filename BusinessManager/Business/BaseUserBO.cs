using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class BaseUserBO
    {
        public List<UserDataModel> GetAll()
        {
            return UserDAL.GetAll();
        }

        public UserDataModel Get(int id)
        {
            return UserDAL.Get(id);
        }

        public virtual void Update(UserDataModel user)
        {
            if (user.ID > 0)
            {
                UserDAL.Update(user);
            }
            else
            {
                throw new Exception("Page not found");
            }
            
        }

        public virtual void Create(UserDataModel user)
        {
            UserDAL.Create(user);
        }
    }
}
