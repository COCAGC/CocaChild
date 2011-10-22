using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListSchools : System.Web.UI.Page
{
    DAL SchoolView = new DAL();

    protected void Page_Load(object sender, EventArgs e)
    {        
        gvSchoolList.DataSource = SchoolView.SchoolListView();
        gvSchoolList.DataBind();

            //SchoolView.SchoolListView();

    }
}