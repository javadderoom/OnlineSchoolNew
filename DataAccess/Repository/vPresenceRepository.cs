using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;

namespace DataAccess.Repository
{
    public class vPresenceRepository
    {
        private Connection conn;

        public vPresenceRepository()
        {
            conn = new Connection();
        }

        public bool? GetPreseceBySessionIDandOzviatID(int id, int oid)
        {
            bool? result = true;
            SchoolDBEntities sd = conn.GetContext();
            result = (from r in sd.Presences
                      where (r.SessionID == id) && (r.OzviatID == oid)

                      select r.Status).FirstOrDefault();

            return result;
        }

        public int GetPreseceIDBySessionIDandOzviatID(int id, int oid)
        {
            int result = 0;
            SchoolDBEntities sd = conn.GetContext();
            result = (from r in sd.Presences
                      where r.SessionID == id && r.OzviatID == oid

                      select r.ID).FirstOrDefault();

            return result;
        }

        public bool? GetisMovajjahBySessionIDandOzviatID(int id, int oid)
        {
            bool? result = true;
            SchoolDBEntities sd = conn.GetContext();
            result = (from r in sd.Presences
                      where r.SessionID == id && r.OzviatID == oid

                      select r.isMovajjah).FirstOrDefault();

            return result;
        }

        public string GetDescriptionBySessionIDandOzviatID(int id, int oid)
        {
            string result = "";
            SchoolDBEntities sd = conn.GetContext();
            result = (from r in sd.Presences
                      where r.SessionID == id && r.OzviatID == oid

                      select r.Description).FirstOrDefault();

            return result;
        }

        public void SavePresenc(Presence presence)
        {
            using (SchoolDBEntities pb = conn.GetContext())
            {
                if (presence.ID > 0)
                {
                    //==== UPDATE ====
                    pb.Presences.Attach(presence);
                    pb.Entry(presence).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    pb.Presences.Add(presence);
                }

                pb.SaveChanges();
            }
        }
    }
}