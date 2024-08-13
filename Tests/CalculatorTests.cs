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
    }

    private Calculator _calculator;

    [Test]
    [TestCase(10, 4, 1)]       // Regular case with positive numbers
    [TestCase(5, 5, 0)]        // Case where pessimistic and optimistic are the same
    [TestCase(4, 10, -1)]      // Case where pessimistic is smaller than optimistic (negative result)
    [TestCase(1_000_000, 999_994, 1)] // Case with large numbers
    [TestCase(0.000001, 0.000001, 0)] // Case with very small numbers close to zero
    [TestCase(-4, -10, 1)]     // Case with negative numbers
    [TestCase(-10, -4, -1)]    // Case where pessimistic and optimistic are negative, with pessimistic larger
    [TestCase(0, 0, 0)]        // Case where both values are zero
    public void GetStandardDev_CorrectInput_ReturnsExpectedResult(double pessimistic, double optimistic, double expected)
    {
        //Act
        var result = Calculator.GetStandardDev(pessimistic, optimistic);

        //Assert
        Assert.AreEqual(expected, result, .0001);
    }

}