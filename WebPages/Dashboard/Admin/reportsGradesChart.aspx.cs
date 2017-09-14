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
                fillDropDownList();
                setLabels(ddlYear.SelectedItem.Text.ToString());
                setGrid(ddlYear.SelectedItem.Text.ToString());
            }
        }

        private void fillDropDownList()
        {
            vReportExamsRepository v = new vReportExamsRepository();
            List<string> l = v.getYearsList();
            foreach (string s in l)
            {
                ddlYear.Items.Add(s);
            }
        }

        private void setGrid(string year)
        {
            vReportExamsRepository vr = new vReportExamsRepository();
            gvClasses.DataSource = vr.topClassesByGradeID(id.ToInt(), year);
            gvClasses.DataBind();
        }

        private void setLabels(string year)
        {
            GradesRepository gr = new GradesRepository();
            lblMaghta.InnerText = gr.getGradeTitleByID(id.ToInt());

            StudentRepository s = new StudentRepository();
            lblStudentCount.InnerText = s.studentCountbyGradeID(id.ToInt()).ToString();

            vReportExamsRepository vre = new vReportExamsRepository();
            lblmianginkatbi.InnerText = Convert.ToDouble(vre.getAverageGrade(id.ToInt(), 0, year)).ToString();
            lblmianginshafahi.InnerText = Convert.ToDouble(vre.getAverageGrade(id.ToInt(), 1, year)).ToString();
        }

        protected void gvClasses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setLabels(ddlYear.SelectedValue.ToString());
            setGrid(ddlYear.SelectedValue.ToString());
            //Page_Load(null, null);
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:4911/Dashboard/Admin/GradeChart.aspx?GradeID=" + id);
        }
    }
}