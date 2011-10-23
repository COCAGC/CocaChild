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
            Random randomNumber = new Random();
            lvStudentBullyList.DataSource = (from d in 
                (
                   from StudentSurveyDate ssd in ssds
                   select new
                   {
                       fn = ssd.Student.FirstName,
                       ln = ssd.Student.LastName,
                       Id = ssd.Id
                   }
               ).ToList() select new {FirstName = d.fn, LastName = d.ln, Id = d.Id, Comment = "Test", RandomNumber = randomNumber.Next(5000)}).OrderBy(i => i.RandomNumber).ToList();
            lvStudentBullyList.DataBind();
        }
    }

    private int GetRandom(string Name) {
        Random rn = new Random();
        return rn.Next();
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