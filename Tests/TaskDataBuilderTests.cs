﻿
using ConsoleAssistant;
using NUnit.Framework;

namespace Tests;

[TestFixture]
internal class TaskDataBuilderTests
{
    [Test]
    [TestCase("Task1", 5, 10, 7)]
    public void Create_ValidInputs_ShouldReturnTaskDataBuilderInstance(string name, double optimistic, double pessimistic,
        double nominal)
    {
        // Act
        var builder = TaskDataBuilder.Create(name, optimistic, pessimistic, nominal);

        // Assert
        Assert.IsNotNull(builder);
    }
    [Test]
    [TestCase("Task1", -5, 10, 7)]
    public void Create_NegativeInputs_ShouldThrowArgumentException(string name, double optimistic, double pessimistic,
        double nominal)
    {
     // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            TaskDataBuilder.Create(name, optimistic, pessimistic, nominal));
    }
    //[Test]
    //public void AddAverageDays_ShouldCalculateAndSetResultCompletionTimeline()
    //{
    //    // Arrange
    //    var builder = TaskDataBuilder.Create("TestTask", 5, 10, 7);

    //    // Act
    //    builder.AddAverageDays();
    //    var taskData = builder.Build();

    //    // Assert
    //    Assert.AreEqual(7, taskData.ResultCompletionTimeline); // Assuming the calculator returns the average for the example
    //}

    [Test]
    public void AddStandardDeviation_ShouldCalculateAndSetResultStandardDeviation()
    {
        // Arrange
        var builder = TaskDataBuilder.Create("TestTask", 5, 10, 7);

        // Act
        builder.AddStandardDeviation();
        var taskData = builder.Build();

        // Assert
        Assert.AreEqual(0.8333, taskData.ResultStandardDeviation, 0.0001); // Assuming (10 - 5) / 6 = 0.8333
    }
   
    [Test]
    public void Build_ShouldReturnTaskDataInstanceWithCorrectValues()
    {
        // Arrange
        var name = "TestTask";
        var optimistic = 5;
        var pessimistic = 10;
        var nominal = 7;

        var builder = TaskDataBuilder.Create(name, optimistic, pessimistic, nominal)
            .AddAverageDays()
            .AddStandardDeviation();

        // Act
        var taskData = builder.Build();

        // Assert
        Assert.AreEqual(name, taskData.Name);
        Assert.AreEqual(optimistic, taskData.Optimistic);
        Assert.AreEqual(pessimistic, taskData.Pessimistic);
        Assert.AreEqual(nominal, taskData.Nominal);
        Assert.AreEqual(7, taskData.ResultCompletionTimeline); // Example value
        Assert.AreEqual(0.8333, taskData.ResultStandardDeviation, 0.0001); // Example value
    }

}