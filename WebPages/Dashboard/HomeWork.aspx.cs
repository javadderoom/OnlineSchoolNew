using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data;
using DataAccess;
//using WebPages.

namespace WebPages.Dashboard
{
    public partial class HomeWork : System.Web.UI.Page
    {
        int lgid;
        protected void Page_Load(object sender, EventArgs e)
        {
            lgid = Session["LGIDForHomeWork"].ToString().ToInt();
            //Session.Add("stuID",)
            // int sid = Session["stuID"].ToString().ToInt();
            if (!IsPostBack)
            {
                setGrid();
            }
        }

        private void setGrid()
        {
            TamrinRepository r = new TamrinRepository();
            gvLessonGroups.DataSource = r.getLessonGroupTamrins(lgid);
            gvLessonGroups.DataBind();


        }

        protected void gvLessonGroups_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvLessonGroups_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvLessonGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvLessonGroups.Rows[index];
                Session.Add("TamrinIDForHomeWorkDetails", row.Cells[0].Text);
                Response.Redirect("http://localhost:4911/Dashboard/HomeWorkDetails.aspx");
            }
        }
    }
}