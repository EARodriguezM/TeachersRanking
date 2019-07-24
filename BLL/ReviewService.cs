using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReviewService
    {
        #region SingletonPattern

        private static ReviewService ReviewServiceObj = null;
        private ReviewService() { }
        public static ReviewService GetInstance()
        {
            if (ReviewServiceObj == null)
            {
                ReviewServiceObj = new ReviewService();
            }
            return ReviewServiceObj;
        }

        #endregion

        public Exception AddReview(Review review)
        {
           return ReviewRepository.GetInstance().AddReview(review);
        }

        public Exception GetRecentReviews(ref ICollection<Review> reviews)
        {
            return ReviewRepository.GetInstance().GetRecentReviews(ref reviews);
        }
    }
}
