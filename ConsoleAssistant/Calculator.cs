using System;
using System.Linq;

namespace ConsoleAssistant;

public class Calculator
{
    #region Public Properties

    public static int Probability { get; set; }

    #endregion Public Properties

    #region Private Fields

    private static double _longestDayTotal;
    private static int _mostLikely;
    private static TaskData _taskData;

    #endregion Private Fields

    #region Public Methods

    //public static TaskData CalculateAll(TaskData taskData)
    //{
    //    ProbabilityDistribution(_longestDayTotal, _mostLikely);
    //    StandardDeviation(taskData.Pessimistic, taskData.Optimistic);
    //    return taskData;
    //}

    public static double ProbabilityDistribution(double longestDayTotal, int mostLikely)
    {
        var averageDays = (longestDayTotal + 4 * mostLikely) / 6d;
        return averageDays;
    }
    public static double RoundAverageDays(double averageDays)
    {
        return Math.Round(averageDays, 0, MidpointRounding.AwayFromZero);
    }

    //public static double ProbabilityDistribution(double pessimistic1, double optimistic1, double mostLikely1)
    //{
    //    var averageDays = (optimistic1 + 4 * mostLikely1 + pessimistic1) / 6d;
    //    return averageDays;
    //}

    public static TaskData ProbabilityDistribution(TaskData taskData)
    {
        _taskData = taskData;
        taskData.ResultAverageDays = (taskData.Pessimistic + 4 * taskData.MostLikely + taskData.Optimistic) / 6;
        return taskData;
    }

    public static double ProbabilityDistribution(double pessimistic, double optimistic)
    {
        // uses Generics to handle different types of data and keep code DRY
        var expectedTimeline = (pessimistic - optimistic) / 6;
        return expectedTimeline;
    }

    public static double StandardDeviation(double[] data)
    {
        if (data == null || data.Length == 0)
            throw new ArgumentException("The data array must contain at least one element.");

        // Step 1: Calculate the mean
        var mean = data.Average();

        // Step 2: Calculate the squared differences from the mean
        var sumOfSquaresOfDifferences = data.Select(val => (val - mean) * (val - mean)).Sum();

        // Step 3: Calculate the mean of these squared differences
        var meanOfSquares = sumOfSquaresOfDifferences / data.Length;

        // Step 4: Take the square root of this mean to get the standard deviation
        return Math.Sqrt(meanOfSquares);
    }

    //public static TaskData StandardDeviation(TaskData taskCompletionData)
    //{
    //    taskCompletionData.ResultStandardDeviation =
    //        (taskCompletionData.Pessimistic - taskCompletionData.Optimistic) / 6;
    //    return taskCompletionData;
    //}

    #endregion Public Methods
}