using System;
using System.Linq;

namespace ConsoleAssistant;

public class ConsoleStatements
{
    #region Private Fields

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
                var optimistic = Convert.ToInt32(inputArray[0]);
                var mostLikely = Convert.ToInt32(inputArray[1]);
                var pessimistic = Convert.ToInt32(inputArray[2]);

                var x = Calculator.ProbabilityDistribution(DateRange.longestDayTotal, pessimistic);
                var y = -1 * Calculator.GetStandardDev(optimistic, pessimistic);

                outputResult = $"Your project will most likely take you {x} days with a margin of error of {y} days.\n";
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