using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class CreateSchool : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (CocaDataContext ctx = new CocaDataContext())
            {

                ddlStates.DataSource = (
                            from State d in ctx.States
                            orderby d.Name
                            select new
                            {
                                ID = d.Id,
                                State = d.Name
                            }
                        ).ToList();
                ddlStates.DataTextField = "State";
                ddlStates.DataValueField = "ID";
                ddlStates.DataBind();
                ddlStates.Items.Insert(0, new ListItem("--Select State--","0"));       
        
            }
        }

    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CocaDataContext ctx = new CocaDataContext();
        School sch = new School();
        sch.Name = txtSchool.Text;
        sch.Address1 = txtAddress1.Text;
        sch.Address2 = txtAddress2.Text;
        sch.Address3 = txtAddress3.Text;
        sch.City = txtCity.Text;
        sch.StateId = Convert.ToInt32(ddlStates.SelectedValue);
        sch.Zip = txtZip.Text;

        ctx.Schools.InsertOnSubmit(sch);            

        ctx.SubmitChanges();

        MsgText.Text = "School successfully created.";
        MsgText.Visible = true;
        
    }
}