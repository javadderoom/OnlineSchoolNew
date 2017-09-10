using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Repository;
using DataAccess;

namespace WebPages.Dashboard.Teacher
{
    public partial class ClassManagment : System.Web.UI.Page
    {
        public void gvLoad()
        {
            vLessonGroupRepository vRep = new vLessonGroupRepository();
            List<int> ClassesOfTeacherList = vRep.GetClassesOfTeacher("11111");

            gvClasses.DataSource = vRep.GetLessonGroupsByLGIDList(ClassesOfTeacherList);
            gvClasses.DataBind();
            foreach (GridViewRow row in gvClasses.Rows)
            {
                switch (row.Cells[3].Text)
                {
                    case "1":
                        row.Cells[3].Text = "شنبه";
                        break;

                    case "2":
                        row.Cells[3].Text = "یک شنبه";
                        break;

                    case "3":
                        row.Cells[3].Text = "دوشنبه";
                        break;

                    case "4":
                        row.Cells[3].Text = "سه شنبه";
                        break;

                    case "5":
                        row.Cells[3].Text = "چهارشنبه";
                        break;

                    case "6":
                        row.Cells[3].Text = "پنج شنبه";
                        break;

                    case "7":
                        row.Cells[3].Text = "جمعه";
                        break;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvLoad();
            }
        }

        protected void gvClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvClasses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Students")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvClasses.Rows[index];
                Session.Add("LGIDforStudentsFromClassManagment", row.Cells[0].Text);
                Session.Timeout = 60;
                Response.Redirect("http://localhost:4911/Dashboard/Teacher/ClassStudents.aspx");
            }
            if (e.CommandName == "SessionHistory")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvClasses.Rows[index];

                Session.Add("LGIDforSessionHistory", row.Cells[0].Text);
                Session.Timeout = 60;
                Response.Redirect("http://localhost:4911/Dashboard/Teacher/SessionHistory.aspx");
            }
            if (e.CommandName == "NewSession")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvClasses.Rows[index];
                Session.Add("LGIDforNewSession", row.Cells[0].Text);
                Session.Timeout = 60;
                Response.Redirect("http://localhost:4911/Dashboard/Teacher/NewSession.aspx");
            }
        }
    }
}