using System;
using DataAccess;
using DataAccess.Repository;

namespace WebPages.Dashboard.Admin
{
    public partial class Kartabl : System.Web.UI.Page
    {
        private KarmandRepository kr = new KarmandRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            Karmand stu = kr.FindByUserName("moosa");

            lblID.InnerText = stu.EID.ToString();
            lblPersonalCode.InnerText = stu.PersonalCode.ToString();
            lblFirstName.InnerText = stu.FirstName;
            lblLastName.InnerText = stu.LastName;

            lblBirthYear.InnerText = stu.BirthDate.Substring(0, 4);

            lblFixTel.InnerText = stu.PhoneNumber;
            lblMobile.InnerText = stu.Mobile;
            lblEmail.InnerText = stu.Email;

            imgUserPic.Src = stu.Image;
        }
    }
}