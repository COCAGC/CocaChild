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

            gvSurveyList.DataSource = (
                    from StudentGroupSeason sgs in ctx.StudentGroupSeasons
                    select new
                    {
                        SurveyDate = sgs.SurveyDate,
                        StudentGroupName = sgs.StudentGroup.Name,
                        SchoolYear = sgs.StudentGroup.SchoolYear.Year.Name
                    }
                ).ToList();
            gvSurveyList.DataBind();
        }

        using (CocaDataContext ctx = new CocaDataContext())
        {
            var x = from StudentGroupSeason apr in ctx.StudentGroupSeasons
                    where apr.Id == 1
                    select new { FirstName = apr.StudentSurveyDates };
        }
    }
}