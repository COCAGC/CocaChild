using System;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.UI;
using DAL;

public partial class StartSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Make certain that the user is not signed in to Coca Administration before starting a survey
        // this prevents possibility of child seeing sensitive information.
        if(!Page.IsPostBack)
            FormsAuthentication.SignOut();

        // Disable page caching:
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddHours(-1);
        Response.Expires = -1500;
        Response.AddHeader("Pragma", "no-cache");
        Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        Response.Cache.SetNoStore();
    }

    protected void btnStartSurvey_Click(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            long anonStudentID = (from AnonStudent s in ctx.AnonStudents
                                      where s.UserId == txtStudentID.Text && s.Password == txtPassword.Text
                                       && s.SurveyId == Convert.ToInt32(SurveyIdTextbox.Text) 
                                       && s.SavedDate == null
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