namespace SchoolCalendarGenerator;

public interface ICalendarGenerator
{
    IEnumerable<SchoolCalendar> GenerateSchoolCalendar(List<SchoolTerm> schoolTerms);
}