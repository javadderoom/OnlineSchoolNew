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
    public class TamrinRepository
    {
        private Connection conn;
        SchoolDBEntities sd;

        public TamrinRepository()
        {
            conn = new Connection();
            sd = conn.GetContext();
        }

        public int countTamrinByid(int id)
        {
            int query =
               (from r in sd.Tamarins
                where r.GroupID == id
                select r).Count();

            return query;
        }

        public DataTable getLessonGroupTamrins(int lgid)
        {
            string Command = string.Format("select *,dStartDate = SUBSTRING(startDate,1,4) + '/' +SUBSTRING(startDate,5,2) + '/' +SUBSTRING(startDate,7,2),dExpirationDate = SUBSTRING(ExpirationDate,1,4) + '/' +SUBSTRING(ExpirationDate,5,2) + '/' +SUBSTRING(ExpirationDate,7,2)  from Tamarin where groupid = {0}", lgid);
            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }

        public DataTable getTamrinInfo(int tamrinid)
        {

            string Command = string.Format("select *,sdate = SUBSTRING(startdate,1,4) + '/'+SUBSTRING(startdate,5,2) + '/'+SUBSTRING(startdate,7,2), edate = SUBSTRING(ExpirationDate,1,4) + '/'+SUBSTRING(ExpirationDate,5,2) + '/'+SUBSTRING(ExpirationDate,7,2)  from Tamarin where TamrinID = {0}", tamrinid);
            SqlConnection myConnection = new SqlConnection(vReportExamsRepository.conString);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(Command, myConnection);
            DataTable dtResult = new DataTable();
            myDataAdapter.Fill(dtResult);
            return dtResult;
        }




    }
}
