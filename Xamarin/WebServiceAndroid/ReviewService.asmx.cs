using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebService.Models;
using WebService.Services;

namespace WebService
{
    [WebService(Namespace = "http://www.xamarin.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ReviewService : System.Web.Services.WebService
    {
        static readonly IReviewService reviewService = new Services.ReviewService(new ReviewRepository());

        [WebMethod]
        public List<Review> GetReviews()
        {
            return reviewService.GetData().ToList();
        }

        [WebMethod]
        public void CreateReview(Review review)
        {
            try
            {
                if (review == null || string.IsNullOrWhiteSpace(review.SubjectName) || string.IsNullOrWhiteSpace(review.Author))
                {
                    throw new SoapException("Review subjectname and author fields are required", SoapException.ClientFaultCode);
                }
                reviewService.InsertData(review);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }
        }

        [WebMethod]
        public void EditReview(Review review)
        {
            try
            {
                if (review == null || string.IsNullOrWhiteSpace(review.SubjectName) || string.IsNullOrWhiteSpace(review.Author))
                {
                    throw new SoapException("Review subjectname and author fields are required", SoapException.ClientFaultCode);
                }
                if (reviewService.Find(review.Id) != null)
                {
                    reviewService.UpdateData(review);
                }
                else
                {
                    throw new SoapException("Review not found", SoapException.ClientFaultCode);
                }
            }
            catch (Exception ex)
            {
                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }
        }

        [WebMethod]
        public void DeleteReview(int id)
        {
            try
            {
                if (reviewService.Find(id) != null)
                {
                    reviewService.DeleteData(id);
                }
                else
                {
                    throw new SoapException("Review not found", SoapException.ClientFaultCode);
                }
            }
            catch (Exception ex)
            {
                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }
        }
    }
}
