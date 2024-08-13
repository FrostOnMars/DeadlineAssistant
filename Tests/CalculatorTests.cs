using ConsoleAssistant;
using FluentAssertions;
using NUnit.Framework;


namespace Tests;

[TestFixture]
public class CalculatorTests
{
    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
        _taskData = new TaskData();
    }

    private Calculator _calculator;
    private TaskData _taskData;

    [Test]
    public void GetStandardDev_CorrectInput_ReturnsExpectedResult()
    {
        //Arrange 
        var pessimistic = 10.0;
        var optimistic = 4.0;
        var expected = 1.0;

        //Act
        var result = Calculator.GetStandardDev(pessimistic, optimistic);

        //Assert
        Assert.AreEqual(expected, result, .0001);
    }

    [Test]
    [TestCase("Task1", 2, 1, 3, 2.0)]
    [TestCase("Task2", 5, 2, 8, 5.0)]
    public void TaskData_ShouldReturn_ProbabilityDistribution(string name, double mostLikely, double pessimistic,
        double optimistic, double expectedAverage)
    {
        var result = Calculator.GetProbDistribution(pessimistic, optimistic, mostLikely);
    }
}