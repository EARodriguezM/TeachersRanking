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
    public class SemesterLogRepository
    {
        #region SingletonPattern

        private static SemesterLogRepository SemesterLogRepositoryObj = null;
        private SemesterLogRepository() { }
        public static SemesterLogRepository GetInstance()
        {
            if (SemesterLogRepositoryObj == null)
            {
                SemesterLogRepositoryObj = new SemesterLogRepository();
            }
            return SemesterLogRepositoryObj;
        }

        #endregion

        public Exception GetSemesterLog(ref ICollection<SemesterLog> semesterLogs)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_SEMESTER_LOG.GET_SEMESTER_LOG";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        SemesterLog semesterLog = new SemesterLog();
                        semesterLog = Mapping(oracleDataReader);
                        semesterLogs.Add(semesterLog);
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

        public SemesterLog Mapping(OracleDataReader oracleDataReader)
        {
            SemesterLog semesterLog = new SemesterLog();
            semesterLog.SemesterLogId = Convert.ToByte(oracleDataReader["SEMESTER_LOG_ID"]);
            semesterLog.Semester = Convert.ToChar(oracleDataReader["SEMESTER"]);
            semesterLog.Startdate = Convert.ToDateTime(oracleDataReader["STARTDATE"]);
            semesterLog.Enddate = Convert.ToDateTime(oracleDataReader["ENDDATE"]);
            semesterLog.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return semesterLog;
        }
    }
}
