using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ScoreService
    {
        #region SingletonPattern

        private static ScoreService ScoreServiceObj = null;
        private ScoreService() { }
        public static ScoreService GetInstance()
        {
            if (ScoreServiceObj == null)
            {
                ScoreServiceObj = new ScoreService();
            }
            return ScoreServiceObj;
        }

        #endregion

        public Exception GetScores(ref ICollection<Score> scores)
        {
            return ScoreRepository.GetInstance().GetScores(ref scores);
        }

    }
}
