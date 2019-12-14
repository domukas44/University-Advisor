using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Data
{
    public class ReviewManager
    {
		readonly ISoapService soapService;

		public ReviewManager(ISoapService service)
		{
			soapService = service;
		}

		public Task<List<Review>> GetReviewsAsync()
		{
			return soapService.RefreshReviewDataAsync();
		}

		public Task SaveReviewAsync(Review review, bool isNew = false)
		{
			// saves review and accordingly updates the subject's rating
			return soapService.SaveReviewAsync(review, isNew);
		}

		public Task DeleteReviewAsync(Review review)
		{
			return soapService.DeleteReviewAsync(review.Id);
		}
	}
}
