using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class SelectorControl : System.Web.UI.UserControl
{
    private const string KEY_SurveyID = "SurveyID";

    protected delegate void BindList();

    public event System.EventHandler SurveyIDChanged;

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

    public string SurveyID
    {
        get
        {
            return (string)ViewState[KEY_SurveyID];
        }
        private set
        {
            ViewState[KEY_SurveyID] = value;
        }
    }

    public bool LockSchool
    {
        get
        {
            return !ddlSchool.Enabled;
        }
        set
        {
            ddlSchool.Enabled = !value;
        }
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

                if (Request["SurveyID"] != null)
                    InitializeWithSurvey(ctx);
                else
                    InitializeWithFirstSchool();
            }
        }
    }

    private void InitializeWithFirstSchool() {
        ddlSchool.SelectedIndex = 0;

        BindYears();
        BindGroups();
        BindSeasons();
        BindSurveyID();
    }

    private void InitializeWithSurvey(CocaDataContext ctx)
    {
        long surveyId;
        if (long.TryParse(Request["SurveyId"], out surveyId))
        {
            Survey survey = (from s in ctx.Surveys where s.Id == surveyId select s).FirstOrDefault();
            if (survey != null)
            {
                if (SetDropDown(ddlSchool, survey.StudentGroup.SchoolYear.SchoolId.ToString(), BindYears))
                    if (SetDropDown(ddlYear, survey.StudentGroup.SchoolYear.Year.Name, BindGroups))
                        if (SetDropDown(ddlGroupName, survey.StudentGroupId.ToString(), BindSeasons))
                            SetDropDown(ddlSeason, survey.Season.Name, null);
                BindSurveyID();
            }
        }
    }

    // attempts to set the specified drop down to the value specified. If a delegate is supplied
    // and the attempt was successful, the delegate will be run and the result will be indicated
    private bool SetDropDown(ListControl list, string value, BindList bindListDelegate) {
        ListItem item = list.Items.FindByValue(value);
        if (item != null)
        {
            item.Selected = true;

            if (bindListDelegate != null)
                bindListDelegate();

            return true;
        }
        return false;
    }

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindYears();
        BindGroups();
        BindSeasons();
        BindSurveyID();

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGroups();
        BindSeasons();
        BindSurveyID();
    }

    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSeasons();
        BindSurveyID();
    }

    protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSurveyID();
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
                          GroupID = sg.Id,
                          GroupName = sg.Name
                      }
                  ).ToList();
            ddlGroupName.DataTextField = "GroupName";
            ddlGroupName.DataValueField = "GroupID";
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
                     where sea.Surveys.Any(sg => sg.StudentGroup.Id == groupID)
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

    private void BindSurveyID()
    {
        string initId = this.SurveyID;
        using (CocaDataContext ctx = new CocaDataContext())
        {
            long groupID = 0;
            long.TryParse(ddlGroupName.SelectedValue, out groupID);

            var survey = ctx.Surveys.Where(sgs => sgs.Season.Name == ddlSeason.SelectedValue && sgs.StudentGroup.Id == groupID).SingleOrDefault();
            if (survey != null)
                this.SurveyID = survey.Id.ToString();
            else
                this.SurveyID = null;
        }

        if (initId != this.SurveyID && this.SurveyIDChanged!=null)
            this.SurveyIDChanged(this, new SurveyIDChangedEventArgs(initId, this.SurveyID));
    }
}

public class SurveyIDChangedEventArgs : EventArgs
{
    public string OldId;
    public string NewId;

    public SurveyIDChangedEventArgs(string oldId, string newId)
    {
        this.OldId = oldId;
        this.NewId = newId;
    }
}