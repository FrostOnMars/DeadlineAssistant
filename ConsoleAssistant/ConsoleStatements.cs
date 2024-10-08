﻿using System;
using System.Linq;


namespace ConsoleAssistant;

// Note: This class used to take user input to calculate values. The task of providing numbers is 
// currently taken over by TaskDataBuilder and TaskData. 

public class ConsoleStatements
{
    #region Private Fields
    private static TaskData _taskData;

    private static readonly string explainSummary =
        "Projects are best described with three estimated completion dates: \n\n" +
        "An optimistic estimate should only occur if all things line up correctly. \n" +
        "A pessimistic estimate includes everything except hurricanes, nuclear war, stray black holes" +
        "and other catastrophes. \n" +
        "The most likely estimate is how long you think the project is most likely to take. \n\n" +
        "In order for the math to be correct, the Optimistic and Pessimistic values" +
        "should occur less than 1% of the time.";

    private static string outputResult;

    private static string promptContinue = "Would you like to calculate another project? Y/N";

    private static readonly string promptInput =
        "Please enter the optimistic, most likely, and pessimistic completion dates for your project, followed " +
        "by a comma. Input should look like this: 1, 5, 14";

    public ConsoleStatements(TaskData taskData)
    {
        _taskData = taskData;
    }

    #endregion Private Fields

    #region Public Methods

    public static void PostOpeningText()
    {
        Console.WriteLine(explainSummary);
        Console.WriteLine("=================");
        Console.WriteLine(promptInput);
        Console.WriteLine("=================");
    }

    public static void ReadInput()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var inputArray = input.Trim().Split(',');

            if (inputArray.Length != 3 || inputArray.Any(string.IsNullOrWhiteSpace) ||
                inputArray.Any(x => !int.TryParse(x, out _)))
            {
                Console.WriteLine("Please enter three valid numbers separated by commas.");
                continue;
            }

            {
                //var optimistic = Convert.ToDouble(inputArray[0]);
                //var nominal = Convert.ToDouble(inputArray[1]);
                //var pessimistic = Convert.ToDouble(inputArray[2]);

                ////TODO: why are we recalculating this? How do I use the result from TaskData instead?
                //var x = _taskData.ResultCompletionTimeline;
                //var y = -1 * _taskData.ResultStandardDeviation;

                //outputResult = $"Your project will most likely take you {x} days with a margin of error of {y} days.\n";
            }
            break;
        }
    }

    public static void ReturnResults()
    {
        Console.WriteLine(outputResult);
    }

    #endregion Public Methods
}