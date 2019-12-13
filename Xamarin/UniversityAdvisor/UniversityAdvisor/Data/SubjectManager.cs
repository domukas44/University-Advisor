using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Data
{
	public class SubjectManager
	{
		ISoapService soapService;

		public SubjectManager(ISoapService service)
		{
			soapService = service;
		}

		public Task<List<Subject>> GetSubjectsAsync()
		{
			return soapService.RefreshDataAsync();
		}

		public Task SaveSubjectAsync(Subject subject, bool isNew = false)
		{
			return soapService.SaveSubjectAsync(subject, isNew);
		}

		public Task DeleteSubjectAsync(Subject subject)
		{
			return soapService.DeleteSubjectAsync(subject.Id);
		}
	}
}
