using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RTeacherMatterService
    {
        #region SingletonPattern

        private static RTeacherMatterService RTeacherMatterServiceObj = null;
        private RTeacherMatterService() { }
        public static RTeacherMatterService GetInstance()
        {
            if (RTeacherMatterServiceObj == null)
            {
                RTeacherMatterServiceObj = new RTeacherMatterService();
            }
            return RTeacherMatterServiceObj;
        }

        #endregion

        public Exception AddRTeacherMatter(Matter matter, SemesterLog semesterLog, Teacher teacher)
        {
            return RTeacherMatterRepository.GetInstance().AddRTeacherMatter(matter.MatterId, semesterLog.SemesterLogId, teacher.TeacherId);
        }

        public Exception GetTeachersByMatterFilterBySemester(Matter matter, SemesterLog semesterLog)
        {
            return RTeacherMatterRepository.GetInstance().GetTeachersByMatterFilterBySemester(ref matter, semesterLog.SemesterLogId);
        }

        public Exception GetMattersByTeacherFilterBySemester(Teacher teacher, SemesterLog semesterLog)
        {
            return RTeacherMatterRepository.GetInstance().GetMattersByTeacherFilterBySemester(ref teacher, semesterLog.SemesterLogId);
        }
    }
}
