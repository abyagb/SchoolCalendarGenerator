namespace SchoolCalendarGenerator;

public class CalendarGenerator : ICalendarGenerator
{
    private int _currentWeekNumber = 1;
    private DateOnly? _lastDate = null;
    
    public IEnumerable<SchoolCalendar> GenerateSchoolCalendar(List<SchoolTerm> schoolTerms)
    {
        var result = new List<SchoolCalendar>();
        schoolTerms.Sort((a, b) => a.Start.CompareTo(b.Start));
        
        foreach (var term in schoolTerms)
        {
            //if last day of term (_lastDate) is less than the start of the current term, then we have a break
            if (_lastDate.HasValue && _lastDate.Value.AddDays(1) < term.Start)
            {
                var breakDays = GenerateBreakDays(_lastDate.Value.AddDays(1), term.Start.AddDays(-1), term);
                result.AddRange(breakDays);
            }
            
            var termDays = GenerateTermDays(term);
            result.AddRange(termDays);
            _lastDate = term.End;
        }
        return result;
    }

    private List<SchoolCalendar> GenerateTermDays(SchoolTerm schoolTerm)
    {
        var days = new List<SchoolCalendar>();
        for(var date = schoolTerm.Start.ToDateTime(TimeOnly.MinValue); date <= schoolTerm.End.ToDateTime(TimeOnly.MinValue); date = date.AddDays(1))
        {
            if(date.DayOfWeek == DayOfWeek.Monday && date != schoolTerm.Start.ToDateTime(TimeOnly.MinValue))
            {
                _currentWeekNumber++;
            }
            days.Add(new SchoolCalendar
            {
                Date = DateOnly.FromDateTime(date),
                WeekdayName = date.DayOfWeek.ToString(),
                WeekdayNameShort = date.DayOfWeek.ToString()[..3],
                WeekdayIndex = _weekdayIndexes[date.DayOfWeek.ToString()],
                WeekNumber = _currentWeekNumber,
                MonthName = date.ToString("MMMM"),
                MonthIndex = _monthIndexes[date.ToString("MMMM")],
                AcademicYear = schoolTerm.AcademicYear,
                AcademicYearShort = GetAcademicYearShort(schoolTerm.AcademicYear),
                AcademicYearStart = date.Year,
                AcademicYearEnd = date.Year + 1,
                FullModuleName = schoolTerm.FullModule,
                ModuleIndex = _modelIndexes[schoolTerm.Module]
            });
        }

        return days;
    }
    
    private List<SchoolCalendar> GenerateBreakDays(DateOnly start, DateOnly end, SchoolTerm schoolTerm)
    {
        var breakDays = new List<SchoolCalendar>();
        for(var date = start.ToDateTime(TimeOnly.MinValue); date <= end.ToDateTime(TimeOnly.MinValue); date = date.AddDays(1))
        {
            breakDays.Add(new SchoolCalendar
            {
                Date = DateOnly.FromDateTime(date),
                WeekdayName = date.DayOfWeek.ToString(),
                WeekdayNameShort = date.DayOfWeek.ToString()[..3],
                WeekdayIndex = _weekdayIndexes[date.DayOfWeek.ToString()],
                WeekNumber = 0,
                MonthName = date.ToString("MMMM"),
                MonthIndex = _monthIndexes[date.ToString("MMMM")],
                AcademicYear = schoolTerm.AcademicYear,
                AcademicYearShort = GetAcademicYearShort(schoolTerm.AcademicYear),
                AcademicYearStart = date.Year,
                AcademicYearEnd = date.Year + 1,
                FullModuleName = schoolTerm.FullModule,
                ModuleIndex = _modelIndexes[schoolTerm.Module]
            });
        }

        return breakDays;
    }
    
    
    
    private readonly Dictionary<string, int> _monthIndexes = new()
    {
        ["September"] = 1,
        ["October"] = 2,
        ["November"] = 3,
        ["December"] = 4,
        ["January"] = 5,
        ["February"] = 6,
        ["March"] = 7,
        ["April"] = 8,
        ["May"] = 9,
        ["June"] = 10,
        ["July"] = 11,
        ["August"] = 0
    };
    
    private readonly Dictionary<string, int> _weekdayIndexes = new()
    {
        ["Monday"] = 1,
        ["Tuesday"] = 2,
        ["Wednesday"] = 3,
        ["Thursday"] = 4,
        ["Friday"] = 5,
        ["Saturday"] = 6,
        ["Sunday"] = 7
    };
    
    private readonly Dictionary<string, int> _modelIndexes = new()
    {
        ["Module 1"] = 1,
        ["Module 2"] = 2,
        ["Module 3"] = 3,
        ["Module 4"] = 4,
        ["Module 5"] = 5,
        ["Module 6"] = 6
    };
    
    private static string GetAcademicYearShort(string academicYear)
    {
        var firstPart = academicYear.Substring(2, 2);
        var secondPart = academicYear.Split('-')[1];
        return $"{firstPart}/{secondPart}";
    }
}