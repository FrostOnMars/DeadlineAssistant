using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

public class TaskCompletionData {
    public string Name { get; set; }
    public double Optimistic { get; set; }
    public double MostLikely { get; set; }
    public double Pessimistic { get; set; }
    public double ResultAverageDays { get; set; }
    public double ResultStandardDeviation { get; set; }

    public override string ToString() {
        
        return $"{Name} has a standard deviation of {ConvertToDayHour(ResultStandardDeviation)} " +
               $"and an average length of {ConvertToDayHour(ResultStandardDeviation)}. ";
    }

    private static string ConvertToDayHour(double unrounded)
    {
        var result = Math.Round(unrounded, 1, MidpointRounding.AwayFromZero);
        var days = (int) result;
        var remainder = unrounded - days;
        var hours = remainder * 8;
        hours = Math.Round(hours, 0, MidpointRounding.AwayFromZero);
        return $"{GrammarDay(days)} and {GrammarHour(hours)}";
    }

    private static string GrammarHour(double hours)
    {
        return hours > 1 ? $"{hours} hours" : $"{hours} hour";
    }

    private static string GrammarDay(double days)
    {
        return days > 1 ? $"{days} days" : $"{days} day";
    }


    public TaskCompletionData(string name, double optimistic, double pessimistic, double expected)
    {
        Optimistic = optimistic;
        Pessimistic = pessimistic;
        MostLikely = expected;
        Name = name;
    }

    public TaskCompletionData()
    {
        
    }

}