using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Repository;
using Common;

namespace WebPages.Dashboard
{
    public partial class WeeklySchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ScheduleLoad();
        }

        private vStudentRepository sr = new vStudentRepository();
        private BarnameRepository bn = new BarnameRepository();
        private vLessonGroupRepository vLR = new vLessonGroupRepository();

        private void ScheduleLoad()
        {
            string stuCode = sr.GetStudentByUsername("mhmmd99").StudentCode;

            List<int?> days = bn.GetListOfDay(stuCode);
            List<int?> Times = bn.GetListOfTime(stuCode);
            ////////////////  year     ///////////////////
            // vbarnameHaftegi bh = bn.FindByOzviatTak(6);
            lblYear.InnerText = bn.GetYear(stuCode);
            //List<string> yearsList = vLR.GetlistOfAllYears();
            //IEnumerable<string> dYears = yearsList.Distinct();
            //yearsList = dYears.ToList();

            //ddlYear.Items.Add("سال تحصیلی");
            //ddlYear.Items[0].Value = "0";
            //for (int i = 1; i <= yearsList.Count; i++)
            //{
            //    ddlYear.Items.Add(yearsList[i - 1]);
            //    ddlYear.Items[i].Value = yearsList[i - 1];
            //}
            ////////////////// end year ///////////////////////
            gvSchedule.DataSource = bn.FindByOzviat(stuCode);
            gvSchedule.DataBind();
            for (int i = 0; i < days.Count; i++)
            {
                GridViewRow row = gvSchedule.Rows[i];
                switch (days[i])
                {
                    case 1: row.Cells[2].Text = Times[i].ToString(); break;
                    case 2: row.Cells[3].Text = Times[i].ToString(); break;
                    case 3: row.Cells[4].Text = Times[i].ToString(); break;
                    case 4: row.Cells[5].Text = Times[i].ToString(); break;
                    case 5: row.Cells[6].Text = Times[i].ToString(); break;
                    case 6: row.Cells[7].Text = Times[i].ToString(); break;
                }
            }
        }

        protected void gvSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvSchedule_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
    }
}