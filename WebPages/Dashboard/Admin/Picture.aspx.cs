using System;
using System.Linq;
using DataAccess;
using DataAccess.Repository;

namespace WebPages.Dashboard.Admin
{
    public partial class Picture : System.Web.UI.Page
    {
        private void UpLoadAndDisplay()
        {
            string imgName = FileUpload1.FileName;
            string imgPath = "Images/" + imgName;
            int imgSize = FileUpload1.PostedFile.ContentLength;
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                imgUserPic.Src = "~/" + imgPath;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SchoolDBEntities db = new SchoolDBEntities();

                Karmand stuu = db.Karmands.Where(p => p.UserName == "moosa").Single();
                imgUserPic.Src = stuu.Image;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {//D:\Projects\SchoolSmartSystem\New folder\OnlineSchool\WebPages\Dashboard\Images\3408.jpg
                string strname = FileUpload1.FileName.ToString();

                string FileName = System.IO.Path.GetFileName(FileUpload1.FileName);
                string path = Server.MapPath("/Dashboard/Images/") + FileName;
                FileUpload1.PostedFile.SaveAs(path);
                imgUserPic.Src = "/Dashboard/Images/" + FileName;
                KarmandRepository sr = new KarmandRepository();

                SchoolDBEntities db = new SchoolDBEntities();

                Karmand stuu = db.Karmands.Where(p => p.UserName == "moosa").Single();

                stuu.Image = "/Dashboard/Images/" + strname;
                db.SaveChanges();
            }
            else
            {
            }
        }

        protected void btnSabtEditProfile_Click(object sender, EventArgs e)
        {
        }
    }
}