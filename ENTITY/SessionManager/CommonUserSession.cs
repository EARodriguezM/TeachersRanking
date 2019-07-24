using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.SessionManager
{
    public class CommonUserSession : CommonUser
    {
        #region SingletonPattern

        private static CommonUserSession CommonUserSessionObj = null;
        private CommonUserSession() { }
        public static CommonUserSession GetInstance()
        {
            if (CommonUserSessionObj == null)
            {
                CommonUserSessionObj = new CommonUserSession();
            }
            return CommonUserSessionObj;
        }

        #endregion

        public void LogOut()
        {
            CommonUserSessionObj = null;
        }

        public void ChangeAnyData(CommonUser commonUser)
        {

        }

    }
}
