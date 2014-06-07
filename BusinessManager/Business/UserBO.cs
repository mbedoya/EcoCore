using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessManager.Data;
using BusinessManager.Models;
using Utilities.Security;

namespace BusinessManager.Business
{
    public class UserBO : BaseUserBO
    {
        private static UserBO instance;

        public static UserBO GetInstance()
        {
            if (instance == null)
            {
                instance = new UserBO();
            }

            return instance;
        }

        public override void Create(UserDataModel user)
        {
            if(!SecurityManager.SesionStarted())
            {
                throw new Exception("Session not started");
            }

            user.CreatedBy = SecurityManager.GetLoggedUser().ID;
            user.DateCreated = DateTime.Now;

            base.Create(user);
        }

        public UserDataModel CheckUser(string email, string password)
        {
            return UserDAL.CheckUser(email, password);
        }
    }
}
