using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SemesterLogService
    {
        #region SingletonPattern

        private static SemesterLogService SemesterLogServiceObj = null;
        private SemesterLogService() { }
        public static SemesterLogService GetInstance()
        {
            if (SemesterLogServiceObj == null)
            {
                SemesterLogServiceObj = new SemesterLogService();
            }
            return SemesterLogServiceObj;
        }

        #endregion

        public Exception GetSemesterLog(ref ICollection<SemesterLog> semesterLogs)
        {
            return SemesterLogRepository.GetInstance().GetSemesterLog(ref semesterLogs);
        }

        public Exception GetScoresBySemester(ref SemesterLog semesterLog)
        {
            return ScoreRepository.GetInstance().GetScoresBySemester(ref semesterLog);
        }

        public Exception GetReviewsBySemester(ref SemesterLog semesterLog)
        {
            return ReviewRepository.GetInstance().GetReviewsBySemester(ref semesterLog);
        }

    }
}
