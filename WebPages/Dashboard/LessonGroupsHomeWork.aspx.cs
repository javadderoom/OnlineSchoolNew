using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard
{
    public partial class LessonGroupsHomeWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("stuID", 93124345);
            if (!IsPostBack)
            {
                setGrid();
            }
        }

        private void setGrid()
        {
            vLessonGroupRepository r = new vLessonGroupRepository();
            gvLessonGroups.DataSource = r.getStudentLessonGroups(Session["stuID"].ToString().ToInt());
            gvLessonGroups.DataBind();
        }

        protected void gvLessonGroups_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvLessonGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvLessonGroups_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvLessonGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvLessonGroups.Rows[index];
            Session.Add("LGIDForHomeWork", row.Cells[0].Text);
            Response.Redirect("http://localhost:4911/Dashboard/HomeWork.aspx");
        }
    }
}