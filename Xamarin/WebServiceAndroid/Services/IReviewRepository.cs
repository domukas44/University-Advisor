using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public interface IReviewRepository
    {
        bool DoesReviewExist(int id);
        Review Find(int id);
        IEnumerable<Review> All { get; }
        void Insert(Review review);
        void Update(Review review);
        void Delete(int id);
        void Dispose();
    }
}
