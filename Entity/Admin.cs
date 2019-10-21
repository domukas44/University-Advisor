using System.Collections.Generic;
using System.Linq;
using University_advisor.Controllers;

namespace University_advisor.Entity
{
    class Admin : User
    {
        public void deleteUser(string email)
        {
            List<User> users = getUserList();
            if((users.Find(x => x.email == email)) != null)
            {
                var path = @"..\..\Resources\User.txt";
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

        public void deleteReview(Subject subject)
        {
            List<Review> reviews = Review.getReviewList(subject);
            if ((reviews.Find(x => x.Subject.Id == subject.Id)) != null)
            {
                var path = @"..\..\Resources\Reviews.txt";
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
