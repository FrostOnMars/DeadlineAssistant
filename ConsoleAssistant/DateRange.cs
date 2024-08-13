using System;

namespace ConsoleAssistant;

public class DateRange
{
    #region Public Fields

    public static double longestDayTotal;

    #endregion Public Fields

    #region Public Constructors

    public DateRange(int pessimistic, int optimistic)
    {
        _pessimistic = pessimistic;
        _optimistic = optimistic;
    }

    #endregion Public Constructors

    #region Public Methods

    public double AddDayTotal(double pessimistic, double optimistic)
    {
        return longestDayTotal = pessimistic + optimistic;
    }

    #endregion Public Methods

    #region Private Fields

    private static double _optimistic;
    private static double _pessimistic;

    #endregion Private Fields

    #region Public Properties

    public double Optimistic => _optimistic;

    public double Pessimistic => _pessimistic;

    #endregion Public Properties
}