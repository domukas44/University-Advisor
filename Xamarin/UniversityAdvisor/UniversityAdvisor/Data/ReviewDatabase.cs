using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Data
{
    public class ReviewDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ReviewDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Review>().Wait();
        }

        public Task<List<Review>> GetItemsAsync()
        {
            return database.Table<Review>().ToListAsync();
        }

        public Task<Review> GetItemAsync(int id)
        {
            return database.Table<Review>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Review review)
        {
            if (review.Id != 0)
            {
                return database.UpdateAsync(review);
            }
            else
            {
                return database.InsertAsync(review);
            }
        }

        public Task<int> DeleteItemAsync(Review review)
        {
            return database.DeleteAsync(review);
        }
    }
}
