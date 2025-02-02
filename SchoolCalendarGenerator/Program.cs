using SchoolCalendarGenerator;

try
{
    const string filePath = "/Users/abyshobs/RiderProjects/SchoolCalendarGenerator/SchoolCalendarGenerator/InputFile.csv";
    var terms = InputFileReader.ReadSchoolTerms(filePath);

    ISchoolTermValidator validator = new SchoolTermValidator();
    foreach (var term in terms)
    {
        if (!validator.Validate(term))
        {
            Console.WriteLine($"Invalid term: {term.FullModule} ({term.Start} - {term.End})");
        }
    
        Console.WriteLine($"Start: {term.Start}, End: {term.End}, Full Module: {term.FullModule}, Academic Year: {term.AcademicYear}, Module: {term.Module}");
    }
}
catch (Exception e)
{
    Console.WriteLine("Something went wrong: " + e.Message);
}

