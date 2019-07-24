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
    public class ScoreRepository
    {
        #region SingletonPattern

        private static ScoreRepository ScoreRepositoryObj = null;
        private ScoreRepository() { }
        public static ScoreRepository GetInstance()
        {
            if (ScoreRepositoryObj == null)
            {
                ScoreRepositoryObj = new ScoreRepository();
            }
            return ScoreRepositoryObj;
        }

        #endregion

        public Exception GetScores(ref ICollection<Score> scores)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_SCORE.GET_SCORES";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Score score = new Score();
                        score = Mapping(oracleDataReader);
                        scores.Add(score);
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

        public Exception GetScoresByTeacher(ref Teacher teacher)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_SCORE.GET_SCORES_BY_TEACHER";
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
                        Score score = new Score();
                        score = Mapping(oracleDataReader);
                        teacher.Score.Add(score);
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

        public Exception GetScoresBySemester(ref SemesterLog semesterLog)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_SCORE.GET_SCORES_BY_SEMESTER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("SEMESTER_ID_PARAMETER", OracleDbType.Byte).Value = semesterLog.SemesterLogId;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Score score = new Score();
                        score = Mapping(oracleDataReader);
                        semesterLog.Score.Add(score);
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

        public Score Mapping(OracleDataReader oracleDataReader)
        {
            Score score = new Score();
            score.ScoreId = Convert.ToInt32(oracleDataReader["SCORE_ID"]);
            score.TeacherId = Convert.ToByte(oracleDataReader["TEACHER_ID"]);
            score.SemesterId = Convert.ToByte(oracleDataReader["SEMESTER_ID"]);
            score.Knowledge = Convert.ToDecimal(oracleDataReader["KNOWLEDGE"]);
            score.Methodology = Convert.ToDecimal(oracleDataReader["METHODOLOGY"]);
            score.Naturalness = Convert.ToDecimal(oracleDataReader["NATURALNESS"]);
            score.Attitude = Convert.ToDecimal(oracleDataReader["ATTITUDE"]);
            score.MotivationProduce = Convert.ToDecimal(oracleDataReader["MOTIVATION_PRODUCE"]);
            score.MatterGuidelines = Convert.ToDecimal(oracleDataReader["MATTER_GUIDELINES"]);
            score.FinalScore = Convert.ToDecimal(oracleDataReader["FINAL_SCORE"]);
            return score;
        }
    }
}
