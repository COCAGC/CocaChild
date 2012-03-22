using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.Page
{
   // public string _season { get { return selControls.Season; } }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        string surveyID = selControls.SurveyID;

        if (!String.IsNullOrEmpty(surveyID))

            switch (rblSelectReport.SelectedIndex)
            {
                case 0:
                    if (!String.IsNullOrEmpty(surveyID))
                        Response.Redirect(String.Format("ReportClassRmSmry.aspx?SurveyId={0}", surveyID));
                    break;
                case 1:
                    if (!String.IsNullOrEmpty(surveyID))
                        Response.Redirect(String.Format("ReportClassRmDetail.aspx?SurveyId={0}", surveyID));
                    break;
                case 2:
                    if (!String.IsNullOrEmpty(surveyID))
                        Response.Redirect(String.Format("ReportCommentDetail.aspx?SurveyId={0}", surveyID));
                    break;                    
                case 3:
                     if (!String.IsNullOrEmpty(surveyID))
                        Response.Redirect(String.Format("ReportsPrepSeason2.aspx?SurveyId={0}", surveyID));
                    break;                    
                case 4:
                     if (!String.IsNullOrEmpty(surveyID))
                        Response.Redirect(String.Format("ReportAnonUser.aspx?SurveyId={0}", surveyID));
                    break;
                default:
                    if (!String.IsNullOrEmpty(surveyID))
                        Response.Redirect(String.Format("ReportAnonUser.aspx?SurveyId={0}", surveyID));
                    break;

            }

        
    }
}