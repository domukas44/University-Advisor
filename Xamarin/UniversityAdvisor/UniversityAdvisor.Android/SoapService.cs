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
        TaskCompletionSource<bool> getRequestComplete = null;
        TaskCompletionSource<bool> saveRequestComplete = null;
        TaskCompletionSource<bool> deleteRequestComplete = null;

        public List<Subject> Subjects { get; private set; } = new List<Subject>();

        public SoapService()
        {
            subjectService = new SubjectWS.SubjectService();
            subjectService.Url = Constants.SoapUrl;

            subjectService.GetSubjectsCompleted += SubjectService_GetSubjectsCompleted;
            subjectService.CreateSubjectCompleted += SubjectService_SaveSubjectCompleted;
            subjectService.EditSubjectCompleted += SubjectService_SaveSubjectCompleted;
            subjectService.DeleteSubjectCompleted += SubjectService_DeleteSubjectCompleted;
        }

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

        public async Task<List<Subject>> RefreshDataAsync()
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
    }
}
