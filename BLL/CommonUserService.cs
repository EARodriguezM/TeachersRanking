using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using INFRASTRUCTURE;
using ENTITY.SessionManager;

namespace BLL
{
    public class CommonUserService
    {
        #region SingletonPattern

        private static CommonUserService CommonUserServiceObj = null;
        private CommonUserService() { }
        public static CommonUserService GetInstance()
        {
            if (CommonUserServiceObj == null)
            {
                CommonUserServiceObj = new CommonUserService();
            }
            return CommonUserServiceObj;
        }

        #endregion

        public CommonUser Login(string email, string password)
        {
            var commonUser = new CommonUser();
            Exception exception = CommonUserRepository.GetInstance().Login(email, ref commonUser);
            if (exception != null)
            {
                if (!VerifyPasswordHash(password, commonUser.Password, commonUser.Salt))
                     return null;
            }              
            return commonUser; // auth successful
        }

        public Exception Register(CommonUser commonUser, string password)
        {
            if (UserNotExist(commonUser.Email))
            {
                byte[] passwordHash, salt;
                CreatePasswordHash(password, out passwordHash, out salt);
                commonUser.Password = passwordHash;
                commonUser.Salt = salt;
                Exception exception = CommonUserRepository.GetInstance().Register(ref commonUser);
                return exception;
            }
            else
            {
                return null;
            }
        }

        public bool PasswordRecovery(string email, out string messageError)
        {
            byte[] passwordHash, salt;
            if (CommonUserRepository.GetInstance().PasswordRecovery(email, out passwordHash, out salt))
            {
                if (passwordHash != null && salt != null)
                {
                    using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
                    {
                        string password = Encoding.UTF8.GetChars(hmac.ComputeHash(passwordHash)).ToString();
                        if (SendEmail.GetInstance().RecoveryPassword_SendMail(email, password))
                        {
                            messageError = "Su contraseña se ha nviado correctamente alcorreo";
                            return true;
                        }
                        else
                        {
                            messageError = "Devido a incovenientes no se ha enviado su contraseña al correo obtorgado, intente mas tarde";
                            return false;
                        }
                    }
                    
                }
                else
                {
                    messageError = "Su correo no se encuentra registrado en la base de datos del programa";
                    return false;
                }
            }
            else
            {
                messageError = "Error de conexion con el servidor, intentelo mas tarde";
                return false;
            }

        }

        public Exception UpdateUserInformation(CommonUser newInformation, CommonUserSession oldInformation)
        {
            Exception exception = CommonUserRepository.GetInstance().UpdateUserInformation(oldInformation.Email, newInformation);
            if (exception != null)
            {
                oldInformation = (CommonUserSession)newInformation;
                return null;
            }
            else
            {
                return exception;
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool UserNotExist(string email)
        {
            if (CommonUserRepository.GetInstance().UserNotExist(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Exception GetReviewsByCommonUser(ref CommonUser commonUser)
        {
            return ReviewRepository.GetInstance().GetReviewsByCommonUser(ref commonUser);
        }

    }
}
