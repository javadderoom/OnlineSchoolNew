using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;
using Common;
using System.Data;

namespace WebPages.Dashboard.Teacher
{
    public partial class EditSession : System.Web.UI.Page
    {
        private int id;
        private SessionRepository sr = new SessionRepository();
        private SchoolDBEntities db = new SchoolDBEntities();
        private vLessonGroupRepository vLesRep = new vLessonGroupRepository();
        private OzviatRepository ozviatRep = new OzviatRepository();
        private vNomratRepository nr = new vNomratRepository();
        private vPresenceRepository pr = new vPresenceRepository();

        private void loadSssions()
        {
            try
            {
                if (Session["SessionIdForEditSession"] != null)
                {
                    id = Convert.ToInt32(Session["SessionIdForEditSession"].ToString());
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
                        (row.FindControl("Score") as TextBox).Text = nr.GetNomreBySessionIDandOzviatID(id, ozvID);
                        (row.FindControl("RowChBPeresece") as CheckBox).Checked = (bool)(pr.GetPreseceBySessionIDandOzviatID(id, ozvID));
                        (row.FindControl("RowChBisMovajjah") as CheckBox).Checked = (bool)(pr.GetisMovajjahBySessionIDandOzviatID(id, ozvID));
                        (row.FindControl("DescriptionTbx") as TextBox).Text = pr.GetDescriptionBySessionIDandOzviatID(id, ozvID);
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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadSssions();
            }
            else
            {
                if (tbxSessionDate.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('لطفا تاریخ را وارد کنید! ');", true);
                }
            }
        }

        protected void HeadChB_CheckedChanged(object sender, EventArgs e)
        {
            bool chek = (gvStudents.HeaderRow.FindControl("HeadChB") as CheckBox).Checked;
            foreach (GridViewRow Row in gvStudents.Rows)
            {
                (Row.FindControl("RowChBPeresece") as CheckBox).Checked = chek;
            }
        }

        private bool saveChanges()
        {
            bool result = true;

            try
            {
                if (Session["SessionIdForSessionDetails"] != null)
                {
                    id = Convert.ToInt32(Session["SessionIdForSessionDetails"].ToString());
                    ///////////////// update session ////////////////
                    Sessoin newSes = new Sessoin();
                    newSes.SessionID = id;
                    newSes.SessionNum = SessionNumber.Text.ToInt();
                    newSes.Date = tbxSessionDate.Text;
                    newSes.LGID = (int)(db.Sessoins.Where(p => p.SessionID == id).Single().LGID);
                    SessionRepository sRep = new SessionRepository();
                    sRep.SaveSession(newSes);

                    ////////////////// update Score ///////////////////////
                    foreach (GridViewRow row in gvStudents.Rows)
                    {
                        string stuCode = row.Cells[1].Text.ToString();
                        Nomarat nomre = new Nomarat();

                        int ozviatid = row.Cells[0].Text.ToInt();
                        nomre.NomreID = nr.GetNomreIDBySessionIDandOzviatID(id, ozviatid);
                        nomre.OzviatID = ozviatid;
                        int lastSession = sRep.FindLastSessionID();
                        nomre.SessionID = id;
                        nomre.Date = tbxSessionDate.Text;
                        nomre.Nomre = (row.FindControl("Score") as TextBox).Text;
                        vNomratRepository nomreRep = new vNomratRepository();
                        nomreRep.SaveNomre(nomre);

                        ///////////////////update Present///////////////////

                        Presence presence = new Presence();
                        presence.OzviatID = ozviatid;
                        presence.ID = pr.GetPreseceIDBySessionIDandOzviatID(id, ozviatid);
                        presence.SessionID = sRep.FindLastSessionID();
                        presence.Date = tbxSessionDate.Text;
                        presence.Status = (row.FindControl("RowChBPeresece") as CheckBox).Checked;
                        presence.isMovajjah = (row.FindControl("RowChBisMovajjah") as CheckBox).Checked;
                        presence.Description = (row.FindControl("DescriptionTbx") as TextBox).Text.ToString();
                        vPresenceRepository PRep = new vPresenceRepository();
                        PRep.SavePresenc(presence);
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
                result = false;
            }
            return result;
        }

        protected void btnSabt2_Click(object sender, EventArgs e)
        {
            if (saveChanges())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با موفقیت انجام شد');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با خطا مواجه شد!');", true);
            }
        }

        protected void btnSabt_Click(object sender, EventArgs e)
        {
            if (saveChanges())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با موفقیت انجام شد');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ثبت با خطا مواجه شد!');", true);
            }
        }
    }
}