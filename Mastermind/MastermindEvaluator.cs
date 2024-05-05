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
        List<string> remainingSecrets = [];
        List<string> remainingGuesses = [];

        // Find all guessed colors
        for (int i = 0; i < secret.Count; i++)
        {
            if (guess[i] == secret[i])
            {
                wellPlaced++;
            }
            else
            {
                remainingGuesses.Add(guess[i]);
                remainingSecrets.Add(secret[i]);
            }
        }

        // Check for misplaced colors
        foreach (var color in remainingGuesses)
        {
            if (remainingSecrets.Contains(color))
            {
                misplaced++;
                remainingSecrets.Remove(color); // Remove to avoid counting the same color twice
            }
        }

        return (wellPlaced, misplaced);
    }
}