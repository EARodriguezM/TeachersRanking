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
    public class RTeacherMatterRepository
    {
        #region SingletonPattern

        private static RTeacherMatterRepository RTeacherMatterRepositoryObj = null;
        private RTeacherMatterRepository() { }
        public static RTeacherMatterRepository GetInstance()
        {
            if (RTeacherMatterRepositoryObj == null)
            {
                RTeacherMatterRepositoryObj = new RTeacherMatterRepository();
            }
            return RTeacherMatterRepositoryObj;
        }

        #endregion

        public Exception AddRTeacherMatter(string matterId, byte semesterLogId, byte teacherId)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_R_TEACHER_MATTER.ADD_R_TEACHER_MATTER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("TEACHER_ID_PARAMETER", OracleDbType.Byte).Value = teacherId;
                oracleCommand.Parameters.Add("MATTER_ID_PARAMETER", OracleDbType.Varchar2).Value = matterId;
                oracleCommand.Parameters.Add("SEMESTER_ID_PARAMETER", OracleDbType.Byte).Value = semesterLogId;
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

        public Exception GetTeachersByMatterFilterBySemester(ref Matter matter, byte semesterLogId)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_R_TEACHER_MATTER.GET_TEACHERS_BY_MATTER_FILTER_BY_SEMESTER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("MATTER_ID_PARAMETER", OracleDbType.Varchar2).Value = matter.MatterId;
                oracleCommand.Parameters.Add("SEMESTER_ID_PARAMETER", OracleDbType.Byte).Value = semesterLogId;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Teacher teacher = new Teacher();
                        teacher = MappingTeacher(oracleDataReader);
                        matter.Teacher.Add(teacher);
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

        public Exception GetMattersByTeacherFilterBySemester(ref Teacher teacher, byte semesterLogId)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_R_TEACHER_MATTER.GET_MATTERS_BY_TEACHER_FILTER_BY_SEMESTER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("TEACHER_ID_PARAMETER", OracleDbType.Byte).Value = teacher.TeacherId;
                oracleCommand.Parameters.Add("SEMESTER_ID_PARAMETER", OracleDbType.Byte).Value = semesterLogId;
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
                        teacher.Matter.Add(matter);
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

        public Exception GetTeachersByMatter(ref Matter matter)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_R_TEACHER_MATTER.GET_TEACHERS_BY_MATTER";
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
                        Teacher teacher = new Teacher();
                        teacher = MappingTeacher(oracleDataReader);
                        matter.Teacher.Add(teacher);
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

        public Exception GetMattersByTeacher(ref Teacher teacher)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_R_TEACHER_MATTER.GET_MATTERS_BY_TEACHER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("TEACHER_ID_PARAMETER", OracleDbType.Byte).Value = teacher.TeacherId;
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
                        teacher.Matter.Add(matter);
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

        public Matter MappingMatter(OracleDataReader oracleDataReader)
        {
            Matter matter = new Matter();
            matter.MatterId = (string)(oracleDataReader["MATTER_ID"]);
            matter.Name = (string)(oracleDataReader["NAME"]);
            matter.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return matter;
        }

        public Teacher MappingTeacher(OracleDataReader oracleDataReader)
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
