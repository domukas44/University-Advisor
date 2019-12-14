using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Data
{
	public interface ISoapService
	{
		Task<List<Subject>> RefreshSubjectDataAsync();
		Task SaveSubjectAsync(Subject subject, bool isNew);
		Task DeleteSubjectAsync(int id);

		Task<List<Review>> RefreshReviewDataAsync();
		Task SaveReviewAsync(Review review, bool isNew);
		Task DeleteReviewAsync(int id);
	}
}
