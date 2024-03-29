﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class SurveyInfo : System.Web.UI.Page
{
    private const string KEY_AnonStudent = "LoggedIn_AnonStudentId";
    private const string PAGE_StudentLogin = "~/StartSurvey.aspx";

    private long surveyId
    {
        get { return 0; }
    }

    private long anonStudentId
    {
        get
        {
            var loggedInId = Session[KEY_AnonStudent];
            if (loggedInId != null)
                return (long)loggedInId;
            return 4;
        }
    }

    private void ReturnToLogin() {
        Response.Redirect(PAGE_StudentLogin);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Disable page caching:
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddHours(-1);
        Response.Expires = -1500;
        Response.AddHeader("Pragma", "no-cache");
        Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        Response.Cache.SetNoStore();

        if (anonStudentId == 0)
            ReturnToLogin();

        if (!IsPostBack)
        {

            using (CocaDataContext ctx = new CocaDataContext())
            {
                // HACK: Not sure why, but compiler is requiring that "Survey" is namespace qualified even though there is a using statement
                //       and there are no other "Survey" definitions in the page without that using.
                DAL.Survey su = (from AnonStudent a in ctx.AnonStudents where a.Id == this.anonStudentId select a.Survey).FirstOrDefault();
                Random randomNumber = new Random();
                gvStudentSurveyList.DataSource = (from d in
                                                      (
                                                         from SurveyStudent ssd in ctx.SurveyStudents
                                                         where ssd.Survey.Equals(su)
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
            AnonStudent loggedInStudent = (from AnonStudent a in ctx.AnonStudents where a.Id == this.anonStudentId select a).FirstOrDefault();
            List<SurveyStudent> ssds = (from SurveyStudent ssd in ctx.SurveyStudents
                                                  where ssd.Survey.Equals(loggedInStudent.Survey)
                                                  select ssd).ToList();
            foreach (GridViewRow row in gvStudentSurveyList.Rows)
            {
                long ssdId = (long)gvStudentSurveyList.DataKeys[row.RowIndex].Value;
                SurveyStudent ssd = (from s in ssds where s.Id == ssdId select s).FirstOrDefault();
                
                TextBox commentText = (TextBox)row.FindControl("txtComment");
                DropDownList bullyAmount = (DropDownList)row.FindControl("ddlBullyTimes");
                DropDownList targetAmount = (DropDownList)row.FindControl("ddlTargetTimes");

                StudentSurveyRating rating = new StudentSurveyRating();

                rating.AnonStudent = loggedInStudent;
                rating.SurveyStudent = ssd;
                int timesBully;
                int timesTarget;
                if(!string.IsNullOrEmpty(bullyAmount.SelectedValue) && int.TryParse(bullyAmount.SelectedValue,out timesBully  ))
                    rating.IsBullyValue = timesBully;
                if(!string.IsNullOrEmpty(targetAmount.SelectedValue) && int.TryParse(targetAmount.SelectedValue, out timesTarget))
                    rating.IsTargetValue = timesTarget;
                rating.Comment = commentText.Text;

                ctx.StudentSurveyRatings.InsertOnSubmit(rating);
              
            }
            loggedInStudent.SavedDate = DateTime.Today;
            loggedInStudent.LoggedInDate = DateTime.Now;
            Session.Remove(KEY_AnonStudent);
            ctx.SubmitChanges();
            Session.Clear();
            ReturnToLogin();
        }
    }
}