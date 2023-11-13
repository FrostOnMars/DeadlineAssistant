public class Calculator
{
    private static int _mostLikely;
    private static TaskData _taskData;
    private static double _longestDayTotal;
    public static int Probability { get; set; }


    public static TaskData CalculateAll(TaskData taskData) 
    {
        ProbabilityDistribution(_longestDayTotal, _mostLikely);
        StandardDeviation(taskData.Pessimistic, taskData.Optimistic);
        return taskData;
    }


    public static double ProbabilityDistribution(double longestDayTotal, int mostLikely)
    {
        var averageDays = (longestDayTotal + (4 * mostLikely)) / 6d;
        return averageDays;
    }

   

    private static double RoundAverageDays(double averageDays)
    {
        return Math.Round(averageDays, 0, MidpointRounding.AwayFromZero);
    }

    public static double ProbabilityDistribution(double pessimistic1, double optimistic1, double mostLikely1)
    {
        var averageDays = (optimistic1 + (4 * mostLikely1) + pessimistic1) / 6d;
        return averageDays;
    }

    public static TaskData ProbabilityDistribution(TaskData taskData)
    {
        _taskData = taskData;
        taskData.ResultAverageDays = (taskData.Pessimistic + (4 * taskData.MostLikely) + taskData.Optimistic) / 6;
        return taskData;
    }

    public static int StandardDeviation(int pessimistic, int optimistic) 
    {
        var standardDeviation = (pessimistic - optimistic) / 6;
        return standardDeviation;
    }

    public static double StandardDeviation(double pessimistic, double optimistic)
    {
        var standardDeviation = (pessimistic - optimistic) / 6;
        return standardDeviation;
    }

    public static TaskData StandardDeviation(TaskData taskCompletionData)
    {
        taskCompletionData.ResultStandardDeviation = (taskCompletionData.Pessimistic - taskCompletionData.Optimistic) / 6;
        return taskCompletionData;
    }
}