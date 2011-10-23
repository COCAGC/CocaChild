using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using DAL;

public partial class Controls_StateControl : System.Web.UI.UserControl
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
            }
        }
    }

}