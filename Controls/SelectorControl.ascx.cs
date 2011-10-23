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

    public string School
    {
        get { return ddlSchool.SelectedValue; }
    }

    public string Year
    {
        get { return ddlYear.SelectedValue; }
    }

    public string GroupName
    {
        get { return ddlGroupName.SelectedValue; }
    }

    public string Season
    {
        get { return ddlSeason.SelectedValue; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (CocaDataContext ctx = new CocaDataContext())
            {

                ddlSchool.DataSource = (
                        from School sc in ctx.Schools
                        orderby sc.Name
                        select new
                        {
                            ID = sc.Id,
                            Name = sc.Name
                        }
                    ).ToList();
                ddlSchool.DataTextField = "Name";
                ddlSchool.DataValueField = "ID";
                ddlSchool.DataBind();
                ddlSchool.SelectedIndex = 0;


                BindYears();
                BindGroups();
                BindSeasons();


            
                //--------------------------
            //    ddlYear.DataSource = (
            //        from Year y in ctx.Years
            //        orderby y.Name
            //        select new
            //        {
            //            YearName = y.Name
            //        }
            //    ).ToList();
            //    ddlYear.DataTextField = "YearName";
            //    ddlYear.DataValueField = "YearName";
            //    ddlYear.DataBind();
            //    --------------------------
            //    ddlGroupName.DataSource = (
            //        from StudentGroup sg in ctx.StudentGroups
            //        orderby sg.Name
            //        select new
            //        {
            //            StudentID = sg.Id,
            //            StudentGroup = sg.Name
            //        }
            //    ).ToList();
            //    ddlGroupName.DataTextField = "StudentGroup";
            //    ddlGroupName.DataValueField = "StudentID";
            //    ddlGroupName.DataBind();
            //    --------------------------
            //    ddlSeason.DataSource = (
            //        from Season sea in ctx.Seasons
            //        orderby sea.Name
            //        select new
            //        {
            //            SeasonName = sea.Name
            //        }
            //    ).ToList();
            //    ddlSeason.DataTextField = "SeasonName";
            //    ddlSeason.DataValueField = "SeasonName";
            //    ddlSeason.DataBind();
            }            
        }
    }    

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindYears();
        BindGroups();
        BindSeasons();

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGroups();
        BindSeasons();
    }

    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSeasons();
    }
    protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    private void BindYears()
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {

            long theType = long.Parse(ddlSchool.SelectedValue);

            ddlYear.DataSource = (
                  from Year y in ctx.Years
                  where y.SchoolYears.Any(sy => sy.School.Id == theType)
                  orderby y.Name
                  select new
                  {
                      YearName = y.Name
                  }
              ).ToList();
            ddlYear.DataTextField = "YearName";
            ddlYear.DataValueField = "YearName";
            ddlYear.DataBind();
        }
    }

    private void BindGroups()
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            ddlGroupName.DataSource = (
                      from StudentGroup sg in ctx.StudentGroups
                      where sg.SchoolYear.Year.Name == ddlYear.SelectedValue && sg.SchoolYear.School.Id == long.Parse(ddlSchool.SelectedValue)
                      orderby sg.Name
                      select new
                      {
                          StudentID = sg.Id,
                          StudentGroup = sg.Name
                      }
                  ).ToList();
            ddlGroupName.DataTextField = "StudentGroup";
            ddlGroupName.DataValueField = "StudentID";
            ddlGroupName.DataBind();
        }        
    }

    private void BindSeasons()
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            long groupID = 0;
            long.TryParse(ddlGroupName.SelectedValue, out groupID);

            ddlSeason.DataSource = (
                     from Season sea in ctx.Seasons
                     where sea.StudentGroupSeasons.Any(sg => sg.Id == groupID)
                     orderby sea.Name
                     select new
                     {
                         SeasonName = sea.Name
                     }
                 ).ToList();
            ddlSeason.DataTextField = "SeasonName";
            ddlSeason.DataValueField = "SeasonName";
            ddlSeason.DataBind();
        }
    }
}