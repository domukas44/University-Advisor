using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebService.Models;

namespace WebService.Services
{
    public class SubjectRepository : ISubjectRepository
    {
        private List<Subject> subjectList;
        private readonly SqlConnection cn = new SqlConnection();
        private readonly SqlDataAdapter da;
        private DataSet ds;

        public SubjectRepository()
        {
            // connect to DB, fill data set from DB
            cn.ConnectionString = "Server=DESKTOP-MU7GUGU\\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text
            };

            da = new SqlDataAdapter("SELECT id, name, rating, reviewcount FROM subjects", cn);
            cn.Close();
            ds = new DataSet();
            da.Fill(ds, "subjects");
        }

        public IEnumerable<Subject> All
        {
            // gets List<Subject> from DB table "subjects"
            get
            {
                return ds.Tables["subjects"].AsEnumerable().Select(row => new Subject { 
                        Id = row.Field<int>("id"), 
                        Name = row.Field<string>("name"), 
                        Rating = Convert.ToDouble(row.Field<Decimal>("rating")), 
                        ReviewCount = row.Field<int>("reviewcount") 
                }).ToList();
            }
        }

        public bool DoesSubjectExist(int id)
        {
            return subjectList.Any(subject => subject.Id == id);
        }

        public Subject Find(int id)
        {
            cn.Open();
            SqlCommand select = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "SELECT rating FROM subjects WHERE id = @id;"
            };
            select.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = select.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return new Subject { 
                        Id = id, 
                        Name = reader["name"].ToString(), 
                        Rating = Convert.ToDouble(reader["rating"]), 
                        ReviewCount = Convert.ToInt32(reader["reviewcount"]) 
                    };
                }
            }
            return null;

            // or:
            // return subjectList.Where(subject => subject.Id == id).FirstOrDefault();
        }

        public void Insert(Subject subject)
        {
            // inserts subject into DB. Resets dataset and subjectList
            cn.Open();
            SqlCommand insert = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO subjects (name) VALUES (@name);"
            };
            insert.Parameters.AddWithValue("@name", subject.Name);
            insert.ExecuteNonQuery();
            cn.Close();

            ds = new DataSet();
            da.Fill(ds, "subjects");

            subjectList = All.ToList();

            // another way:
            // inserts subject into subjectList, dataset and DB
            /*subjectList.Add(subject);

            var row = ds.Tables[0].NewRow();
            row["id"] = ds.Tables[0].Rows.Count + 1;
            row["name"] = subject.Name;
            row["rating"] = 0;
            row["reviewcount"] = 0;

            cn.Open();
            da.Update(ds.Tables["subjects"]);*/     // update DB using DataAdapter
        }

        public void Update(Subject subject)
        {
            // updates given subject in DB. Resets dataset and subjectList
            cn.Open();
            SqlCommand update = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "UPDATE subjects SET rating = @rating, reviewcount = @reviewcount WHERE id = @id;"
            };
            update.Parameters.AddWithValue("@id", subject.Id);
            update.Parameters.AddWithValue("@rating", subject.Rating);
            update.Parameters.AddWithValue("@reviewcount", subject.ReviewCount);
            da.UpdateCommand = update;
            da.UpdateCommand.ExecuteNonQuery();
            cn.Close();

            ds = new DataSet();
            da.Fill(ds, "subjects");

            subjectList = All.ToList();
        }

        public void Delete(int id)
        {
            // deletes subject from DB. Resets dataset and subjectList
            cn.Open();
            SqlCommand delete = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM subjects WHERE id = @id;"
            };
            delete.Parameters.AddWithValue("@id", id);
            delete.ExecuteNonQuery();
            cn.Close();

            ds = new DataSet();
            da.Fill(ds, "subjects");

            subjectList = All.ToList();
        }
    }
}