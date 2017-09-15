using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Repository;
using DataAccess;
using System.Transactions;
using Common;

namespace WebPages.Dashboard.Teacher
{
    public partial class NewSesion : System.Web.UI.Page
    {
        private int id;

        private void loadSssions()
        {


            try
            {
                if (Session["LGIDforNewSession"] != null)
                {
                    var today = DateTime.Now;

                    id = Convert.ToInt32(Session["LGIDforNewSession"].ToString());

                    SessionRepository Sesrep = new SessionRepository();
                    SessionNumber.Text = Sesrep.CountSessionsByLGID(id);
                    vLessonGroupRepository vLesRep = new vLessonGroupRepository();
                    var lessonGroup = vLesRep.FindByLGID(id);
                    ClassNumber.Text = lessonGroup.Class;
                    LessonName.Text = lessonGroup.LessonTitle;
                    Grade.Text = vLesRep.FindByLGID(id).GradeTitle;
                    OzviatRepository ozviatRep = new OzviatRepository();
                    StudentCount.Text = ozviatRep.StudentCountByLGID(id);
                    gvStudents.DataSource = ozviatRep.FindByLGID(id);
                    gvStudents.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Teacher/News.aspx'", true);
                }
            }
            catch (Exception)
            {
                throw;
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
                (Row.FindControl("RowChB") as CheckBox).Checked = chek;
            }
        }

        private bool saveChanges()
        {
            bool result = true;
            TransactionOptions op = new TransactionOptions();
            op.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, op))
            {
                try
                {
                    if (Session["LGIDforSessionHistory"] != null)
                    {
                        id = Convert.ToInt32(Session["LGIDforSessionHistory"].ToString());
                        ///////////////// Save session ////////////////
                        Sessoin newSes = new Sessoin();
                        newSes.Date = tbxSessionDate.Text;
                        newSes.LGID = id;
                        SessionRepository sRep = new SessionRepository();
                        newSes.SessionNum = sRep.CountSessionsByLGID(id).ToInt();
                        sRep.SaveSession(newSes);

                        ////////////////// Save Score ///////////////////////
                        foreach (GridViewRow row in gvStudents.Rows)
                        {
                            string stuCode = row.Cells[1].Text.ToString();
                            Nomarat nomre = new Nomarat();
                            OzviatRepository oRep = new OzviatRepository();
                            int ozviatid = oRep.OzviatIDByLGIDAndStudentCode(id, stuCode);
                            nomre.OzviatID = ozviatid;
                            int lastSession = sRep.FindLastSessionID();
                            nomre.SessionID = lastSession;
                            nomre.Date = tbxSessionDate.Text;
                            nomre.Nomre = (row.FindControl("Score") as TextBox).Text;
                            vNomratRepository nomreRep = new vNomratRepository();
                            nomreRep.SaveNomre(nomre);
                            ///////////////////Save Present///////////////////
                            Presence presence = new Presence();
                            presence.OzviatID = ozviatid;
                            presence.SessionID = sRep.FindLastSessionID();
                            presence.Date = tbxSessionDate.Text;
                            presence.Status = (row.FindControl("RowChB") as CheckBox).Checked;
                            presence.isMovajjah = (row.FindControl("RowChB2") as CheckBox).Checked;
                            presence.Description = (row.FindControl("DescriptionTbx") as TextBox).Text.ToString();
                            vPresenceRepository PRep = new vPresenceRepository();
                            PRep.SavePresenc(presence);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Teacher/News.aspx'", true);
                    }
                    scope.Complete();
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    result = false;
                }
                return result;
            }
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