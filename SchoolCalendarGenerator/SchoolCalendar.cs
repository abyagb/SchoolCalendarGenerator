namespace SchoolCalendarGenerator;

public class SchoolCalendar
{
    public DateOnly Date { get; set; }
    public required string WeekdayName { get; set; }
    public required string WeekdayNameShort { get; set; }
    public required int WeekdayIndex { get; set; }
    public int WeekNumber { get; set; }
    public required string MonthName { get; set; }
    public int MonthIndex { get; set; }
    public required string AcademicYear { get; set; }
    public required string AcademicYearShort { get; set; }
    public int AcademicYearStart { get; set; }
    public int AcademicYearEnd { get; set; }
    public required string FullModuleName { get; set; }
    public int ModuleIndex { get; set; }
}