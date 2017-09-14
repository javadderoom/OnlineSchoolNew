using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard
{
    public partial class HomeWorkDetails : System.Web.UI.Page
    {
        int tamrinid;
        protected void Page_Load(object sender, EventArgs e)
        {
            tamrinid = Session["TamrinIDForHomeWorkDetails"].ToString().ToInt();
            if (!IsPostBack)
            {
                setLabels();
            }
        }

        private void setLabels()
        {
            TamrinRepository r = new TamrinRepository();
            DataTable dt = new DataTable();
            dt = r.getTamrinInfo(tamrinid);
            lblStartDate.InnerText = dt.Rows[0][7].ToString();
            lblExpireDate.InnerText = dt.Rows[0][8].ToString();
            lblTamrinTitle.Text = dt.Rows[0][1].ToString();
            tbxDesc.Text = dt.Rows[0][5].ToString();
            tbxDesc.Enabled = false;

            //buttons
            if (dt.Rows[0][6] == DBNull.Value)
            {
                btnDownload.Enabled = false;
                btnDownload.BackColor = System.Drawing.Color.Red;

            }


            //long expireDate = Convert.ToInt64(dt.Rows[0][4].ToString());
            //long now = Convert.ToInt64(DBManager.CurrentPersianDateWithoutSlash());
            //if (now > expireDate)
            //    btnAnswer.Enabled = false;
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

        }

        protected void btnAnswer_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:4911/Dashboard/answerHomeWork.aspx");
        }
    }
}