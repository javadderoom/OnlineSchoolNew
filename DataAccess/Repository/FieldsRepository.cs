using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Repository
{
    public class FieldsRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;

        public FieldsRepository()
        {
            conn = new Connection();
        }

        public DataTable getMaghateHaveFieldOfCurrentYear()
        {
            string Command = string.Format("select GradeID,GradeTitle from grades inner join(select distinct RegGrade from StuRegister where EduYear = (select top 1 EduYear from StuRegister order by EduYear desc) and FieldID is not null) tbl on Grades.GradeID = tbl.RegGrade");

            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

    }
}