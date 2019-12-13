using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Data
{
	public interface ISoapService
	{
		Task<List<Subject>> RefreshDataAsync();

		Task SaveSubjectAsync(Subject subject, bool isNew);

		Task DeleteSubjectAsync(int id);
	}
}
