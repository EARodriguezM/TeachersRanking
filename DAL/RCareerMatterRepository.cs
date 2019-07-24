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
    public class RCareerMatterRepository
    {
        #region SingletonPattern

        private static RCareerMatterRepository RCareerMatterRepositoryObj = null;
        private RCareerMatterRepository() { }
        public static RCareerMatterRepository GetInstance()
        {
            if (RCareerMatterRepositoryObj == null)
            {
                RCareerMatterRepositoryObj = new RCareerMatterRepository();
            }
            return RCareerMatterRepositoryObj;
        }

        #endregion

        public Exception GetMatterByCarrer(ref Career career)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_R_CAREER_MATTER.GET_MATTER_BY_CAREER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("CAREER_ID_PARAMETER", OracleDbType.Byte).Value = career.CareerId;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Matter matter = new Matter();
                        matter = MappingMatter(oracleDataReader);
                        career.Matter.Add(matter);
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

        public Exception GetCareerByMatter (ref Matter matter)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_R_CAREER_MATTER.GET_CAREER_BY_MATTER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("MATTER_ID_PARAMETER", OracleDbType.Byte).Value = matter.MatterId;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Career career = new Career();
                        career = MappingCareer(oracleDataReader);
                        matter.Career.Add(career);
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

        public Career MappingCareer(OracleDataReader oracleDataReader)
        {
            Career career = new Career();
            career.CareerId = (string)oracleDataReader["CAREER_ID"];
            career.Name = (string)oracleDataReader["NAME"];
            career.FacultyId = Convert.ToByte(oracleDataReader["FACULTY_ID"]);
            career.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return career;
        }

        public Matter MappingMatter(OracleDataReader oracleDataReader)
        {
            Matter matter = new Matter();
            matter.MatterId = (string)oracleDataReader["MATTER_ID"];
            matter.Name = (string)oracleDataReader["NAME"];
            matter.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return matter;
        }
    }
}
