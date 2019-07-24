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
    public class CareerRepository
    {
        #region SingletonPattern

        private static CareerRepository CareerRepositoryObj = null;
        private CareerRepository() { }
        public static CareerRepository GetInstance()
        {
            if (CareerRepositoryObj == null)
            {
                CareerRepositoryObj = new CareerRepository();
            }
            return CareerRepositoryObj;
        }

        #endregion

        public Exception GetAllCareersList(ref ICollection<Career> careers)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_CAREER.GET_ALL_CAREERS_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Career career = new Career();
                        career = Mapping(oracleDataReader);
                        careers.Add(career);
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

        public Exception GetActiveCareersList(ref ICollection<Career> careers)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_CAREER.GET_ACTIVE_CAREERS_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Career career = new Career();
                        career = Mapping(oracleDataReader);
                        careers.Add(career);
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

        public Exception GetCareersByFaculty(ref Faculty faculty)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_CAREER.GET_CAREERS_BY_FACULTY";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("FACULTY_ID_PARAMETER", OracleDbType.Byte).Value = faculty.FacultyId;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Career career = new Career();
                        career = Mapping(oracleDataReader);
                        faculty.Career.Add(career);
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

        public Career Mapping(OracleDataReader oracleDataReader)
        {
            Career career = new Career();
            career.CareerId = (string)(oracleDataReader["CAREER_ID"]);
            career.Name = (string)(oracleDataReader["NAME"]);
            career.FacultyId = Convert.ToByte(oracleDataReader["FACULTY_ID"]);
            career.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return career;
        }
    }
}
