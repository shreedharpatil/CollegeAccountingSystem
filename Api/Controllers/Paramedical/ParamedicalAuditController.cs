

using Business.Facede;
using Business.Facede.Models;
using Business.Facede.Paramedical.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Api.Controllers
{
    public class ParamedicalAuditController : ApiController
    {
        private readonly IQueryFor<Student, IEnumerable<Student>> getAuditDetailsQuery;

        public ParamedicalAuditController()
        {
            getAuditDetailsQuery = new GetAuditDetailsQuery();
        }

        public HttpResponseMessage Get([FromUri] Student student) {
            var students = this.getAuditDetailsQuery.ExecuteQueryWith(student);

            AuditEnvelope auditEnvelope = new AuditEnvelope
            {                
                GovernmentQuota = GetAudit(students, s => s.Quota.Equals("Government", StringComparison.CurrentCultureIgnoreCase)),
                ManagementQuota = GetAudit(students, s => s.Quota.Equals("Management", StringComparison.CurrentCultureIgnoreCase)),
                YearOne = GetAudit(students, s => s.Year.Equals(1)),
                YearTwo = GetAudit(students, s => s.Year.Equals(2)),
                YearThree = GetAudit(students, s => s.Year.Equals(3)),
                Male = GetAudit(students, s => s.Gender.Equals("Male", StringComparison.CurrentCultureIgnoreCase)),
                Female = GetAudit(students, s => s.Gender.Equals("Female", StringComparison.CurrentCultureIgnoreCase)),
            };

            auditEnvelope.MainAuditSummary =new AuditSummary{
                NumberOfStudents = auditEnvelope.GovernmentQuota.AuditSummary.NumberOfStudents + auditEnvelope.ManagementQuota.AuditSummary.NumberOfStudents,
                TotalAdmissionFee = auditEnvelope.GovernmentQuota.AuditSummary.TotalAdmissionFee + auditEnvelope.ManagementQuota.AuditSummary.TotalAdmissionFee,
                TotalDueFee = auditEnvelope.GovernmentQuota.AuditSummary.TotalDueFee + auditEnvelope.ManagementQuota.AuditSummary.TotalDueFee,
                TotalPaidFee = auditEnvelope.GovernmentQuota.AuditSummary.TotalPaidFee + auditEnvelope.ManagementQuota.AuditSummary.TotalPaidFee
            };

            return Request.CreateResponse(HttpStatusCode.OK, auditEnvelope);
        }

        private Audit GetAudit(IEnumerable<Student> students,Func<Student,bool> predicate) {
            var auditDetails = students.Where(predicate);
            AuditSummary auditSummary = new AuditSummary
            {
                NumberOfStudents = auditDetails.Count(),
                TotalAdmissionFee = (double)auditDetails.Sum(p => p.TotalFee),
                TotalDueFee = (double)auditDetails.Sum(p => p.DueFee),
                TotalPaidFee = (double)auditDetails.Sum(p => p.PaidFee)
            };

            Audit audit = new Audit
            {
                AuditSummary = auditSummary,
                AuditDetails = auditDetails
            };

            return audit;
        }
    }
}
