using ConsoleAssistant;

class Program
{
   
    static void Main(string[] args) {
        
        ConsoleStatements.PostOpeningText();

        var myModel = TaskDataBuilder
            .Create("TestTask", 1, 14, 5)
            .AddAverageDays()
            .AddStandardDeviation()
            .Build();

        Console.WriteLine(myModel.ToString());

        var mySecondModel = TaskDataBuilder
            .Create("TestSecondTask", 5, 22, 8)
            .AddAverageDays()
            .AddStandardDeviation()
            .Build();

        Console.WriteLine(mySecondModel.ToString());

        ;

        ConsoleStatements.ReadInput();
        //ConsoleStatements.ReturnResults();

    }

}