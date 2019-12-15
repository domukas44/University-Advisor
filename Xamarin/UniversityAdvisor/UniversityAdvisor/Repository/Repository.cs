using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Repository
{
    public class Repository
    {
        public List<Subject> GetSubjects()
        {
            return App.Context.Subjects.ToList();
        }

        public List<Review> GetReviews()
        {
            return App.Context.Reviews.ToList();
        }

        public void InsertSubject(string name)
        {
            App.Context.Subjects.Add(new Subject
            {
                Name = name,
                Rating = 0
            });
            App.Context.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            App.Context.Entry(subject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            App.Context.SaveChanges();
        }

        public void DeleteSubject(Subject subject)
        {
            App.Context.Subjects.Remove(subject);
            App.Context.SaveChanges();
        }

        public List<(int id, double rating)> GetSubjectRatings()
        {
            var ratings = App.Context.Subjects.Join(
                App.Context.Reviews,
                s => s.Name,
                r => r.SubjectName,
                (s, r) => new { s.Id, r.Rating })
                .GroupBy(s => s.Id)
                .Select(g => new { g.Key, Rating = g.Average(x => x.Rating) });

            List<(int, double)> ret = new List<(int, double)>();
            foreach(var r in ratings)
            {
                ret.Add((r.Key, r.Rating));
            }

            return ret;
        }

        public List<int> GetTopSubjects(int top)
        {
            return GetSubjectRatings()
                .OrderBy(x => x.rating)
                .Select(x => x.id)
                .Take(top).ToList();
        }

        public List<Review> GetPaginatedReviews(int perPage, int page)
        {
            return App.Context.Reviews.Skip(perPage * (page - 1)).Take(perPage).ToList();
        }
    }
}
