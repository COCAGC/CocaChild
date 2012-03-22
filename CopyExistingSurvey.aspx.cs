using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DAL;
using FileHelpers;


public partial class CopyExistingSurvey : System.Web.UI.Page
{
    private long _school { get { return long.Parse(selControls.School); } }
    public string _year { get { return selControls.Year; } }
    public long _groupId { get { return long.Parse(selControls.GroupName); } }
    public string _season { get { return selControls.Season; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorText.Visible = false;
        if (!IsPostBack)
        {
            StudentGrid.Visible = false;
        }
    }

    protected void OnbtnCopyClick(object sender, EventArgs e)
    {
        FillGrid();
    }

    private void FillGrid()
    {
        StudentGrid.Visible = true;
        StudentGrid.DataSource = retrieveStudents();
        StudentGrid.DataBind();
    }

    protected void OnbtnExportClick(object sender, EventArgs e)
    {
        var students = retrieveStudents();
        if (students.Count < 1)
            return;

        List<StudentCSVImportItem> studentRows = students.Select(s => new StudentCSVImportItem()
                {
                    Classroom = s.ClassRoom,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList();

        studentRows.Insert(0, new StudentCSVImportItem() { FirstName = "First Name", LastName = "Last Name", Classroom = "Classroom" });
        FileHelperEngine<StudentCSVImportItem> engine = new FileHelperEngine<StudentCSVImportItem>();
        MemoryStream stream = new MemoryStream();
        TextWriter writer = new StreamWriter(stream);
        engine.WriteStream(writer, studentRows);
        writer.Close();

        HttpResponse response = Response;

        //Get data to output here...

        //Turn off Caching and enforce a content type that will prompt to download/save.
        response.AddHeader("Connection", "close");
        response.AddHeader("Cache-Control", "private");
        response.ContentType = "application/octect-stream";

        //Give the browser a hint at the name of the file.
        response.AddHeader("content-disposition", "attachment; filename=export.csv");

        response.BinaryWrite(stream.GetBuffer());

        response.Flush();
        response.Close();

    }

    private IList<Student> retrieveStudents()
    {
        IList<Student> students;
        try
        {
            using (CocaDataContext ctx = new CocaDataContext())
            {
                var school = ctx.Schools.Where(s => s.Id == _school).SingleOrDefault();
                var year = school.SchoolYears.Where(y => y.Year.Name == _year).SingleOrDefault();
                var group = year.StudentGroups.Where(g => g.Id == _groupId && g.Surveys.Any(sg => sg.Season.Name == _season || string.IsNullOrEmpty(_season))).SingleOrDefault();
                students = group.Students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();

                if (students.Count < 1) throw new InvalidDataException("No students found");
            }
        }
        catch (Exception ex)
        {
            ErrorText.Text = "Unable to find the students for the data you selected:" + ex.Message;
            ErrorText.Visible = true;
            return null;
        }

        return students;
    }

    //Grid Methods

    protected void StudentGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        StudentGrid.EditIndex = e.NewEditIndex;
        FillGrid();
    }


    protected void StudentGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string firstName = ((TextBox)((GridView)sender).Rows[e.RowIndex].FindControl("fnameEdit")).Text;
        string lastName = ((TextBox)((GridView)sender).Rows[e.RowIndex].FindControl("lnameEdit")).Text;
        string classroom = ((TextBox)((GridView)sender).Rows[e.RowIndex].FindControl("classroomEdit")).Text;
        long id = (long)((GridView)sender).DataKeys[e.RowIndex].Value;

        using (CocaDataContext ctx = new CocaDataContext())
        {
            Student student = (from s in ctx.Students where s.Id == id select s).FirstOrDefault();
            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.ClassRoom = classroom;

                ctx.SubmitChanges();
            }
        }
        StudentGrid.EditIndex = -1;
        FillGrid();
    }

    protected void StudentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long id = (long)((GridView)sender).DataKeys[e.RowIndex].Value;
        using (CocaDataContext ctx = new CocaDataContext())
        {
            Student student = (from s in ctx.Students where s.Id == id select s).FirstOrDefault();
            if (student != null)
            {
                ctx.Students.DeleteOnSubmit(student);
                ctx.SubmitChanges();
            }
        }
        StudentGrid.EditIndex = -1;
        FillGrid();
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        using (CocaDataContext ctx = new CocaDataContext())
        {
            var school = ctx.Schools.Where(s => s.Id == _school).SingleOrDefault();
            var year = school.SchoolYears.Where(y => y.Year.Name == _year).SingleOrDefault();
            StudentGroup group = year.StudentGroups.Where(g => g.Id == _groupId && g.Surveys.Any(sg => sg.Season.Name == _season || string.IsNullOrEmpty(_season))).SingleOrDefault();

            Student student = new Student() { FirstName="", LastName = "", ClassRoom = "", StudentGroup = group};

            ctx.Students.InsertOnSubmit(student);
            ctx.SubmitChanges();
        }
        StudentGrid.EditIndex = 0;
        FillGrid();
    }

    protected void StudentGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        StudentGrid.EditIndex = -1;
        FillGrid();
    }

}