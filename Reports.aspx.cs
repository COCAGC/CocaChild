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
        string seasonGroupID = selControls.SeasonGroupID;

        if (!String.IsNullOrEmpty(seasonGroupID))

            switch (rblSelectReport.SelectedIndex)
            {
                case 0:
                    if (!String.IsNullOrEmpty(seasonGroupID))
                        Response.Redirect(String.Format("ReportClassRmSmry.aspx?StudentGroupSeasonId={0}", seasonGroupID));
                    break;
                case 1:
                    if (!String.IsNullOrEmpty(seasonGroupID))
                        Response.Redirect(String.Format("ReportClassRmDetail.aspx?StudentGroupSeasonId={0}", seasonGroupID));
                    break;
                case 2:
                    if (!String.IsNullOrEmpty(seasonGroupID))
                        Response.Redirect(String.Format("ReportCommentDetails.aspx?StudentGroupSeasonId={0}", seasonGroupID));
                    break;                    
                case 3:
                     if (!String.IsNullOrEmpty(seasonGroupID))
                        Response.Redirect(String.Format("ReportCompareSeasons.aspx?StudentGroupSeasonId1={0}&StudentGroupSeasonId2={1}", seasonGroupID, seasonGroupID));
                    break;                    
                case 4:
                     if (!String.IsNullOrEmpty(seasonGroupID))
                        Response.Redirect(String.Format("ReportAnonUser.aspx?StudentGroupSeasonId={0}", seasonGroupID));
                    break;
                default:
                    if (!String.IsNullOrEmpty(seasonGroupID))
                        Response.Redirect(String.Format("ReportAnonUser.aspx?StudentGroupSeasonId={0}", seasonGroupID));
                    break;

            }

        
    }
}