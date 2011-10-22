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
    }
}