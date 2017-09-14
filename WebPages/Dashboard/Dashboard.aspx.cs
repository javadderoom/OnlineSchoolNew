using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using DataAccess;
using DataAccess.Repository;

namespace WebPages.Dashboard
{
    public partial class Kartabl : System.Web.UI.Page
    {
        private vStudentRepository sr = new vStudentRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            vStudent stu = sr.GetStudentByUsername("mhmmd99");

            lblStuID.InnerText = stu.StuID.ToString();
            lblStudentCode.InnerText = stu.StudentCode.ToString();
            lblFirstName.InnerText = stu.FirstName;
            lblLastName.InnerText = stu.LastName;
            lblFatherName.InnerText = stu.FathersFirstName;
            lblBirthYear.InnerText = stu.BirthDate.Substring(0, 4);
            lblIDNumber.InnerText = stu.NationalCode.ToString();
            lblFixTel.InnerText = stu.PhoneNumber;
            lblMobile.InnerText = stu.MobileNumber;
            lblZipCode.InnerText = stu.ZipCode;
            lblEmail.InnerText = stu.Email;
            lblAddress.InnerText = stu.Address;
            imgUserPic.Src = stu.Image;
        }
    }
}