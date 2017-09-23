using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Nursing.Query
{
    public class GetStudentFeeDetailsQuery : IQueryFor<int,IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(int input)
        {
            var db = Database.Open();
            dynamic fees, branch;

            IEnumerable<Student> students;
            SimpleQuery query = db.NURSINGFEES.All()            
              .Select(
                  db.NURSINGFEES.YEAR.As("Year"),
                  db.NURSINGFEES.TUTION_FEE.As("CourseFee"),
                  db.NURSINGFEES.LAB_FEE.As("LabFee"),
                  db.NURSINGFEES.LIBRARY_FEE.As("LibraryFee"),
                  db.NURSINGFEES.OTHER_FEE.As("OtherFee"),
                  db.NURSINGFEES.ADMISSION_FEE.As("AdmissionFee"),

                  db.NURSINGFEES.PHYCHIATRIC_FEE.As("PhyciatricFee"),
                  db.NURSINGFEES.MEDICAL_FEE.As("MedicalFee"),
                  db.NURSINGFEES.TRANSPORTATION_FEE.As("TransportationFee"),
                  db.NURSINGFEES.EXAMINATION_FEE.As("ExaminationFee"),
                  db.NURSINGFEES.HOSTEL_FEE.As("HostelFee"),
                  db.NURSINGFEES.MESS_FEE.As("MessFee"),
                  db.NURSINGFEES.SPORTS_FEE.As("SportsFee"),
                  db.NURSINGFEES.BOOKS_FEE.As("BooksFee"),
                  db.NURSINGFEES.UNIFORM_FEE.As("UniformFee"),
                  db.NURSINGFEES.CAUTION_DEPOSIT_FEE.As("CautionDepositFee"),
                  db.NURSINGFEES.FEE_PAID.As("PaidFee"),
                  db.NURSINGFEES.DUE_FEE.As("DueFee"),
                  db.NURSINGFEES.DUE_DATE.As("DueDate"),
                  db.NURSINGFEES.STATUS.As("Status"),
                  db.NURSINGFEES.TOTAL_FEE.As("TotalFee"),
                  db.NURSINGFEES.DATE_OF_ADMISSION.As("DateOfAdmission")
              ).Where(db.NURSINGFEES.STUDENT_ID == input);

            students = query.ToList<Student>();
            return students;
        }
    }
}
