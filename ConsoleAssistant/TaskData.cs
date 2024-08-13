namespace ConsoleAssistant;

public class TaskData
{
    #region Private Fields

    private readonly Conversions _conversions;

    #endregion Private Fields

    #region Public Methods

    public override string ToString()
    {
        return _conversions.ToString();
    }

    #endregion Public Methods

    #region Public Properties

    public double MostLikely { get; set; }
    public string Name { get; set; }
    public double Optimistic { get; set; }
    public double Pessimistic { get; set; }
    public double ResultAverageDays { get; set; }
    public double ResultStandardDeviation { get; set; }

    #endregion Public Properties

    #region Public Constructors

    public TaskData()
    {
        _conversions = new Conversions(this);
    }

    public TaskData(string name, double optimistic, double pessimistic, double expected)
    {
        _conversions = new Conversions(this);
        Optimistic = optimistic;
        Pessimistic = pessimistic;
        MostLikely = expected;
        Name = name;
    }

    #endregion Public Constructors
}