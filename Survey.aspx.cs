using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Survey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (CocaDataContext ctx = new CocaDataContext())
            {

                ddlSeason.DataSource = (
                            from Season d in ctx.Seasons
                            orderby d.Id
                            select new
                            {
                                ID = d.Id,
                                Name = d.Name
                            }
                        ).ToList();
                ddlSeason.DataTextField = "Name";
                ddlSeason.DataValueField = "ID";
                ddlSeason.DataBind();
                ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));

                ddlGrade.DataSource = (
                           from ClassLevel d in ctx.ClassLevels
                           orderby d.Id
                           select new
                           {
                               ID = d.Id,
                               Name = d.Name
                           }
                       ).ToList();
                ddlGrade.DataTextField = "Name";
                ddlGrade.DataValueField = "ID";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, new ListItem("--Select Grade--", "0"));
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //CocaDataContext ctx = new CocaDataContext();
        //School sch = new School();
        //sch.Name = txtSchool.Text;
        //sch.Address1 = txtAddress1.Text;
        //sch.Address2 = txtAddress2.Text;
        //sch.Address3 = txtAddress3.Text;
        //sch.City = txtCity.Text;
        //sch.StateId = Convert.ToInt32(ddlStates.SelectedValue);
        //sch.Zip = txtZip.Text;

        //ctx.Schools.InsertOnSubmit(sch);

        //ctx.SubmitChanges();
    }
}