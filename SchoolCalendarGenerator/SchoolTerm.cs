using System.Globalization;
using CsvHelper.Configuration.Attributes;

namespace SchoolCalendarGenerator;

public class SchoolTerm
{
    [Name("Start")]
    public required string StartDateString { get; init; }

    [Name("End")]
    public required string EndDateString { get; init; }
    
    [Name("Full Module")]
    public required string FullModule { get; init; }
    
    [Name("Academic Year")]
    public required string AcademicYear { get; init; }    
    
    [Name("Module")]
    public required string Module { get; init; }
    
    public DateOnly Start => ParseDate(StartDateString);
    public DateOnly End => ParseDate(EndDateString);
    
    private static DateOnly ParseDate(string date)
    {
        if (DateOnly.TryParseExact(date, ["d/M/yyyy", "dd/MM/yyyy"], CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
        {
            return parsedDate;
        }

        throw new FormatException($"Invalid date format: '{date}'"); 
    }
}