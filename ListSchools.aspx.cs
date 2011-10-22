using System;
using System.Linq;
using DAL;

public partial class ListSchools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            gvSchoolList.DataSource = (
                    from School d in ctx.Schools orderby d.Name
                    select new
                    {                                
                        ID = d.Id,
                        Name = d.Name,
                        Address1 = d.Address1,
                        Address2 = d.Address2,
                        Address3 = d.Address3,                        
                        City = d.City,
                        StateID = d.StateId,
                        StateName = d.State.Name,
                        Zip = d.Zip
                    }
                ).ToList();
            gvSchoolList.DataBind();
        }

        using (CocaDataContext ctx = new CocaDataContext()) {
            var x = from StudentGroupSeason apr in ctx.StudentGroupSeasons
                    where apr.Id == 1
                    select new { FirstName = apr.StudentSurveyDates };
        }
    }
}