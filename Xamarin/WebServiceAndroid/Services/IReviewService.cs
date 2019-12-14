using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public interface IReviewService
    {
        bool DoesReviewExist(int id);
        Review Find(int id);
        IEnumerable<Review> GetData();
        void InsertData(Review review);
        void UpdateData(Review review);
        void DeleteData(int id);
    }
}
