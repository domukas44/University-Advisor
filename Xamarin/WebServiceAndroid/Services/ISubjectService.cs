using System.Collections.Generic;
using WebService.Models;

namespace WebService.Services
{
    public interface ISubjectService
    {
        bool DoesSubjectExist(int id);
        Subject Find(int id);
        IEnumerable<Subject> GetData();
        void InsertData(Subject subject);
        void UpdateData(Subject subject);
        void DeleteData(int id);
    }
}
