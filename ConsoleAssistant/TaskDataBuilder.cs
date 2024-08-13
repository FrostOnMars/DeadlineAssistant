using System;

namespace ConsoleAssistant;

public class TaskDataBuilder
{
    #region Private Fields

    private readonly TaskData _taskData;

    #endregion Private Fields

    #region Private Constructors

    private TaskDataBuilder(string name, double optimistic, double pessimistic, double expected)
    {
        _taskData = new TaskData(name, optimistic, pessimistic, expected);
    }

    #endregion Private Constructors

    #region Public Constructors

    public TaskDataBuilder()
    {
    }

    #endregion Public Constructors

    #region Public Methods

    public static TaskDataBuilder Create(string name, double optimistic, double pessimistic, double expected)
    {
        if (pessimistic < 0 || optimistic < 0 || expected < 0)
            throw new ArgumentException("All values must be greater than 0.");
        return new TaskDataBuilder(name, optimistic, pessimistic, expected);
    }

    public TaskDataBuilder AddAverageDays()
    {
        // Assuming you've got some calculation here to determine the average days...
        _taskData.ResultAverageDays =
            Calculator.ProbabilityDistribution(_taskData.Pessimistic, _taskData.Optimistic, _taskData.MostLikely);
        return this;
    }

    public TaskDataBuilder AddStandardDeviation()
    {
        // Assuming you've got some calculation here to determine the standard deviation...
        _taskData.ResultStandardDeviation = Calculator.StandardDeviation(_taskData.Pessimistic, _taskData.Optimistic);
        return this;
    }

    //public ModelBuilder AddLinearRegression()
    //{
    //    // This is just an example of additional values the model could have and add.
    //    _model.LinearRegression = Calculate.LinearRegression(_model.a, _model.b, _model.y)// ... calculated value;
    //    return this;
    //}

    public TaskData Build()
    {
        // add the validation logic or whatever I need for the base model.
        return _taskData;
    }

    #endregion Public Methods
}

//eventually I might want to make an Update method to change _model