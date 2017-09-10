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
    public partial class EditeLessonGroup : System.Web.UI.Page
    {
        private vLessonGroupRepository rep = new vLessonGroupRepository();

        public void LoadDrpDList()
        {
            LessonsRepository LR = new LessonsRepository();
            KarmandRepository KR = new KarmandRepository();
            vLessonGroupRepository vLR = new vLessonGroupRepository();

            ddGrade.Items.Add("مقطع");
            ddGrade.Items[0].Value = "0";
            ddGrade.Items.Add("اول");
            ddGrade.Items[1].Value = "1";
            ddGrade.Items.Add("دوم");
            ddGrade.Items[2].Value = "2";
            ddGrade.Items.Add("سوم");
            ddGrade.Items[3].Value = "3";
            ddGrade.Items.Add("چهارم");
            ddGrade.Items[4].Value = "4";
            ddGrade.Items.Add("پنجم");
            ddGrade.Items[5].Value = "5";
            ddGrade.Items.Add("ششم");
            ddGrade.Items[6].Value = "6";
            ddGrade.Items.Add("هفتم");
            ddGrade.Items[7].Value = "7";
            ddGrade.Items.Add("هشتم");
            ddGrade.Items[8].Value = "8";
            ddGrade.Items.Add("نهم");
            ddGrade.Items[9].Value = "9";
            ddGrade.Items.Add("دهم");
            ddGrade.Items[10].Value = "10";
            ddGrade.Items.Add("یازدهم");
            ddGrade.Items[11].Value = "11";
            ddGrade.Items.Add("دوازدهم");
            ddGrade.Items[12].Value = "12";
            /////////////
            Field.Items.Add("رشته تحصیلی");
            Field.Items[0].Value = "0";
            Field.Items.Add("ریاضی");
            Field.Items[1].Value = "1";
            Field.Items.Add("تجربی");
            Field.Items[2].Value = "2";
            Field.Items.Add("انسانی");
            Field.Items[3].Value = "3";
            ///////////////
            Day.Items.Add("روز");
            Day.Items[0].Value = "0";
            Day.Items.Add("شنبه");
            Day.Items[1].Value = "1";
            Day.Items.Add("یکشنبه");
            Day.Items[2].Value = "2";
            Day.Items.Add("دوشنبه");
            Day.Items[3].Value = "3";
            Day.Items.Add("سه شنبه");
            Day.Items[4].Value = "4";
            Day.Items.Add("چهار شنبه");
            Day.Items[5].Value = "5";
            Day.Items.Add("پنج شنبه");
            Day.Items[6].Value = "6";
            ////////////////////////
            Class.Items.Add("شماره کلاس");
            Class.Items[0].Value = "0";
            Class.Items.Add("101");
            Class.Items[1].Value = "101";
            Class.Items.Add("102");
            Class.Items[2].Value = "102";
            Class.Items.Add("103");
            Class.Items[3].Value = "103";
            Class.Items.Add("201");
            Class.Items[4].Value = "201";
            Class.Items.Add("202");
            Class.Items[5].Value = "202";
            Class.Items.Add("203");
            Class.Items[6].Value = "203";
            /////////////////////////////////
            Time.Items.Add("ساعت");
            Time.Items[0].Value = "0";
            Time.Items.Add("ساعت اول");
            Time.Items[1].Value = "1";
            Time.Items.Add("ساعت دوم");
            Time.Items[2].Value = "2";
            Time.Items.Add("ساعت سوم");
            Time.Items[3].Value = "3";
            Time.Items.Add("ساعت چهارم");
            Time.Items[4].Value = "4";
            ////////////////////////
            List<Lesson> lessonList = LR.GetListOfAllLessons();
            LessonDrpDList.Items.Add("نام درس");
            LessonDrpDList.Items[0].Value = "0";
            for (int i = 1; i <= lessonList.Count; i++)
            {
                LessonDrpDList.Items.Add(lessonList[i - 1].LessonTitle);
                LessonDrpDList.Items[i].Value = lessonList[i - 1].LessonID.ToString();
            }
            ////////////////////////////
            List<Karmand> teacherList = KR.GetListOfAllEmployees();
            Teacher.Items.Add("نام مدرس");
            Teacher.Items[0].Value = "0";
            for (int i = 1; i <= teacherList.Count; i++)
            {
                Teacher.Items.Add(teacherList[i - 1].FirstName + " " + teacherList[i - 1].LastName);
                Teacher.Items[i].Value = teacherList[i - 1].PersonalCode.ToString();
            }
            //////////////////////
            List<string> yearsList = vLR.GetlistOfAllYears();
            Year.Items.Add("سال تحصیلی");
            Year.Items[0].Value = "0";
        }

        public void loadLessonGroup()
        {
            ;

            if (Session["LGIDForEditLessonGroup"] != null)
            {
                string id = Session["LGIDForEditLessonGroup"].ToString();
                LessonGroup lo = rep.FindFromLgByLGID(id.ToInt());

                ddGrade.Items.FindByValue(lo.GradeID.ToString()).Selected = true;
                if (lo.FieldID != 0)
                {
                    Field.Items.FindByValue(lo.FieldID.ToString()).Selected = true;
                }

                Day.Items.FindByValue(lo.Day.ToString()).Selected = true;
                Time.Items.FindByValue(lo.Time.ToString()).Selected = true;
                Class.Items.FindByValue(lo.Class.ToString()).Selected = true;
                Teacher.Items.FindByValue(lo.TeacherCode.ToString()).Selected = true;

                LessonDrpDList.Items.FindByValue(lo.LessonID.ToString()).Selected = true;
                // Year.Items.FindByValue(lo.GradeID.ToString()).Selected = true;
                tbxYear.Text = lo.Year;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Admin/News.aspx'", true);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDrpDList();
                loadLessonGroup();
            }
        }

        protected void btnEditLessonGroup_ServerClick(object sender, EventArgs e)
        {


            if (Session["LGIDForEditLessonGroup"] != null)
            {
                string id = Session["LGIDForEditLessonGroup"].ToString();
                LessonGroup vlg = rep.FindFromLgByLGID(id.ToInt());
                LessonGroup lg = new LessonGroup();

                if (ddGrade.SelectedIndex != 0 && Class.SelectedIndex != 0 && Day.SelectedIndex != 0 && Time.SelectedIndex != 0 && LessonDrpDList.SelectedIndex != 0 && Teacher.SelectedIndex != 0)
                {
                    LessonGroup newLesson = new LessonGroup();
                    newLesson.LGID = id.ToInt();
                    if (Field.SelectedIndex > 0)
                    {
                        newLesson.FieldID = Field.SelectedItem.Value.ToInt();
                    }
                    else
                    {
                        newLesson.FieldID = 0;
                    }
                    newLesson.GradeID = ddGrade.SelectedItem.Value.ToInt();

                    newLesson.Class = Class.SelectedItem.Value;
                    newLesson.Day = Day.SelectedItem.Value.ToInt();
                    newLesson.Time = Time.SelectedItem.Value.ToInt();
                    newLesson.LessonID = LessonDrpDList.SelectedItem.Value.ToInt();
                    newLesson.TeacherCode = Teacher.SelectedItem.Value;
                    newLesson.Year = tbxYear.Text;
                    vLessonGroupRepository vv = new vLessonGroupRepository();

                    if (vv.SaveLessonGroups(newLesson))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ویرایش با موفقیت انجام شد! ');window.location ='http://localhost:4911/Dashboard/Admin/LessonGroups.aspx'", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ویرایش با خطا مواجه شد! ')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('لطفا تمام فیلد ها را انتخاب کنید! ')", true);
                }
            }
            else

            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('شما با آدرس اشتباه وارد شده اید ! ');window.location ='http://localhost:4911/Dashboard/Admin/News.aspx'", true);

            }
        }
    }
}