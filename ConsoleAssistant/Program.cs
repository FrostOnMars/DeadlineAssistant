using System;

namespace ConsoleAssistant;

internal class Program
{
    #region Private Methods

    private static void Main()
    {
        ConsoleStatements.PostOpeningText();

        var myModel = TaskDataBuilder
            .Create("TestTask", 1, 14, 5 )
            .AddAverageDays()
            .AddStandardDeviation()
            .Build();

        Console.WriteLine(myModel.ToString());

        var mySecondModel = TaskDataBuilder
            .Create("TestSecondTask", 5, 22, 8 )
            .AddAverageDays()
            .AddStandardDeviation()
            .Build();

        Console.WriteLine(mySecondModel.ToString());

        ;

        ConsoleStatements.ReadInput();
        //ConsoleStatements.ReturnResults();
    }

    #endregion Private Methods
}