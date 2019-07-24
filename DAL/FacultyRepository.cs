using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FacultyRepository
    {
        #region SingletonPattern

        private static FacultyRepository FacultyRepositoryObj = null;
        private FacultyRepository() { }
        public static FacultyRepository GetInstance()
        {
            if (FacultyRepositoryObj == null)
            {
                FacultyRepositoryObj = new FacultyRepository();
            }
            return FacultyRepositoryObj;
        }

        #endregion

        public Exception GetAllFacultiesList(ref ICollection<Faculty> faculties)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_FACULTY.GET_ALL_FACULTY_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Faculty faculty = new Faculty();
                        faculty = Mapping(oracleDataReader);
                        faculties.Add(faculty);
                    }
                    return exceptionToReturn;

                }
                catch (Exception exception)
                {
                    exceptionToReturn = exception;
                    return exceptionToReturn;
                }
            }
        }

        public Exception GetActiveFacultiesList(ref ICollection<Faculty> faculties)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_FACULTY.GET_ACTIVE_FACULTIES_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Faculty faculty = new Faculty();
                        faculty = Mapping(oracleDataReader);
                        faculties.Add(faculty);
                    }
                    return exceptionToReturn;

                }
                catch (Exception exception)
                {
                    exceptionToReturn = exception;
                    return exceptionToReturn;
                }
            }
        }

        public Faculty Mapping(OracleDataReader oracleDataReader)
        {
            Faculty faculty = new Faculty();
            faculty.FacultyId = Convert.ToByte(oracleDataReader["FACULTY_ID"]);
            faculty.Name = (string)(oracleDataReader["NAME"]);
            faculty.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return faculty;
        }

    }
}
