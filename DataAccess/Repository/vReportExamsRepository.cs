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
    public class vReportExamsRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;
        public static string conString = "data source=.;initial catalog=SchoolDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

        public vReportExamsRepository()
        {
            conn = new Connection();
        }

        public decimal? getAverageLessonGroup(int id, int examtype)
        {
            //var query =
            //    from r in db.vReportLessongroups
            //    where r.LGID == id
            //    select r;

            //query.GroupBy(n => new { n.SessionID, n.SessionDate }).Select(p => new { p.Key.SessionID, p.Key.SessionDate, p.Average(s => s.Nomre) });
            //var query =
            //from r in db.vReportLessongroups
            //where r.LGID == id
            //group r.Nomre by new
            //{
            //    r.SessionID,
            //    r.SessionDate
            //} into gs
            //select new
            //{
            //    sessionID = gs.Key.SessionID,
            //    sessionDate = gs.Key.SessionDate,
            //    avg = gs.Average(),
            //};

            //return query.Average(p => p.avg);

            decimal? query = (
            from r in db.vReportExams
            where (r.LGID == id) && r.ExamType == examtype
            select r.Nomre).Average();

            return query;
        }

        public int ExamCountByLGID(int id, int katbiOrShafahi)
        {
            var v = db.vReportExams.Where(p => p.LGID == id).Where(p => p.ExamType == katbiOrShafahi).Select(p => p.SessionID);
            List<int?> l = v.ToList();
            return l.Distinct().Count();
        }

        public DataTable topStudentsAverageByLGID(int id)
        {
            string Command = (string.Format("select tbl.StudentCode , Students.FirstName + ' ' + Students.LastName as FullName,avgNomre,countJavabeTamrin from (select Students.StudentCode, isnull(avg(cast(nomre as decimal)), 0) as avgNomre, count(distinct tamrinid) countJavabeTamrin from Students left outer join Ozviat on Students.StudentCode = Ozviat.StudentCode left outer join Nomarat on Ozviat.OzviatID = Nomarat.OzviatID left outer join JavabeTamrin on Ozviat.OzviatID = JavabeTamrin.OzviatID where LGID = {0} group by Students.StudentCode )tbl inner join Students on tbl.StudentCode = Students.StudentCode order by avgNomre desc", id));

            SqlConnection myConnection = new SqlConnection(conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);

            return dtResult;
        }

        public decimal? getAverageGrade(int id, int examtype, string year)
        {
            decimal? query = (
           from r in db.vReportExams
           where (r.CGrade == id) && r.ExamType == examtype && r.Year == year
           select r.Nomre).Average();

            return query;
        }

        public DataTable topClassesByGradeID(int id, string year)
        {
            string Command = string.Format("select Class, avg(Nomre) as avgNomre  from vReportExams v where CGrade = {0} and v.Year = '{1}' group by Class order by avgNomre desc", id, year);
            SqlConnection myConnection = new SqlConnection(conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        #region chart

        public List<decimal?> GetAvgOfClassPerMonth(string cls)
        {
            List<decimal?> result = new List<decimal?>();

            SchoolDBEntities sd = conn.GetContext();
            IQueryable<decimal?> pl =
                from r in sd.vAvgPerMonths
                where r.Class == cls
                orderby r.ID
                select r.miangin;

            result = pl.ToList();
            return result;
        }

        public List<decimal?> GetAvgOfStudentPerMonth(string stu)
        {
            List<decimal?> result = new List<decimal?>();

            SchoolDBEntities sd = conn.GetContext();
            IQueryable<decimal?> pl =
                from r in sd.vAvgStudentPerMonths
                where r.StudentCode == stu
                orderby r.ID
                select r.AvgNomre;

            result = pl.ToList();
            return result;
        }

        public List<string> GetClassMonthForChart(string cls)
        {
            List<string> result = new List<string>();

            SchoolDBEntities sd = conn.GetContext();
            IQueryable<string> pl =
                from r in sd.vAvgPerMonths
                where r.Class == cls
                orderby r.ID
                select r.mnth;
            result = pl.ToList();
            return result;
        }

        public List<string> GetStudentMonthForChart(string stu)
        {
            List<string> result = new List<string>();

            SchoolDBEntities sd = conn.GetContext();
            IQueryable<string> pl =
                from r in sd.vAvgStudentPerMonths
                where r.StudentCode == stu
                orderby r.ID
                select r.mnth;
            result = pl.ToList();
            return result;
        }

        #endregion chart

        public List<decimal?> getStudentNomreByStuCode(string id, int examType, int lgid)
        {
            var query
                =
                from r in db.vReportExams
                where r.StudentCode == id && r.ExamType == examType && r.LGID == lgid
                orderby r.SessionID
                select r.Nomre;

            return query.ToList();
        }

        public List<string> getSessionDates(int lgid)
        {
            var v =
                from r in db.vReportExams
                where r.LGID == lgid
                orderby r.SessionID
                select r.SessionDate;
            return v.ToList();
        }

        public List<string> getYearsList()
        {
            var v =
                from r in db.vReportExams
                orderby r.Year descending
                select r.Year;
            List<string> l = v.ToList();
            return l.Distinct().ToList();
        }
    }
}