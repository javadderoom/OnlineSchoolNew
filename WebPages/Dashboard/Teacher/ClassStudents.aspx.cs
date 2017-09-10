using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard.Teacher
{
    public partial class ClassStudents : System.Web.UI.Page
    {
        public void loadLessonGroup()
        {

            if (Session["LGIDforStudentsFromClassManagment"] != null)
            {
                string id = Session["LGIDforStudentsFromClassManagment"].ToString();
                Session.Remove("LGIDforStudentsFromClassManagment");
                OzviatRepository rep = new OzviatRepository();
                gvClassStudents.DataSource = rep.FindByLGID(id.ToInt());
                gvClassStudents.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Teacher/News.aspx'", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { loadLessonGroup(); }
        }
    }
}