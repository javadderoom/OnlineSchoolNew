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
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        public void LoadStudents()
        {
            vStudentRepository sr = new vStudentRepository();
            gvStudents.DataSource = sr.GetAllStudents();
            gvStudents.DataBind();
            vStudent st = new vStudent();
            tbxSearch.Value = "";
        }

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:4911/Dashboard/Admin/AddStudent.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxSearch.Value != "")
            {
                vStudentRepository sr = new vStudentRepository();

                gvStudents.DataSource = sr.FindByFullName(tbxSearch.Value, tbxFamilySearch.Value);
                gvStudents.DataBind();
            }
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        protected void gvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        private vStudentRepository rep = new vStudentRepository();

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvStudents.Rows[index];
                Session.Add("UserIDForEditStudent", row.Cells[0].Text);
                Session.Timeout = 60;

                Response.Redirect("http://localhost:4911/Dashboard/Admin/EditStudent.aspx");
            }
            if (e.CommandName == "Details")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvStudents.Rows[index];

                string id = row.Cells[0].Text;

                if (id != "" || id != null)
                {
                    Student lo = rep.FindByStudentCode(id);
                    tbxFirstName.InnerText = lo.FirstName;
                    tbxLastName.InnerText = lo.LastName;
                    tbxStudentCode.InnerText = lo.StudentCode;
                    tbxNatinalCode.InnerText = lo.NationalCode;
                    tbxBirthDay.InnerText = string.Format("{0}/{1}/{2}", lo.BirthDate.Substring(0, 4), lo.BirthDate.Substring(4, 2), lo.BirthDate.Substring(6, 2));
                    tbxUserName.InnerText = lo.UserName;
                    tbxPassword.InnerText = lo.Password;
                    tbxFixTel.InnerText = lo.PhoneNumber;
                    tbxMobile.InnerText = lo.MobileNumber;
                    tbxAddress.InnerText = lo.Address;

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
                GridViewRow row = gvStudents.Rows[index];

                vStudentRepository rep = new vStudentRepository();

                SchoolDBEntities db = new SchoolDBEntities();
                db.Students.Remove(rep.FindByStudentCode(row.Cells[0].Text));
            }
        }
    }
}