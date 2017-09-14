using DataAccess.Repository;
using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard.Admin
{
    public partial class reportsGradesChart : System.Web.UI.Page
    {
        private string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["GradeID"];
            if (!IsPostBack)
            {

                setLabels();
                setGrid();


            }
        }


        private void setGrid()
        {
            vReportExamsRepository vr = new vReportExamsRepository();
            gvClasses.DataSource = vr.topClassesByGradeID(id.ToInt());
            gvClasses.DataBind();
        }

        private void setLabels()
        {
            GradesRepository gr = new GradesRepository();
            lblMaghta.InnerText = gr.getGradeTitleByID(id.ToInt());

            StudentRepository s = new StudentRepository();
            lblStudentCount.InnerText = s.studentCountbyGradeID(id.ToInt()).ToString();

            vReportExamsRepository vre = new vReportExamsRepository();
            lblmianginkatbi.InnerText = Convert.ToDouble(vre.getAverageGrade(id.ToInt(), 0)).ToString();
            lblmianginshafahi.InnerText = Convert.ToDouble(vre.getAverageGrade(id.ToInt(), 1)).ToString();
        }

        protected void gvClasses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gozareshNemoodari_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:4911/Dashboard/Admin/GradeChart.aspx");
        }
    }
}