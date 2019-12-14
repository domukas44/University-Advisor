using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using UniversityAdvisor.Data;
using UniversityAdvisor.Models;

namespace UniversityAdvisor.Droid
{
    public class SoapService : ISoapService
    {
        SubjectWS.SubjectService subjectService;
        ReviewWS.ReviewService reviewService;
        TaskCompletionSource<bool> getRequestComplete = null;
        TaskCompletionSource<bool> saveRequestComplete = null;
        TaskCompletionSource<bool> deleteRequestComplete = null;

        public List<Subject> Subjects { get; private set; } = new List<Subject>();
        public List<Review> Reviews { get; private set; } = new List<Review>();

        public SoapService()
        {
            subjectService = new SubjectWS.SubjectService();
            subjectService.Url = Constants.SubjectSoapUrl;
            subjectService.GetSubjectsCompleted += SubjectService_GetSubjectsCompleted;
            subjectService.CreateSubjectCompleted += SubjectService_SaveSubjectCompleted;
            subjectService.EditSubjectCompleted += SubjectService_SaveSubjectCompleted;
            subjectService.DeleteSubjectCompleted += SubjectService_DeleteSubjectCompleted;

            reviewService = new ReviewWS.ReviewService();
            reviewService.Url = Constants.ReviewSoapUrl;
            reviewService.GetReviewsCompleted += ReviewService_GetReviewsCompleted;
            reviewService.CreateReviewCompleted += ReviewService_SaveReviewCompleted;
            reviewService.EditReviewCompleted += ReviewService_SaveReviewCompleted;
            reviewService.DeleteReviewCompleted += ReviewService_DeleteReviewCompleted;
        }

        #region subjectService
        SubjectWS.Subject ToSubjectWSSubject(Subject subject)
        {
            return new SubjectWS.Subject
            {
                Id = subject.Id,
                Name = subject.Name,
                Rating = subject.Rating,
                ReviewCount = subject.ReviewCount
            };
        }

        static Subject FromSubjectWSSubject(SubjectWS.Subject subject)
        {
            return new Subject
            {
                Id = subject.Id,
                Name = subject.Name,
                Rating = subject.Rating,
                ReviewCount = subject.ReviewCount
            };
        }

        private void SubjectService_GetSubjectsCompleted(object sender, SubjectWS.GetSubjectsCompletedEventArgs e)
        {
            try
            {
                getRequestComplete = getRequestComplete ?? new TaskCompletionSource<bool>();

                Subjects = new List<Subject>();
                foreach (var subject in e.Result)
                {
                    Subjects.Add(FromSubjectWSSubject(subject));
                }
                getRequestComplete?.TrySetResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        private void SubjectService_SaveSubjectCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            saveRequestComplete?.TrySetResult(true);
        }


        private void SubjectService_DeleteSubjectCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            deleteRequestComplete?.TrySetResult(true);
        }

        public async Task<List<Subject>> RefreshSubjectDataAsync()
        {
            getRequestComplete = new TaskCompletionSource<bool>();
            subjectService.GetSubjectsAsync();
            await getRequestComplete.Task;
            return Subjects;
        }

        public async Task SaveSubjectAsync(Subject subject, bool isNew = false)
        {
            try
            {
                var subject1 = ToSubjectWSSubject(subject);
                saveRequestComplete = new TaskCompletionSource<bool>();
                if (isNew)
                {
                    subjectService.CreateSubjectAsync(subject1);
                }
                else
                {
                    subjectService.EditSubjectAsync(subject1);
                }
                await saveRequestComplete.Task;
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteSubjectAsync(int id)
        {
            try
            {
                deleteRequestComplete = new TaskCompletionSource<bool>();
                subjectService.DeleteSubjectAsync(id);
                await deleteRequestComplete.Task;
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }
        #endregion

        #region reviewService
        ReviewWS.Review ToReviewWSReview(Review review)
        {
            return new ReviewWS.Review
            {
                Id = review.Id,
                SubjectName = review.SubjectName,
                Author = review.Author,
                Comment = review.Comment,
                Rating = review.Rating,
            };
        }

        static Review FromReviewWSReview(ReviewWS.Review review)
        {
            return new Review
            {
                Id = review.Id,
                SubjectName = review.SubjectName,
                Author = review.Author,
                Comment = review.Comment,
                Rating = review.Rating,
            };
        }

        private void ReviewService_GetReviewsCompleted(object sender, ReviewWS.GetReviewsCompletedEventArgs e)
        {
            try
            {
                getRequestComplete = getRequestComplete ?? new TaskCompletionSource<bool>();

                Reviews = new List<Review>();
                foreach (var review in e.Result)
                {
                    Reviews.Add(FromReviewWSReview(review));
                }
                getRequestComplete?.TrySetResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        private void ReviewService_SaveReviewCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            saveRequestComplete?.TrySetResult(true);
        }


        private void ReviewService_DeleteReviewCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            deleteRequestComplete?.TrySetResult(true);
        }

        public async Task<List<Review>> RefreshReviewDataAsync()
        {
            getRequestComplete = new TaskCompletionSource<bool>();
            reviewService.GetReviewsAsync();
            await getRequestComplete.Task;
            return Reviews;
        }

        public async Task SaveReviewAsync(Review review, bool isNew = false)
        {
            // saves review and accordingly updates the subject's rating
            try
            {
                var review1 = ToReviewWSReview(review);
                saveRequestComplete = new TaskCompletionSource<bool>();
                if (isNew)
                {
                    reviewService.CreateReviewAsync(review1);
                }
                else
                {
                    reviewService.EditReviewAsync(review1);
                }

                await saveRequestComplete.Task;

                var subject = FromSubjectWSSubject(subjectService.GetSubject(review.SubjectName));
                var ratingSum = subject.Rating * subject.ReviewCount;
                ratingSum += review.Rating;
                subject.ReviewCount++;
                subject.Rating = ratingSum / subject.ReviewCount;

                await SaveSubjectAsync(subject, false);
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteReviewAsync(int id)
        {
            try
            {
                deleteRequestComplete = new TaskCompletionSource<bool>();
                reviewService.DeleteReviewAsync(id);
                await deleteRequestComplete.Task;
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }
        #endregion
    }
}
