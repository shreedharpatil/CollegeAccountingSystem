using Business.Facede;
using Business.Facede.Command;
using Business.Facede.Models;
using Business.Facede.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IQueryFor<SearchCriteria, IEnumerable<Student>> getStudentDetailsQuery;

        private readonly IQueryFor<int, IEnumerable<Student>> getStudentFeeDetailsQuery;

        private readonly ICommandHandler<Student> registerStudentDetailsCommandHandler;

        private readonly IQueryAll<string> getStudentIdQuery;

        private readonly IQueryFor<string, Student> getStudentQuery;

        public StudentController()
        {
            getStudentDetailsQuery = new GetStudentDetailsQuery();
            getStudentFeeDetailsQuery = new GetStudentFeeDetailsQuery();
            registerStudentDetailsCommandHandler = new RegisterStudentDetailsCommandHandler();
            getStudentIdQuery = new GetStudentIdQuery();
            getStudentQuery = new GetStudentQuery();
        }

        public HttpResponseMessage Get([FromUri] SearchCriteria searchCriteria) {
            var students = this.getStudentDetailsQuery.ExecuteQueryWith(searchCriteria);
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        public HttpResponseMessage Get(int id)
        {
            var fees = this.getStudentFeeDetailsQuery.ExecuteQueryWith(id);
            return Request.CreateResponse(HttpStatusCode.OK, fees);
        }

        public HttpResponseMessage Get(string studentId)
        {
            var student = this.getStudentQuery.ExecuteQueryWith(studentId);
            if (student != null) {
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No student details found");
            
        }

        public HttpResponseMessage Post([FromBody] Student student) {
            registerStudentDetailsCommandHandler.Execute(student);
            string id = getStudentIdQuery.QueryAll();
            return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Student registration successful. Please note down student id generated is: " + id, Id = id, Name = student.FirstName + "-" + student.LastName });
        }
    }
}

