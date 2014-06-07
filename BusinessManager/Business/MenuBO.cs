using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class MenuBO : BaseMenuBO
    {
        private static MenuBO instance;

        public static MenuBO GetInstance()
        {
            if(instance == null)
            {
                instance = new MenuBO();
            }

            return instance;
        }

        public override void Update(MenuDataModel menu)
        {            
            base.Update(menu);
        }
    }
}
