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
    public class TeacherRepository
    {
        #region SingletonPattern

        private static TeacherRepository TeacherRepositoryObj = null;
        private TeacherRepository() { }
        public static TeacherRepository GetInstance()
        {
            if (TeacherRepositoryObj == null)
            {
                TeacherRepositoryObj = new TeacherRepository();
            }
            return TeacherRepositoryObj;
        }

        #endregion

        public Exception AddTeacher(Teacher teacher)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_TEACHER.ADD_TEACHER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("TEACHER_ID_PARAMETER", OracleDbType.Byte).Value = teacher.TeacherId;
                oracleCommand.Parameters.Add("FIRST_NAME_PARAMETER", OracleDbType.Varchar2).Value = teacher.FirstName;
                oracleCommand.Parameters.Add("SECOND_NAME_PARAMETER", OracleDbType.Varchar2).Value = teacher.SecondName;
                oracleCommand.Parameters.Add("FIRST_SURNAME_PARAMETER", OracleDbType.Varchar2).Value = teacher.FirstSurname;
                oracleCommand.Parameters.Add("SECOND_SURNAME_PARAMETER", OracleDbType.Varchar2).Value = teacher.SecondSurname;
                oracleCommand.Parameters.Add("IS_UPC_TEACHER_PARAMETER", OracleDbType.Boolean).Value = teacher.IsUpcTeacher;

                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleCommand.ExecuteNonQuery();
                    return exceptionToReturn;

                }
                catch (Exception exception)
                {
                    exceptionToReturn = exception;
                    return exceptionToReturn;
                }
            }
        }

        public Exception GetActiveTeachersList(ref ICollection<Teacher> teachers)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_TEACHER.GET_ACTIVE_TEACHERS_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Teacher teacher = new Teacher();
                        teacher = Mapping(oracleDataReader);
                        teachers.Add(teacher);
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

        public Exception GetAllTeachersList(ref ICollection<Teacher> teachers)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_TEACHER.GET_ALL_TEACHERS_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Teacher teacher = new Teacher();
                        teacher = Mapping(oracleDataReader);
                        teachers.Add(teacher);
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

        public Teacher Mapping(OracleDataReader oracleDataReader)
        {
            Teacher teacher = new Teacher();
            teacher.TeacherId = Convert.ToByte(oracleDataReader["TEACHER_ID"]);
            teacher.FirstName = (string)(oracleDataReader["FIRST_NAME"]);
            teacher.SecondName = (string)oracleDataReader["SECOND_NAME"];
            teacher.FirstSurname = (string)oracleDataReader["FIRST_SURNAME"];
            teacher.SecondSurname = (string)(oracleDataReader["SECOND_SURNAME"]);
            teacher.IsUpcTeacher = Convert.ToBoolean(oracleDataReader["IS_UPC_TEACHER"]);
            teacher.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return teacher;
        }
    }
}
