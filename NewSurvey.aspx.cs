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
            grades = context.ClassLevels.Select(l => l.Name).ToList();
            schools = context.Schools.Select(s => s.Name).ToList();
        }

        if (!IsPostBack)
        {
            SeasonSelector.DataSource = seasonNames;
            SeasonSelector.DataBind();
            SchoolYearSelector.DataSource = years;
            SchoolYearSelector.DataBind();
            GradeSelector.DataSource = grades;
            GradeSelector.DataBind();
            SchoolSelector.DataSource = schools;
            SchoolSelector.DataBind();
        }
    }



    public void UploadAction()
    {
        string seasonName = GetSeasonName();
        using (CocaDataContext context = new CocaDataContext())
        {
            var students = new List<Student>();

            var items = GetCSVRows();

            StudentGroup group = GenerateAndInsertNewStudentGroup(context);

            var studentGroupSeason = GenerateStudentGroupSeason(context, seasonName, group);


            foreach (StudentCSVImportItem row in items)
            {
                var student = new Student();
                student.FirstName = row.FirstName;
                student.LastName = row.LastName;
                student.TeacherName = row.Teacher;
                student.StudentGroup = group;
                students.Add(student);
            }
           
            context.Students.InsertAllOnSubmit<Student>(students);

            context.SubmitChanges();

            ExecuteStoredProcedure(context, studentGroupSeason.Id);                  
        }
    }

    private StudentGroup GenerateAndInsertNewStudentGroup(CocaDataContext ctx)
    {
        var schoolYear = new SchoolYear()
            {                
                Year = ctx.Years.Where(y => y.Name == SchoolYearSelector.SelectedValue).SingleOrDefault(),
                School = ctx.Schools.Where(s=> s.Name == SchoolSelector.SelectedValue).SingleOrDefault()                  
            };
        ctx.SchoolYears.InsertOnSubmit(schoolYear);


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

    protected void OnUploadClick(object sender, EventArgs e)
    {
        UploadAction();
    }

    private void ExecuteStoredProcedure(CocaDataContext ctx, long groupId)
    {
        ctx.ExecuteCommand("exec coca_AddAllStudentsAndGenerateAnnonLogins @StudentGroupSeasonId = {0}", groupId);
    }

    private string GetSeasonName()
    {
        return SeasonSelector.SelectedValue;
    }

    private StudentGroupSeason GenerateStudentGroupSeason(CocaDataContext ctx, string seasonName, StudentGroup group)
    {
        var season = ctx.Seasons.Where(s => s.Name == seasonName).SingleOrDefault();
        DateTime date;
        if(!DateTime.TryParse(SurveyDate.Text, out date))
            throw new InvalidDataException("Not a date");

        var groupSeason = new StudentGroupSeason()
            {
                Season = season,
                SurveyDate = date,
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