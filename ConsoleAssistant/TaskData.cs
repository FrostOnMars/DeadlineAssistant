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

    public string Name { get; set; }
    public double Nominal { get; set; }
    public double Optimistic { get; set; }
    public double Pessimistic { get; set; }
    public double ResultCompletionTimeline { get; set; }
    public double ResultStandardDeviation { get; set; }
    public double StandardDeviation { get; set; }


    #endregion Public Properties

    #region Public Constructors


    public TaskData()
    {
        _conversions = new Conversions(this);
    }

    public TaskData(string name, double optimistic, double pessimistic, double nominal)
    {
        _conversions = new Conversions(this);
        Optimistic = optimistic;
        Pessimistic = pessimistic;
        Nominal = nominal;
        Name = name;
    }

    #endregion Public Constructors
}