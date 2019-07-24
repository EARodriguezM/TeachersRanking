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
    public class CommonUserRepository
    {
        #region SingletonPattern

        private static CommonUserRepository CommonUserRepositoryObj = null;
        private CommonUserRepository() { }
        public static CommonUserRepository GetInstance()
        {
            if (CommonUserRepositoryObj == null)
            {
                CommonUserRepositoryObj = new CommonUserRepository();
            }
            return CommonUserRepositoryObj;
        }

        #endregion

        public Exception Login(string email, ref CommonUser commonUser)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_COMMON_USER.LOGIN";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = email;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        commonUser = Mapping(oracleDataReader);
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

        public Exception Register(ref CommonUser commonUser)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_COMMON_USER.REGISTER_COMMON_USER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("FIRST_NAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.FirstName;
                oracleCommand.Parameters.Add("SECOND_NAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.SecondName;
                oracleCommand.Parameters.Add("FIRST_SURNAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.FirstSurname;
                oracleCommand.Parameters.Add("SECOND_SURNAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.SecondSurname;
                oracleCommand.Parameters.Add("EMAIL_PARAMETER", OracleDbType.Varchar2).Value = commonUser.Email;
                oracleCommand.Parameters.Add("PASSWORD_PARAMETER", OracleDbType.Blob).Value = commonUser.Password;
                oracleCommand.Parameters.Add("SALT_PARAMETER", OracleDbType.Blob).Value = commonUser.Salt;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleCommand.ExecuteNonQuery();
                    oracleConnection.Close();
                    return exceptionToReturn;
                }
                catch (Exception exeption)
                {
                    exceptionToReturn = exeption;
                    oracleConnection.Close();
                    return exceptionToReturn;
                }
            }
        }

        public bool UserNotExist(string email)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_COMMON_USER.CHECK_USER_IS_REGISTERED";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("EMAIL_PARAMETER", OracleDbType.Varchar2).Value = email;
                oracleCommand.Parameters.Add("RETURN_VALUE", OracleDbType.Int32).Direction = ParameterDirection.ReturnValue;
                try
                {
                    oracleConnection.Open();
                    oracleCommand.ExecuteNonQuery();
                    oracleConnection.Close();
                    
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                }
                if (oracleCommand.Parameters["RETURN_VALUE"].Value == null)
                {
                    return false;
                }   
                else
                {
                    return true;
                }
            }
        }

        public bool PasswordRecovery(string email, out byte[] passwordHash, out byte[] salt)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PASSWORD_RECUPERATION";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("EMAIL_PARAMETER", OracleDbType.Varchar2).Value = email;
                oracleCommand.Parameters.Add("PASSWORD_OUT_PARAMETER", OracleDbType.Blob).Direction = ParameterDirection.Output;
                oracleCommand.Parameters.Add("SALT_OUT_PARAMETER", OracleDbType.Blob).Direction = ParameterDirection.Output;
                passwordHash = null;
                salt = null;
                try
                {
                    oracleConnection.Open();
                    oracleCommand.ExecuteNonQuery();
                    passwordHash = (byte[])(oracleCommand.Parameters["PASSWORD_OUT_PARAMETER"].Value);
                    salt = (byte[])(oracleCommand.Parameters["SALT_OUT_PARAMETER"].Value);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public Exception UpdateUserInformation(string email, CommonUser commonUser)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommandObtain = new OracleCommand();
                OracleCommand oracleCommandUpdate = new OracleCommand();
                oracleCommandObtain.Connection = oracleConnection;
                oracleCommandObtain.CommandText = "PACK_COMMON_USER.UPDATE_USER_INFORMARTION";
                oracleCommandObtain.CommandType = CommandType.StoredProcedure;
                oracleCommandUpdate.Parameters.Add("EMAIL_OLD_PARAMETER", OracleDbType.Varchar2).Value = email;
                oracleCommandUpdate.Connection = oracleConnection;
                oracleCommandUpdate.CommandText = "PACK_COMMON_USER.UPDATE_USER_INFORMARTION";
                oracleCommandUpdate.CommandType = CommandType.StoredProcedure;
                oracleCommandUpdate.Parameters.Add("FIRST_NAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.FirstName;
                oracleCommandUpdate.Parameters.Add("SECOND_NAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.SecondName;
                oracleCommandUpdate.Parameters.Add("FIRST_SURNAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.FirstSurname;
                oracleCommandUpdate.Parameters.Add("SECOND_SURNAME_PARAMETER", OracleDbType.Varchar2).Value = commonUser.SecondSurname;
                oracleCommandUpdate.Parameters.Add("EMAIL_NEW_PARAMETER", OracleDbType.Varchar2).Value = commonUser.Email;
                oracleCommandUpdate.Parameters.Add("PASSWORD_PARAMETER", OracleDbType.Blob).Value = commonUser.Password;
                oracleCommandUpdate.Parameters.Add("SALT_PARAMETER", OracleDbType.Blob).Value = commonUser.Salt;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleCommandObtain.ExecuteNonQuery();
                    oracleCommandUpdate.ExecuteNonQuery();
                    oracleConnection.Close();
                    return exceptionToReturn;
                }
                catch (Exception exeption)
                {
                    exceptionToReturn = exeption;
                    oracleConnection.Close();
                    return exceptionToReturn;
                }
            }
        }

        public CommonUser Mapping(OracleDataReader oracleDataReader)
        {
            CommonUser commonUser = new CommonUser();
            commonUser.CommonUserId = Convert.ToInt32(oracleDataReader["COMMON_USER_ID"]);
            commonUser.FirstName = (string)oracleDataReader["FIRST_NAME"];
            commonUser.SecondName = (string)oracleDataReader["SECOND_NAME"];
            commonUser.FirstSurname = (string)oracleDataReader["FIRST_SURNAME"];
            commonUser.SecondSurname = (string)oracleDataReader["SECOND_SURNAME"];
            commonUser.Email = (string)oracleDataReader["EMAIL"];
            commonUser.Password = (byte[])(oracleDataReader["PASSWORD"]);
            commonUser.Salt = (byte[])(oracleDataReader["SALT"]);
            commonUser.IsRegistered = Convert.ToBoolean(oracleDataReader["IS_REGISTERED"]);
            commonUser.UserType = Convert.ToChar(oracleDataReader["USER_TYPE"]);
            return commonUser;

        }
    }
}
