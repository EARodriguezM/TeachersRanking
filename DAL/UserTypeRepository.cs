using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserTypeRepository
    {
        #region SingletonPattern

        private static UserTypeRepository UserTypeRepositoryObj = null;
        private UserTypeRepository() { }
        public static UserTypeRepository GetInstance()
        {
            if (UserTypeRepositoryObj == null)
            {
                UserTypeRepositoryObj = new UserTypeRepository();
            }
            return UserTypeRepositoryObj;
        }

        #endregion
    }
}
