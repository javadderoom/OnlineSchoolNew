using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;
using Common;

namespace WebPages.Dashboard.Admin
{
    public partial class Lessons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLessons();
            }
        }

        public void LoadLessons()
        {
            LessonsRepository le = new LessonsRepository();
            gvLessons.DataSource = le.GetAllLessons();
            gvLessons.DataBind();

            tbxSearch.Value = "";
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadLessons();
        }

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadLessons();
        }

        protected void btnAddLesson_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:4911/Dashboard/Admin/AddLesson.aspx");
        }

        protected void gvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        private LessonsRepository rep = new LessonsRepository();

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvLessons.Rows[index];
                /////////////////////////////////////////////////////////////////
                ///////////// ADD A MODAL HERE FOR EDITING LESSON ///////////////
                ////////////////////////////////////////////////////////////////
            }
            if (e.CommandName == "Details")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvLessons.Rows[index];

                string id = row.Cells[0].Text;

                if (!(string.IsNullOrEmpty(id)))
                {
                    Lesson lo = rep.FindByLessonID(id.ToInt());
                    tbxLessonID.InnerText = lo.LessonID.ToString();
                    tbxLessonTitle.InnerText = lo.LessonTitle;
                    tbxUnit.InnerText = lo.Unit.ToString();

                    //tbxEmail.Value = lo.Email;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#modalShowDetails').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "ModalScript", sb.ToString(), false);
                }
            }
            if (e.CommandName == "Delet")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvLessons.Rows[index];

                LessonsRepository lr = new LessonsRepository();
                lr.DeleteLesson(row.Cells[0].Text.ToInt());

                LoadLessons();
            }
        }
    }
}