public class Calculate
{
    public static int ProbabilityDistribution(int pessimistic, int mostLikely, int optimistic)
    {
        var averageDays = (pessimistic + 4 * mostLikely + optimistic) / 6;
        return averageDays;
    }

    public static int StandardDeviation(int pessimistic, int optimistic) {
        var standardDeviation = (pessimistic - optimistic) / 6;
        return standardDeviation;
    }
}