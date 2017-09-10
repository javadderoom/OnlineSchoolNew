using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;
using Common;

namespace WebPages.Dashboard.Admin
{
    public partial class Ozviat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSelectedStudents();
                LoadStudents();
            }
        }

        private OzviatRepository or = new OzviatRepository();
        private vStudentRepository rep = new vStudentRepository();
        private vLessonGroupRepository lg = new vLessonGroupRepository();

        public void LoadStudents()
        {
            if (Session["LGIDForClassMembers"] != null)
            {
                string id = Session["LGIDForClassMembers"].ToString();
                List<string> stuCodes = new List<string>();
                foreach (GridViewRow row in gvSelectedStudents.Rows)
                {
                    stuCodes.Add(row.Cells[1].Text);
                }
                gvStudents.DataSource = rep.GetAllStudentsExceptByGradeID(stuCodes, lg.getLessonGroupgardeID(id.ToInt()));
                gvStudents.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Admin/News.aspx'", true);
            }

        }

        #region SelectedStudents

        public void LoadSelectedStudents()
        {
            string id = Session["LGIDForClassMembers"].ToString();
            List<vOzviat> vs = new List<vOzviat>();
            List<string> St = or.FindStudentCodeByLGID(id.ToInt());
            for (int i = 0; i < St.Count; i++)
            {
                vs.Add(or.FindStudentinOzviat(St[i]));
            }
            gvSelectedStudents.DataSource = OnlineTools.ToDataTable(vs); ;
            gvSelectedStudents.DataBind();
            lblStudentsCount.InnerText = St.Count.ToString();
            vLessonGroup lgg = lg.FindByLGID(id.ToInt());
            lblTeacherName.InnerText = lgg.FirstName + " " + lgg.LastName;
            lblClass.InnerText = lgg.Class;
            lblLesson.InnerText = lgg.LessonTitle;
        }

        protected void gvSelectedStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvSelectedStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvSelectedStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvSelectedStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvSelectedStudents.Rows[index];

                string id = row.Cells[1].Text;

                if (id != "" || id != null)
                {
                    Student lo = rep.FindByStudentCode(id);
                    tbxFirstName.InnerText = lo.FirstName;
                    tbxLastName.InnerText = lo.LastName;
                    tbxStudentCode.InnerText = lo.StudentCode;
                    tbxNatinalCode.InnerText = lo.NationalCode;
                    tbxBirthDay.InnerText = string.Format("{0}/{1}/{2}", lo.BirthDate.Substring(0, 4), lo.BirthDate.Substring(4, 2), lo.BirthDate.Substring(6, 2));
                    tbxUserName.InnerText = lo.UserName;
                    tbxPassword.InnerText = lo.Password;
                    tbxFixTel.InnerText = lo.PhoneNumber;
                    tbxMobile.InnerText = lo.MobileNumber;
                    tbxAddress.InnerText = lo.Address;

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#modalShowDetails').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "ModalScript", sb.ToString(), false);
                }
            }
            if (e.CommandName == "Delet")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvSelectedStudents.Rows[index];
                string id = row.Cells[0].Text;
                OzviatRepository rep = new OzviatRepository();

                rep.DeleteOzviat(id.ToInt());
                LoadSelectedStudents();
                LoadStudents();
            }
        }

        #endregion SelectedStudents

        #region AllStudents

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                // Retrieve the row index stored in the
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button
                // from the Rows collection.
                GridViewRow row = gvStudents.Rows[index];

                string id = row.Cells[0].Text;

                if (id != "" || id != null)
                {
                    Student lo = rep.FindByStudentCode(id);
                    tbxFirstName.InnerText = lo.FirstName;
                    tbxLastName.InnerText = lo.LastName;
                    tbxStudentCode.InnerText = lo.StudentCode;
                    tbxNatinalCode.InnerText = lo.NationalCode;
                    tbxBirthDay.InnerText = string.Format("{0}/{1}/{2}", lo.BirthDate.Substring(0, 4), lo.BirthDate.Substring(4, 2), lo.BirthDate.Substring(6, 2));
                    tbxUserName.InnerText = lo.UserName;
                    tbxPassword.InnerText = lo.Password;
                    tbxFixTel.InnerText = lo.PhoneNumber;
                    tbxMobile.InnerText = lo.MobileNumber;
                    tbxAddress.InnerText = lo.Address;

                    //tbxEmail.Value = lo.Email;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#modalShowDetails').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "ModalScript", sb.ToString(), false);
                }
            }
        }

        #endregion AllStudents

        protected void GVchk_CheckedChanged(object sender, EventArgs e)
        {
            //int i = lblSelectedRecords.Text.IndexOf(':');
            //int num = lblSelectedRecords.Text.Substring(i + 1).ToInt();

            CheckBox ch = sender as CheckBox;
            // if (ch.Checked == true) num++;
            // else num--;
            // lblSelectedRecords.Text = "تعداد انتخاب شده ها:";
            // lblSelectedRecords.Text += num.ToString();
            Page_Load(null, null);
        }

        protected void ContentPlaceHolder1_btnAddStudent_Click(object sender, EventArgs e)
        {
            List<string> loid = new List<string>();
            CheckBox chk;
            foreach (GridViewRow gvr in gvStudents.Rows)
            {
                chk = gvr.Cells[5].FindControl("GVchk") as CheckBox;
                if (chk.Checked == true)
                {
                    loid.Add(gvr.Cells[0].Text.ToString());
                }
            }

            string id = Session["LGIDForClassMembers"].ToString();

            DataAccess.Ozviat oo;
            foreach (string s in loid)
            {
                oo = new DataAccess.Ozviat();
                oo.LGID = id.ToInt();
                oo.StudentCode = s;
                or.SaveOzviat(oo);
            }

            LoadSelectedStudents();
            LoadStudents();
        }

        public string tabdiladadbehoruf(int adad)
        {
            string horuf = "";
            switch (adad)
            {
                case 1:
                    horuf = "اول";
                    break;

                case 2:
                    horuf = "دوم";
                    break;

                case 3:
                    horuf = "سوم";
                    break;

                case 4:
                    horuf = "چهارم";
                    break;

                case 5:
                    horuf = "پنجم";
                    break;

                case 6:
                    horuf = "ششم";
                    break;

                case 7:
                    horuf = "هفتم";
                    break;

                case 8:
                    horuf = "هشتم";
                    break;

                case 9:
                    horuf = "نهم";
                    break;

                case 10:
                    horuf = "دهم";
                    break;

                case 11:
                    horuf = "یازدهم";
                    break;

                case 12:
                    horuf = "دوازدهم";
                    break;
            }
            return horuf;
        }

        protected void func_search(object sender, EventArgs e)
        {
            List<string> stuCodes = new List<string>();
            foreach (GridViewRow row in gvSelectedStudents.Rows)
            {
                stuCodes.Add(row.Cells[1].Text);
            }
            gvStudents.DataSource = rep.searchStudents(tbxSearch.Text, stuCodes);
            gvStudents.DataBind();
        }
    }
}