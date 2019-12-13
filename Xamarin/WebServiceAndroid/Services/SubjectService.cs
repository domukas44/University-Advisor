using System;
using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;

        public SubjectService(ISubjectRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }

        public bool DoesSubjectExist(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new ArgumentNullException(id.ToString());
            }
            return _repository.DoesSubjectExist(id);
        }

        public Subject Find(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new ArgumentNullException("id");
            }
            return _repository.Find(id);
        }

        public IEnumerable<Subject> GetData()
        {
            return _repository.All;
        }

        public void InsertData(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException("subject");
            }
            _repository.Insert(subject);
        }

        public void UpdateData(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException("subject");
            }
            _repository.Update(subject);
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