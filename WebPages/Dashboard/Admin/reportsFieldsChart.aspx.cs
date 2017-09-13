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
    public partial class reportsFieldsChart : System.Web.UI.Page
    {
        int fid, gid;
        protected void Page_Load(object sender, EventArgs e)
        {
            fid = Session["FieldID"].ToString().ToInt();
            gid = Session["GradeID"].ToString().ToInt();
            if (!Page.IsPostBack)
            {
                setGridView();
                setLabel();

            }
        }

        private void setGridView()
        {
            vReportExamsRepository rep = new vReportExamsRepository();
            gvStudents.DataSource = rep.fieldsAverage(fid, gid);
            gvStudents.DataBind();
        }

        public void setLabel()
        {
            GradesRepository gr = new GradesRepository();
            lblMaghta.InnerText = gr.getGradeTitleByID(gid);
            FieldsRepository fr = new FieldsRepository();
            lblReshte.InnerText = fr.getFieldTitleByID(fid);

            StudentRepository sr = new StudentRepository();
            lblStudentsCount.InnerText = sr.countStudentsByFieldID_GradeID(fid, gid).ToString();

            vReportExamsRepository rep = new vReportExamsRepository();
            lblmianginkatbi.InnerText = rep.getAverageOfFieldOfgrade(fid, gid, 0).ToString();
            lblmianginshafahi.InnerText = rep.getAverageOfFieldOfgrade(fid, gid, 1).ToString();


        }

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}