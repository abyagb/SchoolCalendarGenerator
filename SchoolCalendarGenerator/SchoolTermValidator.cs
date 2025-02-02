namespace SchoolCalendarGenerator;

public class SchoolTermValidator : ISchoolTermValidator
{
    public bool Validate(SchoolTerm schoolTerm)
    {
        return schoolTerm.Start < schoolTerm.End
               && IsValidFullModule(schoolTerm.FullModule)
               && ValidModules.Contains(schoolTerm.Module)
               && IsValidShortAcademicYear(schoolTerm.AcademicYear);
    }
    
    private static readonly HashSet<string> ValidModules =
        ["Module 1", "Module 2", "Module 3", "Module 4", "Module 5", "Module 6"];

    private static bool IsValidFullModule(string fullModule)
    {
        if (string.IsNullOrWhiteSpace(fullModule)) return false;
        
        var parts = fullModule.Split(' ', 2);
        if (parts.Length != 2) return false;
        
        var yearPart = parts[0].Trim();
        var modulePart = parts[1].Trim();
        
        return IsValidShortAcademicYear(yearPart) && ValidModules.Contains(modulePart);
    }
    
    private static bool IsValidShortAcademicYear(string shortAcademicYear)
    {
        if (string.IsNullOrWhiteSpace(shortAcademicYear)) return false; 
        var parts = shortAcademicYear.Split('-');
        if (parts.Length != 2) return false;
        if (!int.TryParse(parts[0], out var startYear) || !int.TryParse(parts[1], out var endYear))
            return false; 
        
        return endYear == (startYear % 100 + 1);
    }
}