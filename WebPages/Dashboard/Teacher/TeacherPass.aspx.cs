using System;
using System.Linq;
using DataAccess;

namespace WebPages.Dashboard.Teacher
{
    public partial class TeacherPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            SchoolDBEntities db = new SchoolDBEntities();

            Karmand stuu = db.Karmands.Where(p => p.UserName == "karim").Single();
            if (tbxCurrentPassword.Value == stuu.UserPass)
            {
                stuu.UserPass = tbxNewPassword.Value;
                db.SaveChanges();
            }
        }
    }
}