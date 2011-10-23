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
            bool anonStudentExists = (from AnonStudent s in ctx.AnonStudents
                                      where s.UserId == txtStudentID.Text && s.Password == txtPassword.Text
                                       && s.StudentGroupSeasonId == Convert.ToInt32(txtARPID.Text)
                                      select s).Any();

            if (anonStudentExists)
            {
                //Session.Add() = txtStudentID.Text;
            }
        }
    }
    protected void btnStartSurvey_Click(object sender, EventArgs e)
    {

    }
}