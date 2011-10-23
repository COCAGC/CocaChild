using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class StartSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnStartSurvey_Click(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            long anonStudentID = (from AnonStudent s in ctx.AnonStudents
                                      where s.UserId == txtStudentID.Text && s.Password == txtPassword.Text
                                       && s.StudentGroupSeasonId == Convert.ToInt32(txtARPID.Text)
                                      select s.Id).FirstOrDefault();

            if (anonStudentID != 0)
            {
                Session["LoggedIn_AnonStudentId"] = anonStudentID;
                Response.Redirect("SurveyInfo.aspx");
            }
            else
            {
                lblLoginError.Text = "Login unsuccessful, try again.";
                lblLoginError.Visible = true;
            }
        }
    }
}