using Business.Facede;
using Business.Facede.Models;
using Business.Facede.Pharmacy.Command;
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
    public class PharmacyFeeController : ApiController
    {
        private readonly ICommandHandler<Student> updateFeeDetailsCommandHandler;

        private readonly ICommandHandler<Student> addFeeDetailsCommandHandler;
        public PharmacyFeeController()
        {
            updateFeeDetailsCommandHandler = new UpdateFeeDetailsCommandHandler();
            addFeeDetailsCommandHandler = new AddFeeDetailsCommandHandler();
        }

        public HttpResponseMessage Post([FromBody] Student student)
        {
            if (student.DueDate == DateTime.MinValue) {
                student.DueDate = null;
            }
            addFeeDetailsCommandHandler.Execute(student);
            return Request.CreateResponse(HttpStatusCode.OK, "Student Fee details are saved successfully.");
        }

        public HttpResponseMessage Put([FromBody] Student student) {
            updateFeeDetailsCommandHandler.Execute(student);
            return Request.CreateResponse(HttpStatusCode.OK, "Student Fee details updated successfully. Please click close button to close modal popup");
        }
    }
}
