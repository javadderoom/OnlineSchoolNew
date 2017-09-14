using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Repository;
using Common;
using DataAccess;

namespace WebPages.Dashboard.Admin
{
    public partial class reportsLessonGroupsChart : System.Web.UI.Page
    {
        private string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["LGID"];
            if (!Page.IsPostBack)
            {
                setGridView();
                setLabel();
            }
        }

        private void setGridView()
        {
            vReportExamsRepository vre = new vReportExamsRepository();
            gvStudents.DataSource = vre.topStudentsAverageByLGID(id.ToInt());
            gvStudents.DataBind();
        }

        public void setLabel()
        {
            vReportExamsRepository v = new vReportExamsRepository();
            string id = Request.QueryString["LGID"];
            lblmianginkatbi.InnerText = Convert.ToDouble(v.getAverageLessonGroup(id.ToInt(), 0)).ToString();
            lblmianginshafahi.InnerText = Convert.ToDouble(v.getAverageLessonGroup(id.ToInt(), 1)).ToString();
            lblKatbiExamCount.InnerText = v.ExamCountByLGID(id.ToInt(), 0).ToString();
            lblShafahiExamCount.InnerText = v.ExamCountByLGID(id.ToInt(), 1).ToString();

            TamrinRepository tr = new TamrinRepository();
            int cnt = tr.countTamrinByid(id.ToInt());
            lbltamrincount.InnerText = cnt.ToString();

            vJavabeTamrinRepository jt = new vJavabeTamrinRepository();
            OzviatRepository or = new OzviatRepository();
            int stucnt = or.countStudentsOfLessonGroupByid(id.ToInt());
            int tjt = jt.TedadejavabeTamrin(id.ToInt());
            if (cnt == 0 || stucnt == 0)
                lblanswer.InnerText = "0";
            else
                lblanswer.InnerText = (((Convert.ToDouble(tjt) /
                    (stucnt * cnt) * 100))).ToString();

            vLessonGroupRepository lg = new vLessonGroupRepository();
            List<string> St = or.FindStudentCodeByLGID(id.ToInt());
            lblStuCount.InnerText = St.Count.ToString();
            vLessonGroup lgg = lg.FindByLGID(id.ToInt());
            lblTeacharName.InnerText = lgg.FirstName + " " + lgg.LastName;
            lblClassNum.InnerText = lgg.Class;
            lblLessonTitle.InnerText = lgg.LessonTitle;

            SessionRepository sr = new SessionRepository();
            lblSessionCount.InnerText = sr.countSessionsByLGID(id.ToInt()).ToString();
        }

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void btnChart_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:4911/Dashboard/Admin/ClassChart.aspx?LGID=" + id);
        }
    }
}