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
    private static int _nominal;
    private static TaskData _taskData;

    #endregion Private Fields

    #region Public Methods

    //public static TaskData CalculateAll(TaskData taskData)
    //{
    //    GetProbDistribution(_longestDayTotal, _nominal);
    //    GetStandardDev(taskData.Pessimistic, taskData.Optimistic);
    //    return taskData;
    //}

    //public static double GetProbDistribution(double longestDayTotal, int mostLikely)
    //{
    //    var averageDays = (longestDayTotal + 4 * mostLikely) / 6d;
    //    return averageDays;
    //}
    public static double RoundAverageDays(double averageDays)
    {
        return Math.Round(averageDays, 0, MidpointRounding.AwayFromZero);
    }

    //TODO: decide whether to route all Calculator methods through TaskData
    public static TaskData GetProbDistribution(TaskData taskData)
    {
        _taskData = taskData;
        taskData.ResultCompletionTimeline = (taskData.Pessimistic + (4 * taskData.Nominal) + taskData.Optimistic) / 6;
        return taskData;
    }
    public static double GetProbDistribution(double Pessimistic, double Nominal, double Optimistic)
    {
        var ResultsCompletionTimeline = (Pessimistic + (4 * Nominal) + Optimistic) / 6;
        return ResultsCompletionTimeline;
    }

    //public static double GetProbDistribution(double pessimistic, double optimistic)
    //{
    //    // uses Generics to handle different types of data and keep code DRY
    //    var expectedTimeline = (pessimistic - optimistic) / 6;
    //    return expectedTimeline;
    //}


    //public static TaskData GetStandardDev(TaskData taskCompletionData)
    //{
    //    taskCompletionData.ResultStandardDeviation =
    //        (taskCompletionData.Pessimistic - taskCompletionData.Optimistic) / 6;
    //    return taskCompletionData;
    //}
    public static double GetStandardDev(double pessimistic, double optimistic)
    {
        var standardDeviation = (pessimistic - optimistic) / 6;
        return standardDeviation;
    }

    #endregion Public Methods
}