using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;

namespace WebPages.Dashboard.Admin
{
    public partial class reportsGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        private void loadGrid()
        {
            GradesRepository gr = new GradesRepository();
            gvGrades.DataSource = gr.getAllGrades();
            gvGrades.DataBind();
        }

        protected void gvGrades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvGrades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGrades.Rows[index];

                string id = row.Cells[0].Text;
                Response.Redirect("http://localhost:4911/Dashboard/Admin/reportsGradesChart.aspx?GradeID=" + row.Cells[0].Text);
            }
        }
    }
}