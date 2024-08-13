namespace ConsoleAssistant;

public class DateRange
{
    private static double _pessimistic;
    private static double _optimistic;
    public static double longestDayTotal;

    public DateRange(int pessimistic, int optimistic)
    {
        _pessimistic = pessimistic;
        _optimistic = optimistic;

    }

    public double Pessimistic => _pessimistic;
    public double Optimistic => _optimistic;

    public double AddDayTotal(double pessimistic, double optimistic)
    {
        return longestDayTotal = pessimistic + optimistic;
    }

}