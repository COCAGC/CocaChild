using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class SurveyInfo : System.Web.UI.Page
{

    private long aprId
    {
        get { return 0; }
    }

    private long anonStudentId
    {
        get
        {
            var loggedInId = Session["LoggedIn_AnonStudentId"];
            if (loggedInId != null)
                return (long)loggedInId;
            return 4;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (anonStudentId == 0)
            Response.Redirect("~/StartSurvey.aspx");

        if (!IsPostBack)
        {

            using (CocaDataContext ctx = new CocaDataContext())
            {

                StudentGroupSeason sgs = (from AnonStudent a in ctx.AnonStudents where a.Id == this.anonStudentId select a.StudentGroupSeason).FirstOrDefault();
                Random randomNumber = new Random();
                gvStudentSurveyList.DataSource = (from d in
                                                      (
                                                         from StudentSurveyDate ssd in ctx.StudentSurveyDates
                                                         where ssd.StudentGroupSeason.Equals(sgs)
                                                         select new
                                                         {
                                                             fn = ssd.Student.FirstName,
                                                             ln = ssd.Student.LastName,
                                                             Id = ssd.Id
                                                         }
                                                     ).ToList()
                                                  select new { FirstName = d.fn, LastName = d.ln, Id = d.Id, RandomNumber = randomNumber.Next(5000) }).OrderBy(i => i.RandomNumber).ToList();
                gvStudentSurveyList.DataBind();
            }
        }
    }

    protected void FinishedId_Click(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            foreach (GridViewRow row in gvStudentSurveyList.Rows)
            {
                long ssdId = (long)gvStudentSurveyList.DataKeys[row.RowIndex].Value;
                TextBox commentText = (TextBox)row.FindControl("txtComment");
                StudentSurveyRating rating = new StudentSurveyRating();
                rating.AnonStudentId = this.anonStudentId;
                rating.StudentSurveyDateId = ssdId;
                rating.Comment = commentText.Text;

                ctx.StudentSurveyRatings.Attach(rating);
            }
            ctx.SubmitChanges();
        }

    }
}