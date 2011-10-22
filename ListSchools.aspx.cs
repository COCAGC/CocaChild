using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Data.Linq;

public partial class ListSchools : System.Web.UI.Page
{
    DalOld SchoolView = new DalOld();

    protected void Page_Load(object sender, EventArgs e)
    {
        using(CocaDataContext ctx = new CocaDataContext()){
       
            gvSchoolList.DataSource = (from School d in ctx.Schools select new {Name = d.Name , City = d.City, StateName = d.State.Name, Zip = d.Zip}).ToList();
            gvSchoolList.DataBind();
        }
        //var sv = SchoolView.SchoolListView().ToTable();
       
 
        //gvSchoolList.DataSource = SchoolView.SchoolListView();
        //gvSchoolList.DataBind();
        //using(CocaDataContext ctx = new CocaDataContext()){
            //var data = from d in ctx.Schools select d;

            //var sortedWords =
            //    from w in words
            //    orderby w.Length
            //    select w;, 

            //var results = (from School d in ctx.Schools orderby d.Name select d);
                //.Including(d => d.State); 


            //gvSchoolList.DataSource = SchoolView.SchoolListView();
           // gvSchoolList.DataSource = results.ToList();
            //gvSchoolList.DataSource = SchoolsWithStates;
            //gvSchoolList.DataSource = Schools;
            //gvSchoolList.DataBind();
        }
       
            //SchoolView.SchoolListView();

    //public static IList<customer> CustomersWithOrders
    //{
    //    get
    //    {
    //        return Customers
    //                .Select(c => new { Customer = c, Orders = c.Orders })
    //        .ToList()
    //                .Select(pair => pair.Customer)
    //        .ToList();
    //    }
    //}
    //public static IList<School> SchoolsWithStates
    //{
    //    get
    //    {
    //        return SchoolsWithStates
    //                .Select(c => new { School = c, States = c.State.Name })
    //        .ToList()
    //                .Select(pair => pair.States)
    //        .ToList();
    //    }
    //}

    //public static IList<School> Schools
    //{
    //    get
    //    {
    //        return Schools  
    //                .Select(c => new { School = c })
    //        .ToList();
    //    }
    //}
}