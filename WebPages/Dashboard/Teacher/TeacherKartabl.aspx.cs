using System;
using DataAccess;
using DataAccess.Repository;

namespace WebPages.Dashboard.Teacher
{
    public partial class TeacherKartabl : System.Web.UI.Page
    {
        private KarmandRepository kr = new KarmandRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            Karmand stu = kr.FindByUserName("karim");

            lblID.InnerText = stu.EID.ToString();
            lblPersonalCode.InnerText = stu.PersonalCode.ToString();
            lblFirstName.InnerText = stu.FirstName;
            lblLastName.InnerText = stu.LastName;

            lblBirthYear.InnerText = stu.BirthDate.Substring(0, 4);

            lblFixTel.InnerText = stu.PhoneNumber;
            lblMobile.InnerText = stu.Mobile;
            lblEmail.InnerText = stu.Email;
            lblEmail.InnerText = stu.Email;

            imgUserPic.Src = stu.Image;
        }
    }
}