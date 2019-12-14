using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public interface ISubjectRepository
    {
        bool DoesSubjectExist(int id);
        Subject Find(int id);
        Subject Find(string name);
        IEnumerable<Subject> All { get; }
        void Insert(Subject subject);
        void Update(Subject subject);
        void Delete(int id);
        void Dispose();
    }
}
