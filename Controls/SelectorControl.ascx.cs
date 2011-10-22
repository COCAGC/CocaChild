using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using DAL;

public partial class SelectorControl : System.Web.UI.UserControl
{    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            using (CocaDataContext ctx = new CocaDataContext())
            {

                ddlSchool.DataSource = (
                        from School d in ctx.Schools
                        orderby d.Name
                        select new
                        {
                            ID = d.Id,
                            Name = d.Name
                        }
                    ).ToList();
                ddlSchool.DataTextField = "Name";
                ddlSchool.DataValueField = "ID";
                ddlSchool.DataBind();
                //--------------------------
                ddlYear.DataSource = (
                    from Year d in ctx.Years
                    orderby d.Name
                    select new
                    {
                        YearName = d.Name                        
                    }
                ).ToList();
                ddlYear.DataTextField = "YearName";
                ddlYear.DataValueField = "YearName";
                ddlYear.DataBind();
                //--------------------------
                ddlGroupName.DataSource = (
                    from StudentGroup d in ctx.StudentGroups
                    orderby d.Name
                    select new
                    {
                        StudentID = d.Id,
                        StudentGroup = d.Name                        
                    }
                ).ToList();
                ddlGroupName.DataTextField = "StudentGroup";
                ddlGroupName.DataValueField = "StudentID";
                ddlGroupName.DataBind();
                //--------------------------
                ddlSeason.DataSource = (
                    from Season d in ctx.Seasons
                    orderby d.Name
                    select new
                    {
                        SeasonName = d.Name
                    }
                ).ToList();
                ddlSeason.DataTextField = "SeasonName";
                ddlSeason.DataValueField = "SeasonName";
                ddlSeason.DataBind();
            }
            
        }
    }    

    public void dropdownBind()
    {
       // var results = ddl.SchoolYearList();
        //ddlSchool.DataSource = results;
        //ddlSchool.DataTextField = "SchoolYear";
        //ddlSchool.DataValueField = "SchoolYear";
        //ddlSchool.DataBind();
        //ddlSchool.SelectedValue = Convert.ToString(DateTime.Today.Year - 1) + "-" + Convert.ToString(DateTime.Today.Year);
        //if (String.IsNullOrEmpty(BaseProperties.propSchoolYear))
        //{
        //    BaseProperties.propSchoolYear = ddlSchoolYear.SelectedValue;
        //}
        //else
        //{
        //    ddlSchoolYear.SelectedValue = BaseProperties.propSchoolYear;
        //}
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}