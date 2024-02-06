using BlockBuster;
using BlockBusterConsole;

var _args = Environment.GetCommandLineArgs();
var choice = _args[0].ToString();
var movies = BlockBusterBasicFunctions.GetAllMovies();
var oh = new OutputHelper();


Console.WriteLine("Welcome to BlockBuster!");

Console.WriteLine("Please select the output format:");
Console.WriteLine("1. CSV");
Console.WriteLine("2. Console");


Console.Write("Enter your choice (1 or 2): ");
string outputChoiceStr = Console.ReadLine();

if (int.TryParse(outputChoiceStr, out int outputChoice))
{
    // Execute the appropriate action based on the user's choice
    if (outputChoice == 1)
    {
        Console.WriteLine("You chose CSV output.");
        // Provide options for CSV output
        ProvideFunctionOptions("CSV");
    }
    else if (outputChoice == 2)
    {
        Console.WriteLine("You chose Console output.");
        // Provide options for Console output
        ProvideFunctionOptions("Console");
    }
    else
    {
        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
}

Console.WriteLine("Thank you for using BlockBuster!");
    
static void ProvideFunctionOptions(string outputType)
{
    Console.WriteLine("Please select a function:");
    Console.WriteLine("1. GetMovieById");
    Console.WriteLine("2. GetAllMovies");
    Console.WriteLine("3. GetAllCheckedoutMovies");
    Console.WriteLine("4. GetAllMoviesByGenre");
    Console.WriteLine("5. GetAllMoviesByDirectorLastName");
    Console.WriteLine("6. GetMovieByTitle");


    Console.Write("Enter your choice (1-6): ");
    string userChoiceStr = Console.ReadLine();

    if (int.TryParse(userChoiceStr, out int method))
    {
        switch (method)
        {
            case 1:
                ExecuteFunction("GetMovieById", outputType, "5"); 
                break;
            case 2:
                ExecuteFunction("GetAllMovies", outputType); 
                break;
            case 3:
                ExecuteFunction("GetAllCheckedoutMovies", outputType); 
                break;
            case 4:
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine();
                ExecuteFunction("GetAllMoviesByGenre", outputType, genre); 
                break;
            case 5:
                Console.Write("Enter director's last name: ");
                string directorLastName = Console.ReadLine();
                ExecuteFunction("GetAllMoviesByDirectorLastName", outputType, directorLastName); 
                break;
            case 6:
                Console.Write("Enter movie title: ");
                string movieTitle = Console.ReadLine();
                ExecuteFunction("GetMovieByTitle", outputType, movieTitle); 
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}

static void ExecuteFunction(string functionName, string outputType, params string[] userInput)
{
    var oh = new OutputHelper();

    if (functionName == "GetMovieById")
    {
        Console.Write("Enter the movie ID: ");
        string movieIdStr = Console.ReadLine();

        if (int.TryParse(movieIdStr, out int movieId))
        {
            userInput = new string[] { movieId.ToString() };
            var movies = BlockBusterBasicFunctions.ExecuteQuery(functionName, userInput);
            oh.Output(movies, outputType);
        }
        else
        {
            Console.WriteLine("Invalid input for movie ID. Please enter a valid integer.");
        }
    }
    else
    {
        var movies = BlockBusterBasicFunctions.ExecuteQuery(functionName, userInput);
        oh.Output(movies, outputType);
    }
}

