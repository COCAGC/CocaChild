using System;
using System.Linq;
using DAL;
using System.Collections.Generic;
using System.Data.Linq;

public partial class ListSchools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {

            gvSchoolList.DataSource = (
                    from School d in ctx.Schools
                    select new
                    {
                        Name = d.Name,
                        City = d.City,
                        StateName = d.State.Name,
                        Zip = d.Zip
                    }
                ).ToList();
            gvSchoolList.DataBind();
        }

        using (CocaDataContext ctx = new CocaDataContext()) {

            IEnumerable<EntitySet<StudentSurveyDate>> x = from StudentGroupSeason apr in ctx.StudentGroupSeasons
                    where apr.Id == 1
                    select apr.StudentSurveyDates;

            
        }
    }
}