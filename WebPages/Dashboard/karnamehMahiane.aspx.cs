using Common;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard
{
    public partial class karnamehMahiane : System.Web.UI.Page
    {
        int stuID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("stuID", 93124345);
            stuID = Session["stuID"].ToString().ToInt();
            if (!IsPostBack)
            {
                setDropDown();
                setGrid();
                setLabels();
            }
        }

        private void setLabels()
        {
            double sum = 0;
            foreach (GridViewRow r in gvLessonGroups.Rows)
            {
                sum += r.Cells[3].Text.ToString().ToInt();
            }

            lblMiabgin.InnerText = (sum / gvLessonGroups.Rows.Count).ToString();
        }

        private void setGrid()
        {
            string mah = "07";
            if (DropDownList1.SelectedIndex == 0)
                mah = "07";
            if (DropDownList1.SelectedIndex == 1)
                mah = "08";
            if (DropDownList1.SelectedIndex == 2)
                mah = "09";
            if (DropDownList1.SelectedIndex == 3)
                mah = "10";
            if (DropDownList1.SelectedIndex == 4)
                mah = "11";
            if (DropDownList1.SelectedIndex == 5)
                mah = "12";
            if (DropDownList1.SelectedIndex == 6)
                mah = "01";
            if (DropDownList1.SelectedIndex == 7)
                mah = "02";
            if (DropDownList1.SelectedIndex == 8)
                mah = "03";

            KarnamehRepository r = new KarnamehRepository();
            gvLessonGroups.DataSource = r.getStudentKarnamehMahiane(stuID, mah);
            gvLessonGroups.DataBind();



        }

        private void setDropDown()
        {
            DropDownList1.Items.Add("مهر");
            DropDownList1.Items.Add("آبان");
            DropDownList1.Items.Add("اذر");
            DropDownList1.Items.Add("دی");
            DropDownList1.Items.Add("بهمن");
            DropDownList1.Items.Add("اسفند");
            DropDownList1.Items.Add("فروردین");
            DropDownList1.Items.Add("اردیبهشت");
            DropDownList1.Items.Add("خرداد");

        }

        protected void gvLessonGroups_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setGrid();
            setLabels();
        }
    }
}