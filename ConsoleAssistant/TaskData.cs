using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

public class TaskData {
    private readonly Conversions _conversions;
    public string Name { get; set; }
    public double Optimistic { get; set; }
    public double MostLikely { get; set; }
    public double Pessimistic { get; set; }
    public double ResultAverageDays { get; set; }
    public double ResultStandardDeviation { get; set; }
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
    public override string ToString()
    {
        return _conversions.ToString();
    }
}