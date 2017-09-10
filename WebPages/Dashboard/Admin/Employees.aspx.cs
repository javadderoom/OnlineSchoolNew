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
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        public void LoadEmployees()
        {
            KarmandRepository sr = new KarmandRepository();
            gvEmployees.DataSource = sr.GetAllEmployees();
            gvEmployees.DataBind();
            Karmand st = new Karmand();
            tbxSearch.Value = "";
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxSearch.Value != "")
            {
                KarmandRepository sr = new KarmandRepository();

                gvEmployees.DataSource = sr.FindByFullName(tbxSearch.Value, tbxFamilySearch.Value);
                gvEmployees.DataBind();
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:4911/Dashboard/Admin/AddEmployee.aspx");
        }

        protected void gvEmployees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvEmployees.Rows[index];
                Session.Add("useridForEditEmployee", row.Cells[0].Text);
                Session.Timeout = 60;
                Response.Redirect("http://localhost:4911/Dashboard/Admin/EditEmployee.aspx");
            }
            if (e.CommandName == "Details")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvEmployees.Rows[index];

                string id = row.Cells[0].Text;
                KarmandRepository rep = new KarmandRepository();
                if (id != "" || id != null)
                {
                    Karmand lo = rep.FindByEmployeeID(id);
                    tbxFirstName.InnerText = lo.FirstName;
                    tbxLastName.InnerText = lo.LastName;
                    tbxPersonalCode.InnerText = lo.PersonalCode;
                    tbxBirthDay.InnerText = string.Format("{0}/{1}/{2}", lo.BirthDate.Substring(0, 4), lo.BirthDate.Substring(4, 2), lo.BirthDate.Substring(6, 2));
                    tbxUserName.InnerText = lo.UserName;
                    tbxPassword.InnerText = lo.UserPass;
                    tbxFixTel.InnerText = lo.PhoneNumber;
                    tbxMobile.InnerText = lo.Mobile;

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
                GridViewRow row = gvEmployees.Rows[index];

                // KarmandRepository rep = new KarmandRepository();

                //rep.DeleteEmployee(row.Cells[0].Text);
                SchoolDBEntities db = new SchoolDBEntities();
                Karmand k = new Karmand();
                string a = row.Cells[0].Text;
                k = db.Karmands.Where(p => p.PersonalCode == a).Single();
                db.Karmands.Remove(k);
                db.SaveChanges();
                LoadEmployees();
            }
        }

        protected void gvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
    }
}