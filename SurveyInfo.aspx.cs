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
        DalOld dal = new DalOld();

        lvStudentBullyList.DataSource = dal.SurveyListView(1);
        lvStudentBullyList.DataBind();      

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