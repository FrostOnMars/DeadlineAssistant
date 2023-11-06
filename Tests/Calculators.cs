using ConsoleAssistant;
using FluentAssertions;

namespace Tests
{
    public class Calculators
    {
        //Note: this formula is derived from the US Navy's PERT (Program Evaluation and Review Technique) formula.
        //The constants 4 and 6 are somewhat arbitrary numbers they developed through experience and calculation
        //to describe the likelihood of the optimistic and pessimistic estimates occurring.
        //The formula is: (Pessimistic + 4 * Most Likely + Optimistic)/6
        [Theory]

        [InlineData("Task1", 2, 1, 3, 2.0)] // (1 + (4 * 2) + 3) / 6 = (1 + 8 + 3) / 6 = 12 / 6 = 2.0
        [InlineData("Task2", 5, 2, 8, 5.0)] // (2 + (4 * 5) + 8) / 6 = (2 + 20 + 8) / 6 = 30 / 6 = 5.0
        [InlineData("Task3", 10, 4, 16, 10.0)] // (4 + (4 * 10) + 16) / 6 = (4 + 40 + 16) / 6 = 60 / 6 = 10.0
        [InlineData("Task4", 4.5, 1.5, 7.5, 4.5)] // (1.5 + (4 * 4.5) + 7.5) / 6 = (1.5 + 18 + 7.5) / 6 = 27 / 6 = 4.5
        [InlineData("TaskError", -1, 2, 3, 0)] // Will throw an exception due to a negative value
        public void TaskCompletionData_ShouldReturn_ProbabilityDistribution(string name, double mostLikely, double pessimistic, double optimistic, double expectedAverage)
        {
            if (pessimistic < 0 || optimistic < 0 || mostLikely < 0)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var task = TaskCompletionDataBuilder
                        .Create(name, pessimistic, optimistic, mostLikely)
                        .AddAverageDays()
                        .Build();
                });
            }
            else
            {
                var task = TaskCompletionDataBuilder
                    .Create(name, pessimistic, optimistic, mostLikely)
                    .AddAverageDays()
                    .Build();

                var result = task.ResultAverageDays;
                result.Should().Be(expectedAverage);
            }
        }





        [Theory]
        [InlineData(12, 1)]
        public void StandardDeviation_ShouldEqual1_8(int pessimistic, int optimistic)
        {
            var result = (pessimistic - optimistic) / 6;

            result.Should().Be((int)1.8);
        }

        

    }
}