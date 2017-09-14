using Common;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard
{
    public partial class answerHomeWork : System.Web.UI.Page
    {
        int tamrinid;
        int ozviatid;
        DataTable dtable;
        protected void Page_Load(object sender, EventArgs e)
        {
            tamrinid = Session["TamrinIDForHomeWorkDetails"].ToString().ToInt();
            Session.Add("stuID", 93124345);//
            OzviatRepository r = new OzviatRepository();
            ozviatid = r.OzviatIDByLGIDAndStudentCode(Session["LGIDForHomeWork"].ToString().ToInt(), Session["stuID"].ToString());
            vJavabeTamrinRepository vr = new vJavabeTamrinRepository();
            dtable = vr.getJavabeTamrinInfoByTamrinID_OzviatID(tamrinid, ozviatid);

            if (!IsPostBack)
            {
                // ozviatid = -2;
                // dtable = new DataTable();
                setLabels();
                setDataTable();

            }
        }

        private void setDataTable()
        {


            if (dtable.Rows.Count == 0 || dtable.Rows[0][3] == DBNull.Value)
            {
                btnDownloadPre.Enabled = false;
                btnDownloadPre.BackColor = System.Drawing.Color.Red;
            }
            if (dtable.Rows.Count != 0)
            {
                btnAnswer.Text = "ویرایش پاسخ";
                btnAnswer.BackColor = System.Drawing.Color.Blue;
                tbxDesc.Text = dtable.Rows[0][4].ToString();
            }
        }

        private void setLabels()
        {
            TamrinRepository r = new TamrinRepository();
            DataTable dt = new DataTable();
            dt = r.getTamrinInfo(tamrinid);
            lblStartDate.InnerText = dt.Rows[0][7].ToString();
            lblExpireDate.InnerText = dt.Rows[0][8].ToString();

            long expireDate = Convert.ToInt64(dt.Rows[0][4].ToString());
            long now = Convert.ToInt64(DBManager.CurrentPersianDateWithoutSlash());
            if (now > expireDate)
            {
                btnAnswer.Enabled = false;
                btnAnswer.BackColor = System.Drawing.Color.Red;
            }

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

        }

        protected void btnAnswer_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (ext != ".zip" && ext != "" && ext != null)
            {
                lblStatus.Text = "فرمت فایل مجاز نیست";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string Description = tbxDesc.Text;
            string SendingDate = DBManager.CurrentPersianDateWithoutSlash();
            string SendingTime = DBManager.CurrentTime();

            string filename = Path.GetFileName(FileUpload1.FileName);
            string rand = DBManager.CurrentTimeWithoutColons() + DBManager.CurrentPersianDateWithoutSlash();
            filename = rand + filename;

            FileUpload1.SaveAs(Server.MapPath(@"~\Dashboard\Images\") + filename);

            SqlConnection cn = new SqlConnection(vReportExamsRepository.conString);
            cn.Open();
            FileStream fStream = File.OpenRead(Server.MapPath(@"~\Dashboard\Images\") + filename);
            byte[] contents = new byte[fStream.Length];
            fStream.Read(contents, 0, (int)fStream.Length);
            fStream.Close();

            if (dtable.Rows.Count != 0)
            {
                int JavabID = dtable.Rows[0][0].ToString().ToInt();


                if (contents.Length != 0)
                {
                    SqlCommand cmd = new SqlCommand(string.Format("UPDATE JavabeTamrin SET TamrinID = {0},OzviatID = {1},Description = N'{2}',SendingDate = '{3}',SendingTime = '{4}',fileData = @data WHERE JavabID = {5}", tamrinid, ozviatid, tbxDesc.Text, DBManager.CurrentPersianDateWithoutSlash(), DBManager.CurrentTime(), JavabID), cn);
                    cmd.Parameters.AddWithValue("@data", contents);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(string.Format("UPDATE JavabeTamrin SET TamrinID = {0},OzviatID = {1},Description = N'{2}',SendingDate = '{3}',SendingTime = '{4}' WHERE JavabID = {5}", tamrinid, ozviatid, tbxDesc.Text, DBManager.CurrentPersianDateWithoutSlash(), DBManager.CurrentTime(), JavabID), cn);
                    cmd.ExecuteNonQuery();
                }

                FileInfo fi = new FileInfo(Server.MapPath(@"~\Dashboard\Images\") + filename);
                fi.Delete();

                lblStatus.Text = "عملیات ویرایش با موفقیت انجام شد";
                lblStatus.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                if (contents.Length == 0)
                {
                    SqlCommand cmd = new SqlCommand(string.Format("select * from JavabeTamrin insert into JavabeTamrin (TamrinID,OzviatID,fileData,Description,SendingDate,SendingTime) values({0},{1},null,'{2}',N'{3}','{4}')", tamrinid, ozviatid, tbxDesc.Text, DBManager.CurrentPersianDateWithoutSlash(), DBManager.CurrentTime()), cn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(string.Format("select * from JavabeTamrin insert into JavabeTamrin (TamrinID,OzviatID,fileData,Description,SendingDate,SendingTime) values({0},{1},@data,'{2}',N'{3}','{4}')", tamrinid, ozviatid, tbxDesc.Text, DBManager.CurrentPersianDateWithoutSlash(), DBManager.CurrentTime()), cn);
                    cmd.Parameters.AddWithValue("@data", contents);
                    cmd.ExecuteNonQuery();
                }


                FileInfo fi = new FileInfo(Server.MapPath(@"~\Dashboard\Images\") + filename);
                fi.Delete();

                lblStatus.Text = "عملیات ثبت با موفقیت انجام شد";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnDownloadPre_Click(object sender, EventArgs e)
        {

        }
    }
}