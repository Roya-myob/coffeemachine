using System;
using CoffeeMachine;
using Xunit;
namespace CoffeeMachineTests
{
    public class ReportGeneratorTest
    {
        [Theory]
        [InlineData("1/1/2021", 1)]
        [InlineData("2/1/2021", 3)]
        [InlineData("3/1/2021", 0)]
        public void Generate_a_report_of_all_the_drinks_sold_for_a_given_day(string date, int count)
        {
            ReportGenerator reportGenerator = new ReportGenerator(new InMemoryRepository());
            var report = reportGenerator.CreateReport(DateTime.Parse(date));

            var soldItems = report.GetSoldItems();
            
            Assert.Equal(DateTime.Parse(date).ToShortDateString(), report.GetDateOfSoldItems().ToShortDateString());
            Assert.Equal(new DateTime(), report.GetGeneratedDate());
            Assert.Equal(count, soldItems.Count);
            
           // Console.WriteLine($"Items Sold {soldItems.Count}");
        }
    }
}