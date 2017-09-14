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
    public class vLessonGroupRepository
    {
        private Connection conn;

        public vLessonGroupRepository()
        {
            conn = new Connection();
        }

        public vLessonGroup FindByClass(string clas)
        {
            vLessonGroup result = null;

            using (SchoolDBEntities sd = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in sd.vLessonGroups
                          where r.Class == clas
                          select r).FirstOrDefault();
            }

            return result;
        }

        public DataTable GetLessonGroupsByLGIDList(List<int> list)
        {
            List<vLessonGroup> result = new List<vLessonGroup>();
            foreach (int id in list)
            {
                SchoolDBEntities sd = conn.GetContext();

                IEnumerable<vLessonGroup> pl =
                    from r in sd.vLessonGroups
                    where r.LGID == id
                    orderby r.LGID
                    select r;
                foreach (var item in pl.ToList())
                { result.Add(item); }
            }

            return OnlineTools.ToDataTable(result);
        }

        public List<int> GetClassesOfTeacher(string id)
        {
            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<int> pl =
                from r in sd.LessonGroups
                where r.TeacherCode == id

                select r.LGID;

            return pl.ToList();
        }

        public List<int> GetClassesOfTeacherInYear(string id, string year)
        {
            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<int> pl =
                from r in sd.LessonGroups
                where r.TeacherCode == id && r.Year == year

                select r.LGID;

            return pl.ToList();
        }

        public List<string> GetClassesOfGrade(int grade, string year)
        {
            List<string> result = new List<string>();

            SchoolDBEntities sd = conn.GetContext();

            IQueryable<string> pl =
                from r in sd.LessonGroups
                where r.GradeID == grade && r.Year == year
                select r.Class;

            result = pl.ToList();
            return result;
        }

        public List<int> GetstudentsOfClass(string clas, string year)
        {
            List<int> result = new List<int>();

            SchoolDBEntities sd = conn.GetContext();

            IQueryable<int> pl =
                from r in sd.LessonGroups
                where r.Class == clas && r.Year == year
                select r.LGID;

            result = pl.ToList();
            return result;
        }

        public string GetLastestYear()
        {
            SchoolDBEntities sd = conn.GetContext();

            string pl =
                (from r in sd.vLessonGroups

                 orderby r.Year descending
                 select r.Year).Take(1).FirstOrDefault();

            return pl;
        }

        public List<string> GetStudentCodeOfLessonGroup(int lgid)
        {
            List<string> result = new List<string>();
            SchoolDBEntities sd = conn.GetContext();
            IQueryable<string> pl =
                from r in sd.Ozviats

                where r.LGID == lgid
                select r.StudentCode;
            result = pl.ToList();
            return result;
        }

        public List<string> GetStudentNameOfLessonGroup(int lgid)
        {
            List<string> result = new List<string>();
            SchoolDBEntities sd = conn.GetContext();
            IQueryable<string> pl =
               from r in sd.Ozviats
               join o in sd.Students
               on r.StudentCode equals o.StudentCode
               where r.LGID == lgid
               select o.FirstName + " " + o.LastName;
            result = pl.ToList();
            return result;
        }

        public List<string> GetlistOfAllYears()
        {
            List<string> result = new List<string>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<string> pl =
                    from r in sd.vLessonGroups

                    orderby r.Year
                    select r.Year;

                pl.Distinct();
                result = pl.ToList();
                return result;
            }
        }

        public DataTable GetAllLessonGroups()
        {
            List<vLessonGroup> result = new List<vLessonGroup>();

            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<vLessonGroup> pl =
                from r in sd.vLessonGroups

                orderby r.LGID
                select r;

            result = pl.ToList();
            return OnlineTools.ToDataTable(result);
        }

        public Boolean SaveLessonGroups(LessonGroup lessonGroup)
        {
            SchoolDBEntities pb = conn.GetContext();

            if (lessonGroup.LGID > 0)
            {
                //==== UPDATE ====
                pb.LessonGroups.Attach(lessonGroup);
                pb.Entry(lessonGroup).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                pb.LessonGroups.Add(lessonGroup);
            }

            return Convert.ToBoolean(pb.SaveChanges());
        }

        public vLessonGroup FindByLGID(int id)
        {
            SchoolDBEntities db = new SchoolDBEntities();

            return db.vLessonGroups.Where(p => p.LGID == id).Single();
        }

        public LessonGroup FindFromLgByLGID(int id)
        {
            SchoolDBEntities db = new SchoolDBEntities();

            return db.LessonGroups.Where(p => p.LGID == id).Single();
        }

        public vLessonGroup FindByYear(string year)
        {
            SchoolDBEntities db = new SchoolDBEntities();

            return db.vLessonGroups.Where(p => p.Year == year).Single();
        }

        public List<string> GetTeacher(int lgid)
        {
            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<string> pl =
                from r in sd.LessonGroups
                where r.LGID == lgid

                select r.TeacherCode;

            return pl.ToList();
        }

        public DataTable FindByYeartest(string year)
        {
            List<vLessonGroup> result = new List<vLessonGroup>();

            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<vLessonGroup> pl =
                from r in sd.vLessonGroups
                where r.Year.Contains(year)

                select r;

            result = pl.ToList();
            return OnlineTools.ToDataTable(result);
        }

        public DataTable FindByFullName(string firstName, string lastName)
        {
            List<vLessonGroup> result = new List<vLessonGroup>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<vLessonGroup> pl =
                    from r in sd.vLessonGroups
                    where r.FirstName.Contains(firstName) && r.LastName.Contains(lastName)

                    select r;

                result = pl.ToList();
                return OnlineTools.ToDataTable(result);
            }
        }

        public void DeleteLessonGroup(int EID)
        {
            SchoolDBEntities pb = conn.GetContext();

            LessonGroup selectedLesson = pb.LessonGroups.Where(p => p.LGID == EID).Single();

            if (selectedLesson != null)
            {
                pb.LessonGroups.Remove(selectedLesson);
                pb.SaveChanges();
            }
        }

        public void DeleteLessonGroups(List<int> EIDs)
        {
            SchoolDBEntities pb = conn.GetContext();

            var selectedLGroups =
                from r in pb.LessonGroups
                join at in EIDs
                on r.LGID equals at
                select r;

            foreach (var lGroup in selectedLGroups)
            {
                pb.LessonGroups.Remove(lGroup as LessonGroup);
            }

            pb.SaveChanges();
        }

        public void DeleteAll()
        {
            using (SchoolDBEntities pb = conn.GetContext())
            {
                System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                    WebConfigurationManager.ConnectionStrings as ConnectionStringSettingsCollection;

                if (connectionStrings.Count > 0)
                {
                    System.Data.Linq.DataContext db = new System.Data.Linq.DataContext(connectionStrings["ConnectionString"].ConnectionString);

                    db.ExecuteCommand("TRUNCATE TABLE LessonGroups");
                }
            }
        }

        public DataTable searchLessonsGroups(string text)
        {
            SchoolDBEntities pb = conn.GetContext();
            List<vLessonGroup> llg = new List<vLessonGroup>();
            var query =
                from r in pb.vLessonGroups
                where r.LessonTitle.Contains(text)
                || r.FirstName.Contains(text)
                || r.LastName.Contains(text)
                || r.GradeTitle.Contains(text)
                || r.Year.Contains(text)
                select r;

            llg = query.ToList();
            return OnlineTools.ToDataTable(llg);
        }

        public int? getLessonGroupgardeID(int lgid)
        {
            SchoolDBEntities pb = conn.GetContext();
            int? id =
                (from r in pb.LessonGroups
                 where r.LGID == lgid
                 select r.GradeID).FirstOrDefault();

            return id;
        }

        public DataTable getAllLessonGroupsOfCurrentYear()
        {

            string Command = string.Format("select class,LessonTitle,unit,GradeTitle,Day,Time,Year,FirstName + ' '+LastName as teacherFullName,LGID from LessonGroups left outer join Karmand on LessonGroups.TeacherCode = Karmand.PersonalCode left outer join Lessons on LessonGroups.LessonID = Lessons.LessonID left outer join Grades on LessonGroups.GradeID = Grades.GradeID where year =  (select top 1 EduYear from StuRegister order by EduYear desc)");
            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }
        public DataTable getStudentLessonGroups(int stuID)
        {
            string Command = string.Format("select *,FirstName+' '+LastName as teacherFullname from Ozviat inner join LessonGroups on Ozviat.LGID = LessonGroups.LGID inner join Karmand on LessonGroups.TeacherCode = Karmand.PersonalCode inner join Lessons on LessonGroups.LessonID = Lessons.LessonID where StudentCode = {0} and Year = (select top 1 year from LessonGroups order by Year desc)", stuID);
            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

    }
}