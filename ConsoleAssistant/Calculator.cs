using System;
using System.Linq;

namespace ConsoleAssistant;

public class Calculator
{
    #region Public Methods

   
    public static double RoundAverageDays(double averageDays)
    {
        return Math.Round(averageDays, 0, MidpointRounding.AwayFromZero);
    }

    ////TODO: decide whether to route all Calculator methods through TaskData
    //public static TaskData GetProbDistribution(TaskData taskData)
    //{
    //    taskData.ResultCompletionTimeline = (taskData.Pessimistic + (4 * taskData.Nominal) + taskData.Optimistic) / 6;
    //    return taskData;
    //}
    public static double GetProbDistribution(double pessimistic, double nominal, double optimistic)
    {

        var resultsCompletionTimeline = (pessimistic + (4 * nominal) + optimistic) / 6;
        return resultsCompletionTimeline;
    }

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