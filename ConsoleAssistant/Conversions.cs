using System;

namespace ConsoleAssistant;

public class Conversions
{
    #region Private Fields

    private readonly TaskData _taskData;

    #endregion Private Fields

    #region Public Constructors

    public Conversions(TaskData taskData)
    {
        _taskData = taskData;
    }

    #endregion Public Constructors

    #region Public Methods

    public string ToString()
    {
        return $"{_taskData.Name} should take an average length of {ConvertToDayHour(_taskData.ResultStandardDeviation)} has a standard deviation of {ConvertToDayHour(_taskData.ResultStandardDeviation)}";
    }

    #endregion Public Methods

    #region Private Methods

    private static string ConvertToDayHour(double unrounded)
    {
        var result = Math.Round(unrounded, 1, MidpointRounding.AwayFromZero);
        var days = (int)result;
        var remainder = unrounded - days;
        var hours = remainder * 8;
        hours = RoundHours(hours);
        return $"{GrammarDay(days)} and {GrammarHour(hours)}";
    }

    private static string GrammarDay(double days)
    {
        return days > 1 ? $"{days} days" : $"{days} day";
    }

    private static string GrammarHour(double hours)
    {
        return hours > 1 ? $"{hours} hours" : $"{hours} hour";
    }

    private static double RoundHours(double hours)
    {
        hours = Math.Round(hours, 0, MidpointRounding.AwayFromZero);
        return hours;
    }

    #endregion Private Methods
}