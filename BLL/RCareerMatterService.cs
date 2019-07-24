using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RCareerMatterService
    {
        #region SingletonPattern

        private static RCareerMatterService RCareerMatterServiceObj = null;
        private RCareerMatterService() { }
        public static RCareerMatterService GetInstance()
        {
            if (RCareerMatterServiceObj == null)
            {
                RCareerMatterServiceObj = new RCareerMatterService();
            }
            return RCareerMatterServiceObj;
        }

        #endregion
    }
}
