using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Data
{
    public class SubjectDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SubjectDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Subject>().Wait();
        }

        public Task<List<Subject>> GetItemsAsync()
        {
            return database.Table<Subject>().ToListAsync();
        }

        public Task<Subject> GetItemAsync(int id)
        {
            return database.Table<Subject>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Subject subject)
        {
            if (subject.Id != 0)
            {
                return database.UpdateAsync(subject);
            }
            else
            {
                return database.InsertAsync(subject);
            }
        }

        public Task<int> DeleteItemAsync(Subject subject)
        {
            return database.DeleteAsync(subject);
        }
    }
}
