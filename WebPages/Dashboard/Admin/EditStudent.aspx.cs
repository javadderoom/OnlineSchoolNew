using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Repository;
using System.Data;
using DataAccess;

namespace WebPages.Dashboard.Admin
{
    public partial class EditStudent : System.Web.UI.Page
    {
        private vStudentRepository rep = new vStudentRepository();

        public void load()
        {

            if (Session["UserIDForEditStudent"] != null)
            {
                string id = Session["UserIDForEditStudent"].ToString();
                Student lo = rep.FindByStudentCode(id);
                tbxFirstName.Value = lo.FirstName;
                tbxLastName.Value = lo.LastName;

                tbxBirthYear.Value = lo.BirthDate.Substring(0, 4);
                tbxIDNumber.Value = lo.NationalCode.ToString();
                tbxFixTel.Value = lo.PhoneNumber;
                tbxMobile.Value = lo.MobileNumber;
                tbxZipCode.Value = lo.ZipCode;
                tbxEmail.Value = lo.Email;
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


            if (Session["UserIDForEditStudent"] != null)
            {
                string id = Session["UserIDForEditStudent"].ToString();
                Student stuu = rep.FindByStudentCode(id);
                Student stu = new Student();

                stu.StuID = stuu.StuID;
                stu.SGarde = stuu.SGarde;
                stu.CGrade = stuu.CGrade;
                stu.UserName = stuu.UserName;
                stu.Password = stuu.Password;
                stu.FatherID = stuu.FatherID;
                stu.MotherID = stuu.MotherID;
                stu.RemainedSalary = stuu.RemainedSalary;

                stu.StudentCode = id;
                stu.ParentUser = stuu.ParentUser;
                stu.ParentPass = stuu.ParentPass;
                stu.FirstName = tbxFirstName.Value;
                stu.LastName = tbxLastName.Value;
                stu.BirthDate = string.Format("{0}{1}{2}", tbxBirthYear.Value, stuu.BirthDate.Substring(4, 2), stuu.BirthDate.Substring(6, 2));
                stu.NationalCode = stuu.NationalCode;
                stu.PhoneNumber = tbxFixTel.Value;
                stu.MobileNumber = tbxMobile.Value;
                stu.ZipCode = tbxZipCode.Value;
                stu.Email = tbxEmail.Value;

                rep.SaveStudent(stu);
                Response.Redirect("http://localhost:4911/Dashboard/Admin/Students.aspx");
            }
        }
    }
}