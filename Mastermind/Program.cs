using Mastermind;

List<string> colors = [ "red", "blue", "green", "yellow", "pink", "orange" ];
Random rand = new Random();
var secretCode = Enumerable.Range(0, 4).Select(x => colors[rand.Next(colors.Count)]).ToList();

Console.WriteLine("Try to guess the color combination. Available colors: red, blue, green, yellow, pink, orange.");
Console.WriteLine("Type your four color guesses separated by spaces (e.g., red blue green yellow).");

while (true)
{
    Console.Write("Enter your guess: ");
    string input = Console.ReadLine()!;
    string[] guess = input.Trim().Split(' ');

    if (guess.Length != 4)
    {
        Console.WriteLine("Please enter exactly four colors.");
        continue;
    }

    try
    {
        var (wellPlaced, misplaced) = MastermindEvaluator.Evaluate(secretCode, guess);

        if (wellPlaced == 4)
        {
            Console.WriteLine("Congratulations! You've guessed the right combination!");
            break;
        }

        Console.WriteLine($"{wellPlaced} well-placed, {misplaced} misplaced. Try again.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine("Game over. The correct code was: " + string.Join(" ", secretCode));