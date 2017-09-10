using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Web.Configuration;
using System.Configuration;

namespace DataAccess.Repository
{
    public class OzviatRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;

        public OzviatRepository()
        {
            conn = new Connection();
        }
        public int OzviatIDByLGIDAndStudentCode(int id, string stuCode)
        {
            int result = 0;
            result = db.Ozviats.Where(p => p.LGID == id).Where(p => p.StudentCode == stuCode)
                .Select(p => p.OzviatID).FirstOrDefault();

            return result;
        }
        public DataTable FindByLGID(int lgid)
        {
            List<vOzviat> result = new List<vOzviat>();

            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<vOzviat> pl =
                from r in sd.vOzviats
                where r.LGID == lgid

                select r;

            result = pl.ToList();
            return OnlineTools.ToDataTable(result);
        }
        public int OzviatIDByLGIDAndStudentCode(int LGID, string SCode)
        {
            int result = 0;

            result = db.Ozviats.Where(p => (p.LGID == LGID) && (p.StudentCode == SCode)).Single().OzviatID;

            return result;
        }

        public List<string> FindStudentCodeByLGID(int lgid)
        {
            List<string> result = new List<string>();

            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<string> pl =
                from r in sd.Ozviats
                where r.LGID == lgid

                select r.StudentCode;

            result = pl.ToList();
            return result;
        }

        public vStudent FindvStudent(string stu)
        {
            vStudent result = null;

            SchoolDBEntities sd = conn.GetContext();

            //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

            result = (from r in sd.vStudents
                      where r.StudentCode == stu
                      select r).FirstOrDefault();
            return result;
        }

        public vOzviat FindStudentinOzviat(string stu)
        {
            vOzviat result = null;

            SchoolDBEntities sd = conn.GetContext();

            //--  SELECT * FROM vPhoneList WHERE PhobeID = phoneID

            result = (from r in sd.vOzviats
                      where r.StudentCode == stu
                      select r).FirstOrDefault();
            return result;
        }

        public void DeleteOzviat(int oID)
        {
            SchoolDBEntities pb = conn.GetContext();

            Ozviat selectedOzviat = pb.Ozviats.Where(p => p.OzviatID == oID).SingleOrDefault();

            if (selectedOzviat != null)
            {
                pb.Ozviats.Remove(selectedOzviat);
                pb.SaveChanges();
            }
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

                    db.ExecuteCommand("TRUNCATE TABLE Ozviat");
                }
            }
        }
        public string StudentCountByLGID(int LGID)
        {
            int result = 0;

            result = db.Ozviats.Where(p => p.LGID == LGID).Count();

            return result.ToString();
        }

        public Boolean SaveOzviat(Ozviat oz)
        {
            SchoolDBEntities pb = conn.GetContext();

            if (oz.OzviatID > 0)
            {
                //==== UPDATE ====
                pb.Ozviats.Attach(oz);
                pb.Entry(oz).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                pb.Ozviats.Add(oz);
            }

            return Convert.ToBoolean(pb.SaveChanges());
        }

        public int countStudentsOfLessonGroupByid(int lgid)
        {
            SchoolDBEntities pb = conn.GetContext();
            int query =
                (from r in pb.Ozviats
                 where r.LGID == lgid
                 select r).Count();

            return query;
        }
    }
}