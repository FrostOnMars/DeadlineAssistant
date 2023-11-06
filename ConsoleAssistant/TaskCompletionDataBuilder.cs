using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleAssistant
{
    public class TaskCompletionDataBuilder
    {
        private readonly TaskCompletionData _taskCompletionData;

        private TaskCompletionDataBuilder(string name, double optimistic, double pessimistic, double expected)
        {
            _taskCompletionData = new TaskCompletionData(name, optimistic, pessimistic, expected);
        }

        public static TaskCompletionDataBuilder Create(string name, double optimistic, double pessimistic, double expected)
        {
            if (pessimistic < 0 || optimistic < 0 || expected < 0)
            {
                throw new ArgumentException("All values must be greater than 0.");
            }
            return new TaskCompletionDataBuilder(name, optimistic, pessimistic, expected);
        }

        public TaskCompletionDataBuilder AddStandardDeviation()
        {
            // Assuming you've got some calculation here to determine the standard deviation...
            _taskCompletionData.ResultStandardDeviation = Calculate.StandardDeviation(_taskCompletionData.Pessimistic, _taskCompletionData.Optimistic);
            return this;
        }

        public TaskCompletionDataBuilder AddAverageDays()
        {
            // Assuming you've got some calculation here to determine the average days...
            _taskCompletionData.ResultAverageDays =
                Calculate.ProbabilityDistribution(_taskCompletionData.Pessimistic, _taskCompletionData.Optimistic, _taskCompletionData.MostLikely); 
            return this;
        }

        //public ModelBuilder AddLinearRegression()
        //{
        //    // This is just an example of additional values your model could have and add. 
        //    _model.LinearRegression = Calculate.LinearRegression(_model.a, _model.b, _model.y)// ... calculated value;
        //    return this;
        //}

        public TaskCompletionData Build()
        {
            // here you'll add the validation logic or whatever you need for the base model.
            return _taskCompletionData;
        }
    }

    //eventually I might want to make an Update method to change _model
}
