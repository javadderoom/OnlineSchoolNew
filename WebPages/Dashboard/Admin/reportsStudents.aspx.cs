using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard.Admin
{
    public partial class reportsStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setGrid();
            }
        }

        private void setGrid()
        {
            vStudentRepository v = new vStudentRepository();
            gvStudents.DataSource = v.getStudentsInfo();
            gvStudents.DataBind();
        }

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvStudents.Rows[index];

            Response.Redirect("http://localhost:4911/Dashboard/Admin/reportsStudentsChart.aspx?stuCode=" + row.Cells[0].Text);
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            vStudentRepository v = new vStudentRepository();
            gvStudents.DataSource = v.searchStudentsInfo(tbxSearch.Value);
            gvStudents.DataBind();
        }

        protected void btnViewAll_ServerClick(object sender, EventArgs e)
        {
            setGrid();
        }
    }
}