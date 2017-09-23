using Business.Facede.Models;
using MySql.Data.MySqlClient;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede.Query
{
    public class GetStudentDetailsQuery : IQueryFor<SearchCriteria, IEnumerable<Student>>
    {
        public IEnumerable<Student> ExecuteQueryWith(SearchCriteria input)
        {
            string query;
            if (input.Criteria == "1") {
                query = "select st.id,st.name,st.fathername,st.address,st.gender,st.contact_number, st.quota, br.name as branch_name,st.branch_id, st.image_url  from DIPLOMASTUDENTS st, branch br where st.branch_id = br.id and st.branch_id = '" + input.BranchId + "' and st.quota = '" + input.Quota + "' and st.id in ("
            + "select student_id from diplomafees where year_of_admission = '" + input.AdmissionYear + "')";
            }
            else if (input.Criteria == "2")
            {
                query = "select st.id,st.name,st.fathername,st.address,st.gender,st.contact_number, st.quota, br.name as branch_name,st.branch_id, st.image_url  from DIPLOMASTUDENTS st, branch br where st.branch_id = br.id and st.branch_id = '" + input.BranchId + "'and st.id in ("
       + "select student_id from diplomafees where year_of_admission = '" + input.AdmissionYear + "' and year='" + input.Year + "')";
            }
            else {
                query = "select st.id,st.name,st.address,st.fathername,st.gender,st.contact_number, st.quota, br.name as branch_name,st.branch_id, st.image_url  from DIPLOMASTUDENTS st, branch br where st.branch_id = br.id and st.name like '%" + input.Name + "%' and gender = '" + input.Gender + "' and st.quota = '" + input.Quota + "'";
            }

            return Criteria(query);            
        }

        private IList<Student> Criteria(string query) {           

            MySqlConnection mysqlcon = new MySqlConnection(ConfigurationManager.AppSettings["connectionString"]);
            //MySqlCommand cmd;

            MySqlCommand cmd = new MySqlCommand(query, mysqlcon);
            mysqlcon.Open();
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            IList<Student> studs = new List<Student>();
            Student st;
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                st = new Student();
                st.Id = int.Parse(dataReader["ID"].ToString());
                st.Name = dataReader["NAME"].ToString();
                st.FatherName = dataReader["FATHERNAME"].ToString();
                st.Address = dataReader["ADDRESS"].ToString();
                st.Gender = dataReader["GENDER"].ToString();
                st.ContactNumber = dataReader["CONTACT_NUMBER"].ToString();
                st.Quota = dataReader["QUOTA"].ToString();
                st.BranchName = dataReader["BRANCH_NAME"].ToString();
                st.BranchId = int.Parse(dataReader["BRANCH_ID"].ToString());
                st.ImageUrl = dataReader["IMAGE_URL"].ToString();
                studs.Add(st);
            }
            dataReader.Close();
            mysqlcon.Close();
            return studs;
        }        
    }

}

