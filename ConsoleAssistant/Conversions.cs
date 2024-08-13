namespace ConsoleAssistant;

public class Conversions
{
    private readonly TaskData _taskData;

    public Conversions(TaskData taskData)
    {
        _taskData = taskData;
    }

    public string ToString() {
        
        return $"{_taskData.Name} has a standard deviation of {ConvertToDayHour(_taskData.ResultStandardDeviation)} " +
               $"and an average length of {ConvertToDayHour(_taskData.ResultStandardDeviation)}. ";
    }


    private static string ConvertToDayHour(double unrounded)
    {
        var result = Math.Round(unrounded, 1, MidpointRounding.AwayFromZero);
        var days = (int) result;
        var remainder = unrounded - days;
        var hours = remainder * 8;
        hours = RoundHours(hours);
        return $"{GrammarDay(days)} and {GrammarHour(hours)}";
    }

    private static double RoundHours(double hours)
    {
        hours = Math.Round(hours, 0, MidpointRounding.AwayFromZero);
        return hours;
    }

    private static string GrammarHour(double hours)
    {
        return hours > 1 ? $"{hours} hours" : $"{hours} hour";
    }

    private static string GrammarDay(double days)
    {
        return days > 1 ? $"{days} days" : $"{days} day";
    }
}