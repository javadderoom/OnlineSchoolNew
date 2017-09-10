using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;
using Common;

namespace WebPages.Dashboard.Teacher
{
    public partial class SessionDetails : System.Web.UI.Page
    {
        private int id;
        private SessionRepository sr = new SessionRepository();
        private SchoolDBEntities db = new SchoolDBEntities();
        private vLessonGroupRepository vLesRep = new vLessonGroupRepository();
        private OzviatRepository ozviatRep = new OzviatRepository();
        private vNomratRepository nr = new vNomratRepository();
        private vPresenceRepository pr = new vPresenceRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                loadSssions();
        }

        private void loadSssions()
        {
            try
            {
                if (Session["SessionIdForSessionDetails"] != null)
                {
                    id = Convert.ToInt32(Session["SessionIdForSessionDetails"].ToString());
                    Session.Remove("SessionIdForSessionDetails");
                    Sessoin session = sr.GetSessionsBySessionID(id);
                    SessionNumber.Text = session.SessionNum.ToString();

                    int? lgid = db.Sessoins.Where(p => p.SessionID == id).Single().LGID;
                    var lessonGroup = vLesRep.FindByLGID((int)lgid);
                    ClassNumber.Text = lessonGroup.Class;
                    LessonName.Text = lessonGroup.LessonTitle;
                    Grade.Text = lessonGroup.GradeTitle;
                    tbxSessionDate.Text = session.Date;
                    StudentCount.Text = ozviatRep.StudentCountByLGID((int)lgid);
                    gvStudents.DataSource = ozviatRep.FindByLGID((int)lgid);
                    gvStudents.DataBind();
                    foreach (GridViewRow row in gvStudents.Rows)
                    {
                        int ozvID = row.Cells[0].Text.ToInt();
                        row.Cells[4].Text = nr.GetNomreBySessionIDandOzviatID(id, ozvID);
                        row.Cells[5].Text = ((bool)(pr.GetPreseceBySessionIDandOzviatID(id, ozvID))).ToString();
                        row.Cells[6].Text = ((bool)(pr.GetisMovajjahBySessionIDandOzviatID(id, ozvID))).ToString();
                        row.Cells[7].Text = pr.GetDescriptionBySessionIDandOzviatID(id, ozvID);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Teacher/News.aspx'", true);
                }
            }
            catch (Exception e)
            {
                string s = e.Message;
                throw;
            }
        }
    }
}