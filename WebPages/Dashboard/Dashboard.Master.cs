using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;

namespace WebPages.Dashboard
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SchoolDBEntities db = new SchoolDBEntities();


            Student stuu = db.Students.Where(p => p.UserName == "mhmmd99").Single();
            imgSideProfile.Src = stuu.Image;

        }
    }
}