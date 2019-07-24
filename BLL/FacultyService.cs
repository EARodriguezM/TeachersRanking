using ENTITY;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacultyService
    {
        #region SingletonPattern

        private static FacultyService FacultyServiceObj = null;
        private FacultyService() { }
        public static FacultyService GetInstance()
        {
            if (FacultyServiceObj == null)
            {
                FacultyServiceObj = new FacultyService();
            }
            return FacultyServiceObj;
        }

        #endregion

        public Exception GetAllFacultiesList(ref ICollection<Faculty> faculties)
        {
            return FacultyRepository.GetInstance().GetAllFacultiesList(ref faculties);
        }

        public Exception GetActiveFacultiesList(ref ICollection<Faculty> faculties)
        {
            return FacultyRepository.GetInstance().GetActiveFacultiesList(ref faculties);
        }

        public Exception GetCareersByFaculty(ref Faculty faculty)
        {
            return CareerRepository.GetInstance().GetCareersByFaculty(ref faculty);
        }

    }
}
