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
    public partial class LessonGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLessonGroups();
            }
        }

        public void LoadLessonGroups()
        {
            vLessonGroupRepository sr = new vLessonGroupRepository();
            gvLessonGroups.DataSource = sr.GetAllLessonGroups();
            gvLessonGroups.DataBind();
            foreach (GridViewRow row in gvLessonGroups.Rows)
            {
                switch (row.Cells[7].Text)
                {
                    case "1":
                        row.Cells[7].Text = "شنبه";
                        break;

                    case "2":
                        row.Cells[7].Text = "یک شنبه";
                        break;

                    case "3":
                        row.Cells[7].Text = "دوشنبه";
                        break;

                    case "4":
                        row.Cells[7].Text = "سه شنبه";
                        break;

                    case "5":
                        row.Cells[7].Text = "چهارشنبه";
                        break;

                    case "6":
                        row.Cells[7].Text = "پنج شنبه";
                        break;

                    case "7":
                        row.Cells[7].Text = "جمعه";
                        break;
                }
            }
            tbxSearch.Value = "";
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadLessonGroups();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            vLessonGroupRepository sr = new vLessonGroupRepository();

            gvLessonGroups.DataSource = sr.searchLessonsGroups(tbxSearch.Value);
            gvLessonGroups.DataBind();
            foreach (GridViewRow row in gvLessonGroups.Rows)
            {
                switch (row.Cells[7].Text)
                {
                    case "1":
                        row.Cells[7].Text = "شنبه";
                        break;

                    case "2":
                        row.Cells[7].Text = "یک شنبه";
                        break;

                    case "3":
                        row.Cells[7].Text = "دوشنبه";
                        break;

                    case "4":
                        row.Cells[7].Text = "سه شنبه";
                        break;

                    case "5":
                        row.Cells[7].Text = "چهارشنبه";
                        break;

                    case "6":
                        row.Cells[7].Text = "پنج شنبه";
                        break;

                    case "7":
                        row.Cells[7].Text = "جمعه";
                        break;
                }
            }
            tbxSearch.Value = "";
        }

        protected void btnAddLessonGroup_Click(object sender, EventArgs e)
        {
        }

        protected void gvEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Students")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvLessonGroups.Rows[index];
                Session.Add("LGIDForClassMembers", row.Cells[0].Text);
                Response.Redirect("http://localhost:4911/Dashboard/Admin/ClassMembers.aspx");
            }
            if (e.CommandName == "Edit")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvLessonGroups.Rows[index];
                Session.Add("LGIDForEditLessonGroup", row.Cells[0].Text);
                Response.Redirect("http://localhost:4911/Dashboard/Admin/EditLessonGroup.aspx");
            }
            if (e.CommandName == "Details")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvLessonGroups.Rows[index];

                string id = row.Cells[0].Text;
                vLessonGroupRepository rep = new vLessonGroupRepository();
                if (id != "" || id != null)
                {
                    vLessonGroup lo = rep.FindByLGID(id.ToInt());
                    tbxID.InnerText = lo.LGID.ToString();
                    tbxClass.InnerText = lo.Class;
                    tbxLessonTitle.InnerText = lo.LessonTitle;
                    tbxTeacherFName.InnerText = lo.FirstName;
                    tbxTeacherLName.InnerText = lo.LastName;
                    tbxUnit.InnerText = lo.Unit.ToString();
                    tbxDay.InnerText = lo.Day.ToString();
                    tbxTime.InnerText = lo.Time.ToString();

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
                GridViewRow row = gvLessonGroups.Rows[index];

                vLessonGroupRepository rep = new vLessonGroupRepository();

                rep.DeleteLessonGroup(row.Cells[0].Text.ToInt());
                //SchoolDBEntities db = new SchoolDBEntities();
                //LessonGroup k = new LessonGroup();
                //int a = row.Cells[0].Text;
                //k = db.LessonGroups.Where(p => p.LGID == a).Single();
                //db.Karmands.Remove(k);
                //db.SaveChanges();
                LoadLessonGroups();
            }
        }

        protected void gvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void Grade_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}