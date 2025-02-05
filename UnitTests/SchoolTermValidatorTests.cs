using SchoolCalendarGenerator;
using Shouldly;

namespace UnitTests;

public class SchoolTermValidatorTests
{
    private readonly SchoolTermValidator _validator = new SchoolTermValidator();
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var testSchoolTerm = new SchoolTerm
        {
            StartDateString = "1/1/2022",
            EndDateString = "1/1/2023",
            FullModule = "2022 Module 1",
            AcademicYear = "2022-23",
            Module = "Module 1"
        };
        
        var result = _validator.Validate(testSchoolTerm);
        result.ShouldBe(true);
    }
}