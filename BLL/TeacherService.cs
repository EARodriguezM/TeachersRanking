using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TeacherService
    {
        #region SingletonPattern

        private static TeacherService TeacherServiceObj = null;
        private TeacherService() { }
        public static TeacherService GetInstance()
        {
            if (TeacherServiceObj == null)
            {
                TeacherServiceObj = new TeacherService();
            }
            return TeacherServiceObj;
        }

        #endregion

        public Exception AddTeacher(Teacher teacher)
        {
            return TeacherRepository.GetInstance().AddTeacher(teacher);
        }

        public Exception GetActiveTeachersList(ref ICollection<Teacher> teachers)
        {
            return TeacherRepository.GetInstance().GetActiveTeachersList(ref teachers);
        }

        public Exception GetAllTeachersList(ref ICollection<Teacher> teachers)
        {
            return TeacherRepository.GetInstance().GetAllTeachersList(ref teachers);
        }

        public Exception GetMattersByTeacher(ref Teacher teacher)
        {
            return RTeacherMatterRepository.GetInstance().GetMattersByTeacher(ref teacher);
        }

        public Exception GetReviewsByTeacher(ref Teacher teacher)
        {
            return ReviewRepository.GetInstance().GetReviewsByTeacher(ref teacher);
        }

        public Exception GetScoresByTeacher(ref Teacher teacher)
        {
            return ScoreRepository.GetInstance().GetScoresByTeacher(ref teacher);
        }
    }
}
