using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace WebPages.Dashboard.Teacher
{
    public partial class SesionHistory : System.Web.UI.Page
    {
        private SessionRepository sr = new SessionRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["LGIDforSessionHistory"] != null)
                {
                    string id = Session["LGIDforSessionHistory"].ToString();
                    Session.Remove("LGIDforSessionHistory");
                    gvSessionHistory.DataSource = sr.GetSessionByLGID(id.ToInt());
                    gvSessionHistory.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Teacher/News.aspx'", true);
                }

            }
        }

        protected void gvSessionHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvSessionHistory.Rows[index];
                Session.Add("SessionIdForEditSession", row.Cells[0].Text);
                Session.Timeout = 60;
                Response.Redirect("http://localhost:4911/Dashboard/Teacher/EditSession.aspx");
            }
            if (e.CommandName == "Details")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvSessionHistory.Rows[index];

                Session.Add("SessionIdForSessionDetails", row.Cells[0].Text);
                Session.Timeout = 60;
                Response.Redirect("http://localhost:4911/Dashboard/Teacher/SessionDetails.aspx");
            }
        }
    }
}