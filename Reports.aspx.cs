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
      //  string seasonGroupID = selControls.SeasonGroupID;
        int seasonGroupID = 0;
        bool result = int.TryParse(selControls.SeasonGroupID, out seasonGroupID);
        Response.Redirect(String.Format("/ReportAnonUser.aspx?StudentGroupSeasonId={0}", seasonGroupID));

       


    }
}