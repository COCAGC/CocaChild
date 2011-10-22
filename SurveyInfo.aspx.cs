using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class SurveyInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //using (CocaDataContext ctx = new CocaDataContext())
        //{
        //    var s = from StudentGroupSeason apr in StudentGroupSeason
        //            where apr.Id == 1
        //            select new
        //            {
        //                FirstName = apr.StudentSurveyDate.Students.FirstName,
        //                LastName = apr.StudentSurveyDate.Students.LastName
        //            };
        //}
        using (CocaDataContext ctx = new CocaDataContext())
        {

            IQueryable<StudentSurveyDate> ssds = from StudentSurveyDate ssd in ctx.StudentSurveyDates where ssd.StudentGroupSeason.Id == 1 || true select ssd;

            lvStudentBullyList.DataSource = (from StudentSurveyDate ssd in ssds select new { FirstName = ssd.Student.FirstName, LastName = ssd.Student.LastName, Id = ssd.Id, Comments="Test" }).ToList();
            lvStudentBullyList.DataBind();
        }
    }
    
    protected void FinishedId_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < lvStudentBullyList.Items.Count(); i++)
      {
        //Get the label by row
          TextBox l = (TextBox)lvStudentBullyList.Items[i].FindControl("txtComments");
       
 
        string s = l.Text;
      }



    }
}