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
    public class vStudentRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;

        public vStudentRepository()
        {
            conn = new Connection();
        }

        public vStudent GetStudentByUsername(string user)
        {
            vStudent stu = db.vStudents.Where(p => p.UserName == user).Single();
            return stu;
        }

        public vStudent FindByNatinalCode(string nationalCode)
        {
            vStudent result = null;

            using (SchoolDBEntities sd = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in sd.vStudents
                          where r.NationalCode == nationalCode
                          select r).FirstOrDefault();
                return result;
            }
        }

        public DataTable searchStudents(string searchtxt, List<string> stuCodes)
        {
            List<string> los = new List<string>();

            SchoolDBEntities sd = conn.GetContext();
            var pl =
                from r in sd.vStudents
                where r.StudentCode.Contains(searchtxt)
                || r.FirstName.Contains(searchtxt)
                || r.LastName.Contains(searchtxt)
                || r.FathersFirstName.Contains(searchtxt)
                || r.GradeTitle.Contains(searchtxt)
                select r.StudentCode;

            los = pl.ToList().Except(stuCodes).ToList();

            List<vStudent> lvs = new List<vStudent>();
            var query = sd.vStudents.Where(v => los.Contains(v.StudentCode));
            lvs = query.ToList();

            return OnlineTools.ToDataTable(lvs);
        }

        public DataTable searchStudents(string searchtxt)
        {
            List<vStudent> lvs = new List<vStudent>();

            SchoolDBEntities sd = conn.GetContext();
            var pl =
                from r in sd.vStudents
                where r.StudentCode.Contains(searchtxt)
                || r.FirstName.Contains(searchtxt)
                || r.LastName.Contains(searchtxt)
                || r.FathersFirstName.Contains(searchtxt)
                || r.GradeTitle.Contains(searchtxt)
                select r;

            lvs = pl.ToList();
            return OnlineTools.ToDataTable(lvs);
        }

        public DataTable searchStudentsInfo(string searchtxt)
        {
            string Command = (string.Format(" select* from vStudentsInfo v where v.StudentCode like N'%{0}%' or v.stuClass like N'%{1}%' or v.GradeTitle like N'%{2}%' or v.fullName like N'%{3}%' or v.FirstName like N'%{4}%'", searchtxt, searchtxt, searchtxt, searchtxt, searchtxt));

            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);

            return dtResult;
        }

        public DataTable GetAllStudentsExceptByGradeID(List<string> stuCodes, int? gid)
        {
            List<string> result1 = new List<string>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<string> pl =
                    from r in sd.vStudents
                    where r.CGrade == gid
                    select r.StudentCode;

                result1 = pl.ToList().Except(stuCodes).ToList();

                List<vStudent> result2 = new List<vStudent>();

                var query = sd.vStudents.Where(v => result1.Contains(v.StudentCode));
                result2 = query.ToList();

                return OnlineTools.ToDataTable(result2);
            }
        }

        public vStudent FindByIdentityCode(string identityCode)
        {
            vStudent result = null;

            using (SchoolDBEntities sd = conn.GetContext())
            {
                //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

                result = (from r in sd.vStudents
                          where r.IdentityCode == identityCode
                          select r).FirstOrDefault();
                return result;
            }
        }

        public Student FindByStudentCode(string id)
        {
            SchoolDBEntities db = new SchoolDBEntities();

            return db.Students.Where(p => p.StudentCode == id).Single();
        }

        public void SaveStudent(Student student)
        {
            using (SchoolDBEntities pb = conn.GetContext())
            {
                if (student.StuID > 0)
                {
                    //==== UPDATE ====
                    pb.Students.Attach(student);
                    pb.Entry(student).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    pb.Students.Add(student);
                }

                pb.SaveChanges();
            }
        }

        public DataTable FindByName(string Name)
        {
            List<vStudent> result = new List<vStudent>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<vStudent> pl =
                    from r in sd.vStudents
                    where r.FirstName.Contains(Name)

                    select r;

                result = pl.ToList();
                return OnlineTools.ToDataTable(result);
            }
        }

        public DataTable FindByFullName(string fullName)
        {
            List<vStudent> result = new List<vStudent>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<vStudent> pl =
                    from r in sd.vStudents
                    where r.FirstName.Contains(fullName) || r.LastName.Contains(fullName)

                    select r;

                result = pl.ToList();
                return OnlineTools.ToDataTable(result);
            }
        }

        public DataTable FindByFullName(string firstName, string lastName)
        {
            List<vStudent> result = new List<vStudent>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<vStudent> pl =
                    from r in sd.vStudents
                    where r.FirstName.Contains(firstName) && r.LastName.Contains(lastName)

                    select r;

                result = pl.ToList();
                return OnlineTools.ToDataTable(result);
            }
        }

        public DataTable FindByBirthDate(string date)
        {
            List<vStudent> result = new List<vStudent>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<vStudent> pl =
                    from r in sd.vStudents
                    where r.BirthDate == date

                    select r;

                result = pl.ToList();
                return OnlineTools.ToDataTable(result);
            }
        }

        public DataTable FindByHand(bool hand)
        {
            List<vStudent> result = new List<vStudent>();

            using (SchoolDBEntities sd = conn.GetContext())
            {
                IEnumerable<vStudent> pl =
                    from r in sd.vStudents
                    where r.Hand == hand

                    select r;

                result = pl.ToList();
                return OnlineTools.ToDataTable(result);
            }
        }

        public DataTable GetAllStudents()
        {
            List<vStudent> result = new List<vStudent>();

            SchoolDBEntities sd = conn.GetContext();

            var pl =
                from r in sd.vStudents
                select r;

            result = pl.ToList();
            return OnlineTools.ToDataTable(result);
        }

        public void DeleteStudent(String stuCode)

        {
            SchoolDBEntities pb = conn.GetContext();

            Student selectedStudent = new Student();
            selectedStudent = pb.Students.Where(p => p.StudentCode == stuCode).Single();

            if (selectedStudent != null)
            {
                pb.Students.Remove(selectedStudent);
                pb.SaveChanges();
            }
        }

        public void DeleteStudents(List<string> StudeCodes)
        {
            SchoolDBEntities pb = conn.GetContext();

            var selectedStudents =
            from r in pb.Students
            join at in StudeCodes
            on r.StudentCode equals at
            select r;

            foreach (var student in selectedStudents)
            {
                pb.Students.Remove(student as Student);
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

                    db.ExecuteCommand("TRUNCATE TABLE Students");
                }
            }
        }

        public DataTable getStudentsInfo()
        {
            string Command = (string.Format("select s.StudentCode,s.FirstName + ' ' + s.LastName as fullName,Fathers.FirstName,s.CGrade, (select top 1 class from Students inner join Ozviat on Students.StudentCode = Ozviat.StudentCode inner join LessonGroups on Ozviat.LGID = LessonGroups.LGID where Students.StudentCode = s.StudentCode order by LessonGroups.LGID desc) as stuClass from Students s left outer join Fathers on s.FatherID = Fathers.FatherID inner join StuRegister on s.StudentCode = StuRegister.StuCode where StuRegister.EduYear = (select top 1 EduYear from StuRegister order by EduYear desc)"));

            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);

            return dtResult;
        }
    }
}