using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;

namespace DataAccess.Repository
{
    public class vNomratRepository
    {
        private Connection conn;

        public vNomratRepository()
        {
            conn = new Connection();
        }

        public string GetNomreBySessionIDandOzviatID(int id, int oid)
        {
            string result = "";
            SchoolDBEntities sd = conn.GetContext();
            result = (from r in sd.Nomarats
                      where r.SessionID == id && r.OzviatID == oid

                      select r.Nomre).FirstOrDefault();

            return result;
        }

        public int GetNomreIDBySessionIDandOzviatID(int id, int oid)
        {
            int result = 0;
            SchoolDBEntities sd = conn.GetContext();
            result = (from r in sd.Nomarats
                      where r.SessionID == id && r.OzviatID == oid

                      select r.NomreID).FirstOrDefault();

            return result;
        }

        public void SaveNomre(Nomarat nomre)
        {
            using (SchoolDBEntities pb = conn.GetContext())
            {
                if (nomre.NomreID > 0)
                {
                    //==== UPDATE ====
                    pb.Nomarats.Attach(nomre);
                    pb.Entry(nomre).State = EntityState.Modified;
                }
                else
                {
                    //==== INSERT ====
                    pb.Nomarats.Add(nomre);
                }

                pb.SaveChanges();
            }
        }
    }
}