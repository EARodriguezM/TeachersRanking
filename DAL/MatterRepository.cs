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
    public class MatterRepository
    {
        #region SingletonPattern

        private static MatterRepository MatterRepositoryObj = null;
        private MatterRepository() { }
        public static MatterRepository GetInstance()
        {
            if (MatterRepositoryObj == null)
            {
                MatterRepositoryObj = new MatterRepository();
            }
            return MatterRepositoryObj;
        }

        #endregion

        public Exception GetAllMattersList(ref ICollection<Matter> matters)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_MATTER.GET_ALL_MATTERS_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Matter matter = new Matter();
                        matter = Mapping(oracleDataReader);
                        matters.Add(matter);
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

        public Exception GetActiveMattersList(ref ICollection<Matter> matters)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_MATTER.GET_ACTIVE_MATTERS_LIST";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Matter matter = new Matter();
                        matter = Mapping(oracleDataReader);
                        matters.Add(matter);
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

        public Matter Mapping(OracleDataReader oracleDataReader)
        {
            Matter matter = new Matter();
            matter.MatterId = (string)(oracleDataReader["MATTER_ID"]);
            matter.Name = (string)(oracleDataReader["NAME"]);
            matter.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return matter;
        }
    }
}
