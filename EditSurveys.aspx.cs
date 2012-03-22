using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class ViewSurveys : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            //HACK: Not sure why, but compiler is requiring that Survey be Namespace qualified
            //      despite the using statement.
            gvSurveyList.DataSource = (
                    from DAL.Survey su in ctx.Surveys
                    select new
                    {
                        SurveyDate = su.SurveyDate,
                        StudentGroupName = su.StudentGroup.Name,
                        SchoolYear = su.StudentGroup.SchoolYear.Year.Name
                    }
                ).ToList();
            gvSurveyList.DataBind();
        }

        using (CocaDataContext ctx = new CocaDataContext())
        {
            //HACK: Not sure why, but compiler is requiring that Survey be Namespace qualified
            //      despite the using DAL statement.
            var x = from DAL.Survey su in ctx.Surveys
                    where su.Id == 1
                    select new { FirstName = su.SurveyStudents };
        }
    }
}