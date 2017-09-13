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
    public class JavabeTamrinRepository
    {
        private SchoolDBEntities db = new SchoolDBEntities();
        private Connection conn;

        public JavabeTamrinRepository()
        {
            conn = new Connection();
        }





        public void DeleteJavabeTamrin(int ID)
        {
            SchoolDBEntities pb = conn.GetContext();

            JavabeTamrin selectedJavab = pb.JavabeTamrins.Where(p => p.JavabID == ID).SingleOrDefault();

            if (selectedJavab != null)
            {
                pb.JavabeTamrins.Remove(selectedJavab);
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

                    db.ExecuteCommand("TRUNCATE TABLE JavabeTamrin");
                }
            }
        }



        public Boolean SaveJavabeTamrin(JavabeTamrin oz)
        {
            SchoolDBEntities pb = conn.GetContext();

            if (oz.JavabID > 0)
            {
                //==== UPDATE ====
                pb.JavabeTamrins.Attach(oz);
                pb.Entry(oz).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                pb.JavabeTamrins.Add(oz);
            }

            return Convert.ToBoolean(pb.SaveChanges());
        }


    }
}