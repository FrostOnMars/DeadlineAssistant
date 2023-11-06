public class Calculate
{
    public static TaskCompletionData CalculateAll(TaskCompletionData taskCompletionData) 
    {
        taskCompletionData.ResultAverageDays = ProbabilityDistribution(taskCompletionData.Pessimistic, taskCompletionData.Optimistic, taskCompletionData.MostLikely);
        taskCompletionData.ResultStandardDeviation = StandardDeviation(taskCompletionData.Pessimistic, taskCompletionData.Optimistic);
        return taskCompletionData;
    }

    //public static Model LinearRegression(Model model)
    //{
    //    Y = a + bX
    //    model.ResultAverageDays = ProbabilityDistribution(model.Pessimistic, model.MostLikely, model.Optimistic);
    //    model.ResultStandardDeviation = StandardDeviation(model.Pessimistic, model.Optimistic);
    //    return model;
    //}
    public static int ProbabilityDistribution(int pessimistic, int optimistic, int mostLikely)
    {
        var averageDays = (optimistic + (4 * mostLikely) + pessimistic) / 6d;
        return (int) Math.Round(averageDays, 0, MidpointRounding.AwayFromZero);
    }
    public static double ProbabilityDistribution(double pessimistic, double optimistic, double mostLikely)
    {
        // pessimistic = 2, optimistic = 1, mostLikely = 3
        // (1 + (4 * 2) + 3) / 6 = (1 + 8 + 3) / 6 = 12 / 6 = 2.0
        //[InlineData("Task1", 2, 1, 3, 2.0)] // (1 + (4 * 2) + 3) / 6 = (1 + 8 + 3) / 6 = 12 / 6 = 2.0
        var averageDays = (optimistic + (4 * mostLikely) + pessimistic) / 6d;
        return averageDays;
    }

    public static TaskCompletionData ProbabilityDistribution(TaskCompletionData taskCompletionData)
    {
        taskCompletionData.ResultAverageDays = (taskCompletionData.Pessimistic + (4 * taskCompletionData.MostLikely) + taskCompletionData.Optimistic) / 6;
        return taskCompletionData;
    }

    public static int StandardDeviation(int pessimistic, int optimistic) 
    {
        var standardDeviation = (pessimistic - optimistic) / 6;
        return standardDeviation;
    }

    public static TaskCompletionData StandardDeviation(TaskCompletionData taskCompletionData)
    {
        taskCompletionData.ResultStandardDeviation = (taskCompletionData.Pessimistic - taskCompletionData.Optimistic) / 6;
        return taskCompletionData;
    }
    public static double StandardDeviation(double pessimistic, double optimistic)
    {
        var standardDeviation = (pessimistic - optimistic) / 6;
        return standardDeviation;
    }

}