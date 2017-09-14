using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPages.Dashboard.Controllers;
using Common;

namespace WebPages.Dashboard.Admin
{
    public partial class GradeChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["GradeID"];
            GradeChartt.grade = id.ToInt();
        }
    }
}