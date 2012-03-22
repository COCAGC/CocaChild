using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileHelpers;
using System.IO;
using DAL;

public partial class NewSurvey : System.Web.UI.Page
{
    protected string ReportUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> seasonNames;
        List<string> grades;
        List<string> years;
        List<string> schools;

        using (CocaDataContext context = new CocaDataContext())
        {
            seasonNames = context.Seasons.Select(s=> s.Name).ToList();
            years = context.Years.Select(y => y.Name).ToList();
            grades = context.ClassLevels.OrderBy(l => l.Weight).Select(l => l.Name).ToList();
            schools = context.Schools.Select(s => s.Name).ToList();
        }

        if (!IsPostBack)
        {
            SeasonSelector.DataSource = seasonNames;
            SeasonSelector.DataBind();
            SeasonSelector.Items.Insert(0, new ListItem("--Select Season--", "0"));

            SchoolYearSelector.DataSource = years;
            SchoolYearSelector.DataBind();
            SchoolYearSelector.Items.Insert(0, new ListItem("--Select Year--", "0"));

            GradeSelector.DataSource = grades;
            GradeSelector.DataBind();
            GradeSelector.Items.Insert(0, new ListItem("--Select Grade--", "0"));

            SchoolSelector.DataSource = schools;
            SchoolSelector.DataBind();
            SchoolSelector.Items.Insert(0, new ListItem("--Select School--", "0"));

        }
    }



    public void UploadAction()
    {
        string seasonName = GetSeasonName();
        using (CocaDataContext context = new CocaDataContext())
        {
            var students = new List<Student>();

            var items = GetCSVRows();
            if (items.Count() < 1)
            {
                ErrorText.Text = "Please look for a file using the browse button before hitting upload";
                ErrorText.Visible = true;
                return;
            }

            StudentGroup group = GenerateAndInsertNewStudentGroup(context);

            DAL.Survey survey = (DAL.Survey)GenerateSurvey(context, seasonName, group);

            foreach (StudentCSVImportItem row in items)
            {
                var student = new Student();
                var trimChars = new char[] { ' ', '"' };
                student.FirstName = row.FirstName.Trim(trimChars);
                student.LastName = row.LastName.Trim(trimChars);
                student.ClassRoom = row.Classroom.Trim(trimChars);
                student.StudentGroup = group;
                students.Add(student);
            }
           
            context.Students.InsertAllOnSubmit<Student>(students);

            context.SubmitChanges();


            ExecuteStoredProcedure(context, survey.Id);
            ReportUrl = string.Format("ReportAnonUser.aspx?SurveyId={0}", survey.Id);
            Page.DataBind();
            LinkToUserList.Visible = true;
        }
    }

    private StudentGroup GenerateAndInsertNewStudentGroup(CocaDataContext ctx)
    {

        SchoolYear schoolYear;

        Year yr = ctx.Years.Where(y => y.Name == SchoolYearSelector.SelectedValue).SingleOrDefault();
        School sch = ctx.Schools.Where(s => s.Name == SchoolSelector.SelectedValue).SingleOrDefault();

        schoolYear = (from sy in ctx.SchoolYears where sy.Year.Equals(yr) && sy.School.Equals(sch)
                         select sy).FirstOrDefault();

        if (schoolYear == null)
        {
            schoolYear = new SchoolYear()
                {                
                    Year = yr,
                    School = sch                
                };

            ctx.SchoolYears.InsertOnSubmit(schoolYear);
        }        


        var studentGroup = new StudentGroup()
            {
                SchoolYear = schoolYear,
                ClassLevel = ctx.ClassLevels.Where(l => l.Name == GradeSelector.SelectedValue).SingleOrDefault(),
                Name = GroupName.Text      
            };

        ctx.StudentGroups.InsertOnSubmit(studentGroup);
        ctx.SubmitChanges();
        
        return studentGroup;        
    }

    //protected void OnUploadClick(object sender, EventArgs e)
    //{
    //    UploadAction();
    //}

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        UploadAction();
        MsgText.Text = "Survey successfully uploaded!.";
        MsgText.Visible = true;
    }

    private void ExecuteStoredProcedure(CocaDataContext ctx, long groupId)
    {
        ctx.ExecuteCommand("exec coca_AddAllStudentsAndGenerateAnonLogins @SurveyId = {0}", groupId);
    }

    private string GetSeasonName()
    {
        return SeasonSelector.SelectedValue;
    }

    //HACK: Not sure why, but compiler is requiring that Survey be Namespace qualified
    //      despite the using DAL statement.
    private DAL.Survey GenerateSurvey(CocaDataContext ctx, string seasonName, StudentGroup group)
    {
        var season = ctx.Seasons.Where(s => s.Name == seasonName).SingleOrDefault();
        DateTime date;
        if(!DateTime.TryParse(SurveyDate.Text, out date))
            throw new InvalidDataException("Not a date");

        var groupSeason = new DAL.Survey()
            {
                Season = season,
                SurveyDate = date,
                //SurveyDate = SurveyDate.SelectedDate,
                StudentGroup = group
            };
       
        return groupSeason;
    }

    private StudentCSVImportItem[] GetCSVRows()
    {       
        StreamReader sr = new StreamReader(File.FileContent);
        FileHelperEngine<StudentCSVImportItem> engine = new FileHelperEngine<StudentCSVImportItem>();
        var items = engine.ReadStream(sr);
        return items;
    }

}