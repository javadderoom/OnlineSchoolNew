using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard.Admin
{
    public partial class reportsLessonGroups : System.Web.UI.Page
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
            gvLessonGroups.DataSource = sr.getAllLessonGroupsOfCurrentYear();
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

        protected void gvLessonGroups_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLessonGroups.PageIndex = e.NewPageIndex;
            LoadLessonGroups();
        }
    }
}