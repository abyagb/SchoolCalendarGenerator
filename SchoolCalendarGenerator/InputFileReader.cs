using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace SchoolCalendarGenerator;

public static class InputFileReader
{
    public static List<SchoolTerm> ReadSchoolTerms(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true 
        });

        return csv.GetRecords<SchoolTerm>().ToList(); // Maps CSV rows to `SchoolTerm` objects
    }
}