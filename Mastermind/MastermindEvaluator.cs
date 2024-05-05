namespace Mastermind;

public static class MastermindEvaluator
{
    public static (int wellPlaced, int misplaced) Evaluate(IReadOnlyList<string> secret, IReadOnlyList<string> guess)
    {
        if (secret.Count != guess.Count)
        {
            throw new ArgumentException("Secret and guess must have the same number of elements.");
        }
    
        int wellPlaced = 0;
        int misplaced = 0;
        
        // This remaining secrets and guesses will be used to find misplaced colors
        List<string> remainingSecret = [];
        List<string> remainingGuess = [];

        // Find all guessed colors
        for (int i = 0; i < secret.Count; i++)
        {
            if (guess[i] == secret[i])
            {
                wellPlaced++;
            }
            else
            {
                remainingGuess.Add(guess[i]);
                remainingSecret.Add(secret[i]);
            }
        }

        // Now, check for misplaced colors
        foreach (var color in remainingGuess)
        {
            if (remainingSecret.Contains(color))
            {
                misplaced++;
                remainingSecret.Remove(color); // Remove to avoid counting the same color twice
            }
        }

        return (wellPlaced, misplaced);
    }
}