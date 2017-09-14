using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repository
{
    public class vJavabeTamrinRepository
    {
        private Connection conn;
        SchoolDBEntities sd;

        public vJavabeTamrinRepository()
        {
            conn = new Connection();
            sd = conn.GetContext();
        }

        public int TedadejavabeTamrin(int id)
        {


            string Command = (string.Format(" SELECT count(javabid)FROM dbo.Tamarin left outer join dbo.JavabeTamrin on Tamarin.TamrinID = JavabeTamrin.TamrinID where GroupID = {0}", id));

            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlCommand com = new SqlCommand(Command, myConnection);
            myConnection.Open();
            int cnt = com.ExecuteScalar().ToString().ToInt();
            myConnection.Close();

            return cnt;
        }

        public int countJavabeTamrinByOzviatID(int id)
        {
            int cnt =
                (from r in sd.JavabeTamrins
                 where r.OzviatID == id
                 select r).Count();

            return cnt;
        }

        public int countJavabeTamrinByStuCode_Lgid(int stuID, int lgid)
        {
            string Command = (string.Format("select count(*) as cntAnswer from Ozviat inner join JavabeTamrin on Ozviat.OzviatID = JavabeTamrin.OzviatID inner join Tamarin on Tamarin.TamrinID = JavabeTamrin.TamrinID inner join LessonGroups on LessonGroups.LGID = Tamarin.GroupID where GroupID = {0} and year = (select top 1 year from LessonGroups order by Year desc) and StudentCode = {1}", lgid, stuID));

            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlCommand com = new SqlCommand(Command, myConnection);
            myConnection.Open();
            int cnt = com.ExecuteScalar().ToString().ToInt();
            myConnection.Close();

            return cnt;
        }
        public DataTable getJavabeTamrinInfoByTamrinID_OzviatID(int tamrinid, int ozviatid)
        {
            SchoolDBEntities db = new SchoolDBEntities();
            var query =
                from r in db.JavabeTamrins
                where r.OzviatID == ozviatid && r.TamrinID == tamrinid
                select r;

            return OnlineTools.ToDataTable(query.ToList());
        }
    }
}
