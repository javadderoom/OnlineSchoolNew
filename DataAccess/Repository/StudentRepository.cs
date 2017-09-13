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
    public class StudentRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;

        public StudentRepository()
        {
            conn = new Connection();
        }

        public int studentCountbyGradeID(int id)
        {
            int query =
               (from r in db.Students
                where r.CGrade == id
                select r).Count();

            return query;
        }
        public DataTable getStudentsInfoByStuCode(int id)
        {

            string Command = string.Format("select top 1 Students.StudentCode,Students.FirstName +' ' +Students.LastName as fullName,GradeTitle,Class from Students left outer join Fathers on Students.FatherID = Fathers.FatherID left outer join Grades on Students.CGrade = Grades.GradeID left outer join StuRegister on Students.StudentCode = StuRegister.StuCode where StudentCode = '{0}' order by StuRegister.RegID desc", id);
            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
        public double getStudentAverageInCurrentYear(int id, int examType)
        {
            string Command = (string.Format("select avg(cast(nomre as decimal))from Ozviat left outer join LessonGroups on Ozviat.LGID = LessonGroups.LGID left outer join Nomarat on Ozviat.OzviatID = Nomarat.OzviatID where StudentCode = '{0}' and year = (select top 1 EduYear from StuRegister where StudentCode = '{0}' order by RegID desc)and ExamType = {1}", id, examType));

            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlCommand com = new SqlCommand(Command, myConnection);
            myConnection.Open();
            string s = com.ExecuteScalar().ToString();
            if (string.IsNullOrEmpty(s))
                return 0;
            double cnt = Convert.ToDouble(s);
            myConnection.Close();

            return cnt;
        }

        public DataTable getStudentAverageGroupByLGIDByStuCode(int id)
        {
            string Command = string.Format("select LessonTitle, avgNomre, FirstName+' ' + LastName as teacherFullName from(select ozviat.lgid, avg(cast(nomre as decimal)) as avgNomre from Ozviat left outer join LessonGroups on Ozviat.LGID = LessonGroups.LGID left outer join Nomarat on Ozviat.OzviatID = Nomarat.OzviatID where StudentCode = '{0}' and year = (select top 1 EduYear from StuRegister where StudentCode = '{1}' order by RegID desc) group by ozviat.LGID)tbl inner join LessonGroups on tbl.LGID = LessonGroups.LGID inner join Lessons on LessonGroups.LessonID = Lessons.LessonID inner join Karmand on LessonGroups.TeacherCode = Karmand.EID", id, id);
            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public int countStudentsByFieldID_GradeID(int fid, int gid)
        {

            string Command = (string.Format("select count(*) as cntStu from StuRegister where EduYear = (select top 1 EduYear from StuRegister order by EduYear desc)  and FieldID = {0} and RegGrade = {1}", fid, gid));

            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlCommand com = new SqlCommand(Command, myConnection);
            myConnection.Open();
            string s = com.ExecuteScalar().ToString();
            if (string.IsNullOrEmpty(s))
                return 0;
            int cnt = Convert.ToInt32(s);
            myConnection.Close();

            return cnt;
        }
    }
}