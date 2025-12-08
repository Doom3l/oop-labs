using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-1, 0, 10, 0)]
    [InlineData(50, 0, 10, 10)]
    public void Limiter_ShouldClampCorrectly(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Fact]
    public void Shortener_ShouldTrimTooLong()
    {
        var s = Validator.Shortener("abcdefghijk", 3, 5, '#');
        Assert.Equal("abcde", s);
    }

    [Fact]
    public void Shortener_ShouldPadTooShort()
    {
        var s = Validator.Shortener("a", 3, 10, '#');
        Assert.Equal("a##", s);
    }

    [Fact]
    public void Shortener_ShouldReplaceWhitespace()
    {
        var s = Validator.Shortener("   ", 3, 10, '#');
        Assert.Equal("###", s);
    }
}
