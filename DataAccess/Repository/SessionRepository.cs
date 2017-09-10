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
    public class SessionRepository
    {
        private Connection conn;

        public SessionRepository()
        {
            conn = new Connection();
        }

        public string CountSessionsByLGID(int LGID)
        {
            int result = 0;

            SchoolDBEntities DB = new SchoolDBEntities();
            result = DB.Sessoins.Where(p => p.LGID == LGID).Count();

            return (result + 1).ToString();
        }

        public DataTable GetSessionByLGID(int lgid)
        {
            List<Sessoin> result = new List<Sessoin>();

            SchoolDBEntities sd = conn.GetContext();

            IEnumerable<Sessoin> pl =
                from r in sd.Sessoins
                where r.LGID == lgid
                orderby r.SessionID
                select r;

            result = pl.ToList();
            return OnlineTools.ToDataTable(result);
        }

        public int countSessionsByLGID(int id)
        {
            SchoolDBEntities pb = conn.GetContext();
            int query =
                (from r in pb.Sessoins
                 where r.LGID == id
                 select r).Count();

            return query;
        }

        public Sessoin GetSessionsBySessionID(int id)
        {
            SchoolDBEntities sd = conn.GetContext();

            Sessoin pl =
                (from r in sd.Sessoins
                 where r.SessionID == id
                 orderby r.SessionID
                 select r).FirstOrDefault();

            return pl;
        }

        public Boolean SaveSession(Sessoin Session)
        {
            SchoolDBEntities pb = conn.GetContext();

            if (Session.SessionID > 0)
            {
                //==== UPDATE ====
                pb.Sessoins.Attach(Session);
                pb.Entry(Session).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                pb.Sessoins.Add(Session);
            }

            return Convert.ToBoolean(pb.SaveChanges());
        }

        public void DeleteSession(int SID)
        {
            SchoolDBEntities pb = conn.GetContext();

            Sessoin selectedSession = pb.Sessoins.Where(p => p.SessionID == SID).Single();

            if (selectedSession != null)
            {
                pb.Sessoins.Remove(selectedSession);
                pb.SaveChanges();
            }
        }

        public void DeleteSessions(List<int> ID)
        {
            SchoolDBEntities pb = conn.GetContext();

            var selectedSession =
                from r in pb.Sessoins
                join at in ID
                on r.SessionID equals at
                select r;

            foreach (var lGroup in selectedSession)
            {
                pb.Sessoins.Remove(lGroup as Sessoin);
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

                    db.ExecuteCommand("TRUNCATE TABLE Sessoin");
                }
            }
        }

        public int FindLastSessionID()
        {
            int result = 0;

            SchoolDBEntities pb = conn.GetContext();

            result = (from r in pb.Sessoins
                      orderby r.SessionID descending
                      select r.SessionID).FirstOrDefault();

            return result;
        }
    }
}