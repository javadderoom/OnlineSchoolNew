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
    public partial class EditEmployee : System.Web.UI.Page
    {
        private KarmandRepository rep = new KarmandRepository();

        public void load()
        {


            if (Session["useridForEditEmployee"] != null)
            {
                string id = Session["useridForEditEmployee"].ToString();
                Karmand lo = rep.FindByEmployeeID(id);
                tbxFirstName.Value = lo.FirstName;
                tbxLastName.Value = lo.LastName;
                lblPersonalCode.Value = lo.PersonalCode;
                tbxBirthDay.Value = string.Format("{0}/{1}/{2}", lo.BirthDate.Substring(0, 4), lo.BirthDate.Substring(4, 2), lo.BirthDate.Substring(6, 2));
                tbxUserName.Value = lo.UserName;
                tbxPassword.Value = lo.UserPass;
                tbxFixTel.Value = lo.PhoneNumber;
                tbxMobile.Value = lo.Mobile;

                //tbxEmail.Value = lo.Email;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Admin/News.aspx'", true);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                load();
            }
        }

        protected void btnSabtEditProfile_Click(object sender, EventArgs e)
        {


            if (Session["useridForEditEmployee"] != null)
            {
                string id = Session["useridForEditEmployee"].ToString();
                Karmand stuu = rep.FindByEmployeeID(id);
                Karmand kar = new Karmand();

                kar.PersonalCode = id;
                kar.EID = stuu.EID; ;
                kar.UserName = tbxUserName.Value;
                kar.UserPass = tbxPassword.Value;

                kar.FirstName = tbxFirstName.Value;
                kar.LastName = tbxLastName.Value;
                kar.BirthDate = string.Format("{0}{1}{2}", tbxBirthDay.Value.Substring(0, 4), tbxBirthDay.Value.Substring(5, 2), tbxBirthDay.Value.Substring(8, 2));

                kar.PhoneNumber = tbxFixTel.Value;
                kar.Mobile = tbxMobile.Value;

                //stu.Email = tbxEmail.Value;

                rep.SaveEmployees(kar);
                Response.Redirect("http://localhost:4911/Dashboard/Admin/Employees.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Admin/News.aspx'", true);

            }
        }
    }
}