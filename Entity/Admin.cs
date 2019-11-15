using System.Collections.Generic;
using System.Linq;

namespace University_advisor.Entity
{
    class Admin : User
    {
        public void DeleteUser(string email)
        {
            List<User> users = GetUserList();
            if((users.Find(x => x.Email == email)) != null)
            {
                var path = @"..\Resources\User.txt";
                var oldLines = System.IO.File.ReadAllLines(path);
                var newLines = oldLines.Select(line => new {
                    Line = line,
                    Words = line.Split(' ')
                })
                .Where(lineInfo => !lineInfo.Words.Contains(email))
                .Select(lineInfo => lineInfo.Line);
                System.IO.File.WriteAllLines(path, newLines);
            }
        }

        public void DeleteReview(Subject subject)
        {
            List<Review> reviews = Review.GetReviewList(subject);
            if ((reviews.Find(x => x.Subject.Id == subject.Id)) != null)
            {
                var path = @"..:\Resources\Reviews.txt";
                var oldLines = System.IO.File.ReadAllLines(path);
                var newLines = oldLines.Select(line => new {
                    Line = line,
                    Words = line.Split(' ')
                })
                .Where(lineInfo => !lineInfo.Words.Contains(subject.Name))
                .Select(lineInfo => lineInfo.Line);
                System.IO.File.WriteAllLines(path, newLines);
            }
        }
    }
}
