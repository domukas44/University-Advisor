using System;
using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public class ReviewService :IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }

        public bool DoesReviewExist(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new ArgumentNullException(id.ToString());
            }
            return _repository.DoesReviewExist(id);
        }

        public Review Find(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new ArgumentNullException("id");
            }
            return _repository.Find(id);
        }

        public IEnumerable<Review> GetData()
        {
            return _repository.All;
        }

        public void InsertData(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException("review");
            }
            _repository.Insert(review);
        }

        public void UpdateData(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException("review");
            }
            _repository.Update(review);
        }

        public void DeleteData(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new ArgumentNullException("id");
            }
            _repository.Delete(id);
        }
    }
}