using SchoolCalendarGenerator;

try
{
    const string filePath = "/Users/abyshobs/RiderProjects/SchoolCalendarGenerator/SchoolCalendarGenerator/InputFile.csv";
    var termDates = InputFileReader.ReadSchoolTerms(filePath);
    
    ISchoolTermValidator validator = new SchoolTermValidator();
    Console.WriteLine("These are the school terms...");
    foreach (var term in termDates)
    {
        if (!validator.Validate(term))
        {
            Console.WriteLine($"Invalid term: {term.FullModule} ({term.Start} - {term.End})");
        }
    
        Console.WriteLine($"Start: {term.Start}, End: {term.End}, Full Module: {term.FullModule}, Academic Year: {term.AcademicYear}, Module: {term.Module}");
    }
    
    Console.WriteLine("Generating school calendar...");
    
    ICalendarGenerator calendarGenerator = new CalendarGenerator();
    var schoolCalendar = calendarGenerator.GenerateSchoolCalendar(termDates);
    foreach (var academicDay in schoolCalendar.ToList())
    {
        Console.WriteLine($"Date: {academicDay.Date}, Week Number : {academicDay.WeekNumber}, Weekday Name: {academicDay.WeekdayName}, Weekday Name Short: {academicDay.WeekdayNameShort}, Weekday Index: {academicDay.WeekdayIndex}, Month Name: {academicDay.MonthName}, Month Index: {academicDay.MonthIndex}, Academic Year: {academicDay.AcademicYear}, Academic Year Short: {academicDay.AcademicYearShort}, Academic Year Start: {academicDay.AcademicYearStart}, Academic Year End: {academicDay.AcademicYearEnd}, Full Module Name: {academicDay.FullModuleName}, Module Index: {academicDay.ModuleIndex}");
    }

}
catch (Exception e)
{
    Console.WriteLine("Something went wrong: " + e.Message);
}

