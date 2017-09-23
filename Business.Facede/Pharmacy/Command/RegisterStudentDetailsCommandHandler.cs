using Business.Facede.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Pharmacy.Command
{
    public class RegisterStudentDetailsCommandHandler : ICommandHandler<Student>
    {
        private string[] Photos = new string[]{
            "photo1.jpg", "photo2.png", "photo3.jpg", "photo4.png", "photo5.jpg",
        "photo6.png", "photo7.jpg", "photo8.png", "photo9.png", "photo10.jpg"
        };

        private string GetDefaultPhoto()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, 10);
            if (index >= 0 && index < 10)
            {
                return Photos[index];
            }

            return Photos[0];
        }


        public void Execute(Student command)
        {
            var db = Database.Open();
            db.PHARMACYSTUDENTS.Insert(
                NAME: command.FirstName + ", " + command.LastName,
                FATHERNAME: command.FatherName,
                ADDRESS: command.Address,
                CONTACT_NUMBER: command.ContactNumber,
                GENDER: command.Gender,
                BRANCH_ID: command.BranchId,
                QUOTA: command.Quota,
                DATE_OF_REGISTRATION: DateTime.Today,
                IMAGE_URL: "/photos/default/" + GetDefaultPhoto()
                );
        }
    }
}
