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
    public class KarnamehRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;
        public KarnamehRepository()
        {
            conn = new Connection();
        }

        public DataTable getStudentKarnamehMahiane(int stuID, string mah)
        {
            string Command = string.Format("select LessonTitle,SessionNum,Unit,Nomre,case ExamType when 0 then N'کتبی' else N'شفاهی' end as exam,FirstName+' '+LastName as teacherFullname,sDate = SUBSTRING(Sessoins.Date,1,4) +'/'+SUBSTRING(Sessoins.Date,5,2)+'/'+SUBSTRING(Sessoins.Date,7,2) from Ozviat inner join LessonGroups on Ozviat.LGID = LessonGroups.LGID inner join Sessoins on Sessoins.LGID = LessonGroups.LGID inner join Nomarat on  Ozviat.OzviatID=Nomarat.OzviatID and Nomarat.SessionID = Sessoins.SessionID left outer join Lessons on LessonGroups.LessonID = Lessons.LessonID left outer join Karmand on LessonGroups.TeacherCode = Karmand.PersonalCode  where LessonGroups.Year = (select top 1 Year from LessonGroups order by Year desc) and StudentCode = {0} and SUBSTRING(Sessoins. Date,5,2) = '{1}' order by LessonTitle,sDate desc", stuID, mah);
            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
    }
}