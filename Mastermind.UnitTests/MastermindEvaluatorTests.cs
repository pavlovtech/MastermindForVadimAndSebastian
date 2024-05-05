namespace Mastermind.UnitTests;
using static MastermindEvaluator;

[TestFixture]
public class MastermindEvaluatorTests
{
    [Test]
    public void Test_AllCorrect_WellPlaced()
    {
        Assert.That(Evaluate(["red", "blue"], ["red", "blue"]), Is.EqualTo((2, 0)));
    }

    [Test]
    public void Test_NoneCorrect()
    {
        Assert.That(Evaluate(["red", "blue"], ["green", "yellow"]), Is.EqualTo((0, 0)));
    }

    [Test]
    public void Test_SomeMisplaced()
    {
        Assert.That(Evaluate(["red", "blue", "green"], ["blue", "green", "red"]), Is.EqualTo((0, 3)));
    }

    [Test]
    public void Test_SomeCorrect_SomeMisplaced()
    {
        Assert.That(Evaluate(["red", "blue", "green", "yellow"], ["red", "green", "blue", "yellow"]), Is.EqualTo((2, 2)));
    }

    [Test]
    public void Test_RepeatColors_Misplaced()
    {
        Assert.That(Evaluate(["red", "red", "blue"], ["red", "blue", "red"]), Is.EqualTo((1, 2)));
    }

    [Test]
    public void Test_AllIncorrect()
    {
        Assert.That(Evaluate(["red", "blue", "green"], ["yellow", "purple", "orange"]), Is.EqualTo((0, 0)));
    }

    [Test]
    public void Test_EmptyLists()
    {
        Assert.That(Evaluate([], []), Is.EqualTo((0, 0)));
    }

    [Test]
    public void Test_RepeatColors_CorrectPlacement()
    {
        Assert.That(Evaluate(["red", "red", "blue", "blue"], ["red", "red", "blue", "blue"]), Is.EqualTo((4, 0)));
    }
    
    [Test]
    public void Test_DifferentLengths_ShouldThrowArgumentException()
    {
        string[] secret = [ "red", "blue", "green" ];
        string[] guess = [ "red", "blue" ];
        var ex = Assert.Throws<ArgumentException>(() => Evaluate(secret, guess));
        Assert.That(ex.Message, Is.EqualTo("Secret and guess must have the same number of elements."));
    }
}