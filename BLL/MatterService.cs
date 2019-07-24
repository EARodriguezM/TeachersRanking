using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MatterService
    {
        #region SingletonPattern

        private static MatterService MatterServiceObj = null;
        private MatterService() { }
        public static MatterService GetInstance()
        {
            if (MatterServiceObj == null)
            {
                MatterServiceObj = new MatterService();
            }
            return MatterServiceObj;
        }

        #endregion

        public Exception GetAllMattersList(ref ICollection<Matter> matters)
        {
            return MatterRepository.GetInstance().GetAllMattersList(ref matters);
        }

        public Exception GetActiveMattersList(ref ICollection<Matter> matters)
        {
            return MatterRepository.GetInstance().GetActiveMattersList(ref matters);
        }

        public Exception GetCareerByMatter(ref Matter matter)
        {
            return RCareerMatterRepository.GetInstance().GetCareerByMatter(ref matter);
        }

        public Exception GetTeachersByMatter(ref Matter matter)
        {
            return RTeacherMatterRepository.GetInstance().GetTeachersByMatter(ref matter);
        }

        public Exception GetReviewsByMatter(ref Matter matter)
        {
            return ReviewRepository.GetInstance().GetReviewsByMatter(ref matter);
        }
    }
}
