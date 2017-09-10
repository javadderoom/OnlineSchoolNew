using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPages.Dashboard.Admin
{
    public partial class reportsFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setGrid();
            }
        }

        private void setGrid()
        {
            FieldsRepository fr = new FieldsRepository();
            gvLessonGroups.DataSource = fr.getMaghateHaveFieldOfCurrentYear();
            gvLessonGroups.DataBind();
        }

        protected void gvLessonGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvLessonGroups_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvLessonGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}