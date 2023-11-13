using ConsoleAssistant;
using FluentAssertions;
using NUnit.Framework;


namespace Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

       

        [Test]
        [TestCase("Task1", 2, 1, 3, 2.0)]
        [TestCase("Task2", 5, 2, 8, 5.0)]
        public void TaskData_ShouldReturn_ProbabilityDistribution(string name, double mostLikely, double pessimistic, double optimistic, double expectedAverage)
        {
            var result = Calculator.ProbabilityDistribution(pessimistic, optimistic, mostLikely);
        }


        [Theory]
        [TestCase(12, 1)]
        public void StandardDeviation_ShouldEqual1_8(int pessimistic, int optimistic)
        {
            var result = Calculator.StandardDeviation(pessimistic, optimistic);

            result.Should().Be(standard);
        }

        

    }
}