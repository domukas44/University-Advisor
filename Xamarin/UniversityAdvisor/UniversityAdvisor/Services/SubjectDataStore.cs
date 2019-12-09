using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Services
{
    public class SubjectDataStore : IDataStore<Subject>
    {
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uniAdv.db3");
        SQLiteConnection db;

        readonly List<Subject> subjects;

        public SubjectDataStore()
        {
            subjects = new List<Subject>()
            {
            };

            db = new SQLiteConnection(_dbPath);
            db.DropTable<Subject>();            // delete line later
            db.CreateTable<Subject>();

            // or add check if already inserted?
            db.InsertAll(subjects);
        }

        public async Task<bool> AddItemAsync(Subject s)
        {
            subjects.Add(s);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Subject s)
        {
            var oldItem = subjects.Where((Subject arg) => arg.Id == s.Id).FirstOrDefault();
            subjects.Remove(oldItem);
            subjects.Add(s);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = subjects.Where((Subject arg) => arg.Id == Convert.ToInt32(id)).FirstOrDefault();
            subjects.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Subject> GetItemAsync(string id)
        {
            return await Task.FromResult(subjects.FirstOrDefault(s => s.Id == Convert.ToInt32(id)));
        }

        public async Task<IEnumerable<Subject>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(subjects);
        }
    }
}