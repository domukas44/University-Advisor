using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebService.Models;

namespace WebService.Services
{
    public class ReviewRepository : IReviewRepository
    {

        private List<Review> reviewList;
        private readonly SqlConnection cn = new SqlConnection();
        private readonly SqlDataAdapter da;
        private DataSet ds;

        public ReviewRepository()
        {
            // connect to DB, fill data set from DB
            cn.ConnectionString = "Server=GABRIELESLAPTOP\\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
            if (cn.State == ConnectionState.Closed)
                cn.Open();

            SqlCommand cmd = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text
            };

            da = new SqlDataAdapter("SELECT id, subjectname, author, comment, rating FROM reviews", cn);
            ds = new DataSet();
            da.Fill(ds, "reviews");
            //cn.Close();
        }

        public IEnumerable<Review> All
        {
            // gets List<Review> from DB table "reviews"
            get
            {
                return ds.Tables["reviews"].AsEnumerable().Select(row => new Review
                {
                    Id = row.Field<int>("id"),
                    SubjectName = row.Field<string>("subjectname"),
                    Author = row.Field<string>("author"),
                    Comment = row.Field<string>("comment"),
                    Rating = row.Field<int>("rating")
                }).ToList();
            }
        }

        public bool DoesReviewExist(int id)
        {
            return reviewList.Any(review => review.Id == id);
        }

        public Review Find(int id)
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlCommand select = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "SELECT subjectname, author, comment, rating FROM reviews WHERE id = @id;"
            };
            select.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = select.ExecuteReader())
            {
                if (reader.Read())
                {
                    var review = new Review
                    {
                        Id = id,
                        SubjectName = reader["subjectname"].ToString(),
                        Author = reader["author"].ToString(),
                        Comment = reader["comment"].ToString(),
                        Rating = Convert.ToInt32(reader["rating"])
                    };
                    //cn.Close();
                    return review;
                }
            }
            //cn.Close();
            return null;

            // or:
            // return reviewList.Where(review => review.Id == id).FirstOrDefault();
        }

        public void Insert(Review review)
        {
            // inserts review into DB. Resets dataset and reviewList
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlCommand insert = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO reviews (subjectname, author, comment, rating) VALUES (@subjectname, @author, @comment, @rating);"
            };
            insert.Parameters.AddWithValue("@subjectname", review.SubjectName);
            insert.Parameters.AddWithValue("@author", review.Author);
            insert.Parameters.AddWithValue("@comment", review.Comment);
            insert.Parameters.AddWithValue("@rating", review.Rating);
            insert.ExecuteNonQuery();

            ds = new DataSet();
            da.Fill(ds, "reviews");

            reviewList = All.ToList();
            //cn.Close();
        }

        public void Update(Review review)
        {
            // updates a given review's comment and rating in DB. Resets dataset and reviewList
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlCommand update = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "UPDATE reviews SET comment = @comment, rating = @rating WHERE id = @id;"
            };
            update.Parameters.AddWithValue("@id", review.Id);
            update.Parameters.AddWithValue("@comment", review.Comment);
            update.Parameters.AddWithValue("@rating", review.Rating);
            da.UpdateCommand = update;
            da.UpdateCommand.ExecuteNonQuery();

            ds = new DataSet();
            da.Fill(ds, "reviews");

            reviewList = All.ToList();
            //cn.Close();
        }

        public void Delete(int id)
        {
            // deletes review from DB. Resets dataset and reviewList
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SqlCommand delete = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM reviews WHERE id = @id;"
            };
            delete.Parameters.AddWithValue("@id", id);
            delete.ExecuteNonQuery();

            ds = new DataSet();
            da.Fill(ds, "reviews");

            reviewList = All.ToList();
            //cn.Close();
        }

        public void Dispose()
        {
            cn.Close();
        }
    }
}