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
    public partial class reportsLessonGroupsDetail : System.Web.UI.Page
    {
        int stuID, lgid;
        protected void Page_Load(object sender, EventArgs e)
        {
            stuID = Session["stuID"].ToString().ToInt();
            lgid = Session["LGIDForReportsGroupDetail"].ToString().ToInt();
            if (!IsPostBack)
            {
                setLabels();
                setGrid();
            }
        }

        private void setGrid()
        {
            vReportExamsRepository v = new vReportExamsRepository();
            gvStudents.DataSource = v.getRizNomaratOfstudentOfLessonGroup(stuID, lgid);
            gvStudents.DataBind();

            foreach (GridViewRow row in gvStudents.Rows)
            {
                switch (row.Cells[4].Text)
                {
                    case "0":
                        row.Cells[4].Text = "کتبی";
                        break;

                    case "1":
                        row.Cells[4].Text = "شفاهی";
                        break;
                }
                string s = row.Cells[2].Text;
                s = s.Substring(0, 4) + '/' + s.Substring(4, 2) + '/' + s.Substring(6, 2);

                row.Cells[2].Text = s;
            }
        }

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        private void setLabels()
        {
            vReportExamsRepository r = new vReportExamsRepository();
            lblMiabginKatbi.InnerText = r.getStudentAverageOfLessonGorup(stuID, lgid, 0).ToString();
            lblMianginShafahi.InnerText = r.getStudentAverageOfLessonGorup(stuID, lgid, 1).ToString();

            TamrinRepository t = new TamrinRepository();
            lblTamrinCount.InnerText = t.countTamrinByid(lgid).ToString();

            vJavabeTamrinRepository v = new vJavabeTamrinRepository();
            lblAnswer.InnerText = v.countJavabeTamrinByStuCode_Lgid(stuID, lgid).ToString();
        }
    }
}