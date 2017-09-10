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