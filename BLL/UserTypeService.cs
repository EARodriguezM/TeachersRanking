using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class UserTypeService
    {
        #region SingletonPattern

        private static UserTypeService UserTypeServiceObj = null;
        private UserTypeService() { }
        public static UserTypeService GetInstance()
        {
            if (UserTypeServiceObj == null)
            {
                UserTypeServiceObj = new UserTypeService();
            }
            return UserTypeServiceObj;
        }

        #endregion
    }
}
