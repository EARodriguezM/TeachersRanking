using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CareerService
    {
        #region SingletonPattern

        private static CareerService CareerServiceObj = null;
        private CareerService() { }
        public static CareerService GetInstance()
        {
            if (CareerServiceObj == null)
            {
                CareerServiceObj = new CareerService();
            }
            return CareerServiceObj;
        }

        #endregion

        public Exception GetAllCareersList(ref ICollection<Career> careers)
        {
            return CareerRepository.GetInstance().GetAllCareersList(ref careers);
        }

        public Exception GetActiveCareersList(ref ICollection<Career> careers)
        {
            return CareerRepository.GetInstance().GetActiveCareersList(ref careers);
        }

        public Exception GetMatterByCarrer(ref Career career)
        {
            return RCareerMatterRepository.GetInstance().GetMatterByCarrer(ref career);
        }
    }
}
