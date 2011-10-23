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
                //--------------------------
                ddlYear.DataSource = (
                    from Year y in ctx.Years
                    orderby y.Name
                    select new
                    {
                        YearName = y.Name                        
                    }
                ).ToList();
                ddlYear.DataTextField = "YearName";
                ddlYear.DataValueField = "YearName";
                ddlYear.DataBind();
                //--------------------------
                ddlGroupName.DataSource = (
                    from StudentGroup sg in ctx.StudentGroups
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
                //--------------------------
                ddlSeason.DataSource = (
                    from Season sea in ctx.Seasons
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

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
  
            string theType = ddlSchool.SelectedValue;

            ddlYear.DataSource = (
                  from Year y in ctx.Years //, SchoolYear sy in ctx.SchoolYears 
                     // where sy.SchoolId = theType
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
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            ddlGroupName.DataSource = (
                      from StudentGroup sg in ctx.StudentGroups
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

    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            ddlSeason.DataSource = (
                     from Season sea in ctx.Seasons
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
    protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}