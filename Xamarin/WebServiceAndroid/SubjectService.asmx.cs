using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebService.Models;
using WebService.Services;

namespace WebService
{
    [WebService(Namespace = "http://www.xamarin.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SubjectService : System.Web.Services.WebService
    {
        static readonly ISubjectService subjectService = new Services.SubjectService(new SubjectRepository());

        [WebMethod]
        public List<Subject> GetSubjects()
        {
            return subjectService.GetData().ToList();
        }

        [WebMethod]
        public Subject GetSubject(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new SoapException("Subject name field is required", SoapException.ClientFaultCode);
                }
                return subjectService.Find(name);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }
        }

        [WebMethod]
        public void CreateSubject(Subject subject)
        {
            try
            {
                if (subject == null || string.IsNullOrWhiteSpace(subject.Name))
                {
                    throw new SoapException("Subject name field is required", SoapException.ClientFaultCode);
                }
                subjectService.InsertData(subject);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }
        }

        [WebMethod]
        public void EditSubject(Subject subject)
        {
            try
            {
                if (subject == null || string.IsNullOrWhiteSpace(subject.Name))
                {
                    throw new SoapException("Subject name field is required", SoapException.ClientFaultCode);
                }
                if (subjectService.Find(subject.Id) != null)
                {
                    subjectService.UpdateData(subject);
                }
                else
                {
                    throw new SoapException("Subject not found", SoapException.ClientFaultCode);
                }
            }
            catch (Exception ex)
            {
                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }
        }

        [WebMethod]
        public void DeleteSubject(int id)
        {
            try
            {
                if (subjectService.Find(id) != null)
                {
                    subjectService.DeleteData(id);
                }
                else
                {
                    throw new SoapException("Subject not found", SoapException.ClientFaultCode);
                }
            }
            catch (Exception ex)
            {
                throw new SoapException("Error", SoapException.ServerFaultCode, ex);
            }
        }
    }
}
