using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int BranchId { get; set; }
        public int Year { get; set; }
        public string Quota { get; set; }
        public string BranchName { get; set; }

        public decimal CourseFee { get; set; }
        public decimal AdmissionFormFee { get; set; }
        public decimal LabFee { get; set; }
        public decimal LibraryFee { get; set; }
        public decimal OtherFee { get; set; }

        public decimal AdmissionFee { get; set; }
        public decimal IdentityCardFee { get; set; }
        public decimal StudentAssociationFee { get; set; }
        public decimal ReadingRoomFee { get; set; }
        public decimal MagazineFee { get; set; }

        public decimal StudentWelfareFundFee { get; set; }
        public decimal TeacherBenefitFundFee { get; set; }
        public decimal SportsFee { get; set; }
        public decimal FineFee { get; set; }
        public decimal AdmissionFineFee { get; set; }

        public decimal TotalFee { get; set; }
        public string Status { get; set; }
        public decimal DueFee { get; set; }
        public decimal PaidFee { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string AdmissionYear { get; set; }
        public string Application { get; set; }

        public decimal PhyciatricFee { get; set; }
        public decimal MedicalFee { get; set; }
        public decimal TransportationFee { get; set; }
        public decimal ExaminationFee { get; set; }
        public decimal HostelFee { get; set; }
        public decimal MessFee { get; set; }
        public decimal BooksFee { get; set; }
        public decimal UniformFee { get; set; }
        public decimal CautionDepositFee { get; set; }

        public decimal HomeExamFee { get; set; }
        public decimal MisFee { get; set; }
        public decimal LabDepositFee { get; set; }
        public decimal StudentAidFundFee { get; set; }
        public decimal JournalFee { get; set; }

        public decimal CollegeSportsFee { get; set; }
        public decimal ApplicationFee { get; set; }
        public decimal MedicalExamFee { get; set; }
        public decimal UnionFee { get; set; }
        public decimal AnnualDayFee { get; set; }
        public decimal ScienceDevelopmentFee { get; set; }
        public decimal UniversityRegistrationFee { get; set; }
        public decimal EligibilityApplicationFee { get; set; }
        public decimal UniversitySportsFee { get; set; }
        public decimal UniversityWelfareFee { get; set; }
        public decimal CarrierGuidenceFundFee { get; set; }
        public decimal CorpusFundFee { get; set; }
        public decimal ArrearFee { get; set; }
        public decimal NssFee { get; set; }
        public decimal CollegeDevelopmentFee { get; set; }
        public decimal UniversitysilverJubileeFee { get; set; }
        public decimal MiscellaneousFee { get; set; }
        public decimal EligibilityFee { get; set; }

        public string Image_Url { get; set; }
    }
}

