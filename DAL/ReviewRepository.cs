using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public class ReviewRepository
    {
        #region SingletonPattern

        private static ReviewRepository ReviewRepositoryObj = null;
        private ReviewRepository() { }
        public static ReviewRepository GetInstance()
        {
            if (ReviewRepositoryObj == null)
            {
                ReviewRepositoryObj = new ReviewRepository();
            }
            return ReviewRepositoryObj;
        }

        #endregion

        public Exception AddReview(Review review)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_REVIEW.ADD_REVIEW";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("TEACHER_ID_PARAMETER", OracleDbType.Byte).Value = review.TeacherId;
                oracleCommand.Parameters.Add("COMMON_USER_ID_PARAMETER", OracleDbType.Long).Value = review.CommonUserId;
                oracleCommand.Parameters.Add("MATTER_ID_PARAMETER", OracleDbType.Varchar2).Value = review.MatterId;
                oracleCommand.Parameters.Add("SEMESTER_ID_PARAMETER", OracleDbType.Byte).Value = review.SemesterId;
                oracleCommand.Parameters.Add("CONTENT_PARAMETER", OracleDbType.NClob).Value = review.Content;
                oracleCommand.Parameters.Add("KNOWLEDGE_PARAMETER", OracleDbType.Byte).Value = review.Knowledge;
                oracleCommand.Parameters.Add("NATURALNESS_PARAMETER", OracleDbType.Byte).Value = review.Naturalness;
                oracleCommand.Parameters.Add("ATTITUDE_PARAMETER", OracleDbType.Byte).Value = review.Attitude;
                oracleCommand.Parameters.Add("MOTIVATION_PRODUCE_PARAMETER", OracleDbType.Byte).Value = review.MotivationProduce;
                oracleCommand.Parameters.Add("MATTER_GUIDELINES_PARAMETER", OracleDbType.Byte).Value = review.MatterGuidelines;
                oracleCommand.Parameters.Add("WEIGHTED_AVERAGE_PARAMETER", OracleDbType.Decimal).Value = review.WeightedAverage;
                oracleCommand.Parameters.Add("IS_ANONYMOUS_PARAMETER", OracleDbType.Boolean).Value = review.IsAnonymous;
                oracleCommand.Parameters.Add("FAIL_ANY_MATTER_PARAMETER", OracleDbType.Boolean).Value = review.FailAnyMatter;
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

        public Exception GetRecentReviews(ref ICollection<Review> reviews)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_REVIEW.GET_RECENT_REVIEW";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Review review = new Review();
                        review = Mapping(oracleDataReader);
                        reviews.Add(review);
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

        public Exception GetReviewsByTeacher(ref Teacher teacher)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_REVIEW.GET_REVIEW_BY_TEACHER";
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
                        Review review = new Review();
                        review = Mapping(oracleDataReader);
                        teacher.Review.Add(review);
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

        public Exception GetReviewsByCommonUser(ref CommonUser commonUser)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_REVIEW.GET_REVIEW_BY_COMMON_USER";
                oracleCommand.CommandType = CommandType.StoredProcedure;
                oracleCommand.Parameters.Add("COMMON_USER_ID", OracleDbType.Long).Value = commonUser.CommonUserId;
                OracleDataReader oracleDataReader;
                Exception exceptionToReturn = null;
                try
                {
                    oracleConnection.Open();
                    oracleDataReader = oracleCommand.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        Review review = new Review();
                        review = Mapping(oracleDataReader);
                        commonUser.Review.Add(review);
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

        public Exception GetReviewsByMatter(ref Matter matter)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_REVIEW.GET_REVIEW_BY_MATTER";
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
                        Review review = new Review();
                        review = Mapping(oracleDataReader);
                        matter.Review.Add(review);
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

        public Exception GetReviewsBySemester(ref SemesterLog semesterLog)
        {
            using (OracleConnection oracleConnection = Connection.GetInstance().ConnectionDB())
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.Connection = oracleConnection;
                oracleCommand.CommandText = "PACK_REVIEW.GET_REVIEW_BY_SEMESTER";
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
                        Review review = new Review();
                        review = Mapping(oracleDataReader);
                        semesterLog.Review.Add(review);
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

        public Review Mapping(OracleDataReader oracleDataReader)
        {
            Review review = new Review();
            review.ReviewId = Convert.ToInt32(oracleDataReader["REVIEW_ID"]);
            review.TeacherId = Convert.ToByte(oracleDataReader["TEACHER_ID"]);
            review.CommonUserId = Convert.ToInt32(oracleDataReader["COMMON_USER_ID"]);
            review.MatterId = (string)oracleDataReader["MATTER_ID"];
            review.SemesterId = Convert.ToByte(oracleDataReader["SEMESTER_ID"]);
            review.Content = (string)oracleDataReader["CONTENT"];
            review.Knowledge = Convert.ToByte(oracleDataReader["KNOWLEDGE"]);
            review.Methodology = Convert.ToByte(oracleDataReader["METHODOLOGY"]);
            review.Naturalness = Convert.ToByte(oracleDataReader["NATURALNESS"]);
            review.Attitude = Convert.ToByte(oracleDataReader["ATTITUDE"]);
            review.MotivationProduce = Convert.ToByte(oracleDataReader["MOTIVATION_PRODUCE"]);
            review.MatterGuidelines = Convert.ToByte(oracleDataReader["MATTER_GUIDELINES"]);
            review.WeightedAverage = Convert.ToDecimal(oracleDataReader["WEIGHTED_AVERAGE"]);
            review.PostDate = Convert.ToDateTime(oracleDataReader["POST_DATE"]);
            review.IsAnonymous = Convert.ToBoolean(oracleDataReader["IS_ANONYMOUS"]);
            review.FailAnyMatter = Convert.ToBoolean(oracleDataReader["FAIL_ANY_MATTER"]);
            review.Status = Convert.ToBoolean(oracleDataReader["STATUS"]);
            return review;
        }

    }
}
