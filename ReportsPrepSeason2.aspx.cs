using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class ReportsPrepSeason2 : System.Web.UI.Page
{
    private string _surveyID;
    private List<MatchStudent> _survey2Unmatched;

    // public string _season { get { return selControls.Season; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        _surveyID = Request["SurveyId"];
    }

    protected void UnmatchedRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            DropDownList surveyList = (DropDownList)e.Item.FindControl("SurveyUnmatchedList");
            surveyList.DataSource = _survey2Unmatched;
            surveyList.DataTextField = "Name";
            surveyList.DataValueField = "Id";
            surveyList.DataBind();

            long matchValue = ((MatchStudent)e.Item.DataItem).MatchToId;
            if (matchValue > 0)
            {
                ListItem item = surveyList.Items.FindByValue(matchValue.ToString());
                if (item != null)
                    item.Selected = true;
            }
        }
    }

    protected void selControl_SurveyIdChanged(object sender, EventArgs e)
    {
        SurveyIDChangedEventArgs sicea = (SurveyIDChangedEventArgs)e;
        using (DAL.CocaDataContext ctx = new DAL.CocaDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString))
        {
            long surveyId;
            long.TryParse(_surveyID, out surveyId);

            long compareToSurveyId;
            long.TryParse(sicea.NewId, out compareToSurveyId);

            // get unmatched students from second survey for dropdown lists
            _survey2Unmatched = (
                    from s in ctx.coca_GetUnmatchedStudents(compareToSurveyId, surveyId)
                    orderby s.LastName ascending, s.FirstName ascending
                    select new MatchStudent(s.Id, 0, string.Format("{0} {1}", s.FirstName, s.LastName))
                ).ToList();

            // get unmatched students in first survey to match against the second
            var students = (
                    from s in ctx.coca_GetUnmatchedStudents(surveyId, compareToSurveyId)
                    select new { Id = s.Id, First = s.FirstName, Last = s.LastName }
                ).ToList();
            long[] unmatchedIds1 = (from s in students select s.Id).ToArray();
            var matches = (
                    from m in ctx.StudentMatches
                    join s in ctx.SurveyStudents on m.MatchingStudentId equals s.StudentId 
                    where unmatchedIds1.Contains(m.StudentId) && s.SurveyId == compareToSurveyId
                    select new { Id = m.StudentId, MatchId = m.MatchingStudentId }
                ).ToList();

            var data = (
                    from s in students
                    join m in matches on s.Id equals m.Id into o
                    from m in o.DefaultIfEmpty(null)
                    orderby s.Last, s.First
                    select new MatchStudent(s.Id, m != null ? m.MatchId : 0, string.Format("{0} {1}", s.First, s.Last))
                ).ToList();

            // bind them to the repater
            UnmatchStudentsRepeater.DataSource = data;
            UnmatchStudentsRepeater.DataBind();

        }

    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("ReportCompareSeasons.aspx?SurveyId={0}&CompareToSurveyId={1}", _surveyID, selControls.SurveyID));
    }

    protected void ModifyMatchList(object sender, EventArgs e)
    {
        using (DAL.CocaDataContext ctx = new DAL.CocaDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString))
        {
            foreach (RepeaterItem item in UnmatchStudentsRepeater.Items)
            {
                HiddenField idField = (HiddenField)item.FindControl("StudentIdField");
                DropDownList surveyList = (DropDownList)item.FindControl("SurveyUnmatchedList");

                long id;
                long.TryParse(idField.Value, out id);

                long matchId;
                long.TryParse(surveyList.SelectedValue, out matchId);


                if(id > 0) {
                    DAL.StudentMatch sm;
                    sm = (from s in ctx.StudentMatches where s.StudentId == id && s.MatchingStudentId == matchId select s).FirstOrDefault();

                    // check to see if the match already exists. if so ignore
                    if (sm == null)
                    {

                        // okay, exact match does not exist, now check to see if student on left
                        // is already related to a student on the right.
                        long surveyId;
                        long.TryParse(_surveyID, out surveyId);
                        sm = (from m in ctx.StudentMatches
                              join s in ctx.SurveyStudents on m.MatchingStudentId equals s.StudentId
                              where m.StudentId == id && s.SurveyId == surveyId
                              select m).FirstOrDefault();

                        // if yes, modify the match on the right, otherwise create a new match
                        if (sm != null)
                        {
                            sm.MatchingStudentId = matchId;
                        }
                        else
                        {
                            if (matchId > 0)
                            {
                                sm = new DAL.StudentMatch() { StudentId = id, MatchingStudentId = matchId };
                                ctx.StudentMatches.InsertOnSubmit(sm);
                            }
                        }
                    }
                }
            }
            ctx.SubmitChanges();
        }
    }

}

public class MatchStudent
{

    public MatchStudent(long id, long matchToId, string name)
    {
        this.Id = id;
        this.MatchToId = matchToId;
        this.Name = name;
    }
    public long Id { get; private set; }
    public long MatchToId { get; private set; }
    public string Name { get; private set; }

}