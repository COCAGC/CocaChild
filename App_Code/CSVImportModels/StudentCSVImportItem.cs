using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

/// <summary>
/// Summary description for StudentCSVImportItem
/// </summary>

[IgnoreFirst(1)]
[DelimitedRecord(",")]
public sealed class StudentCSVImportItem
{

    public String FirstName;

    public String LastName;

    public String Classroom;


}
