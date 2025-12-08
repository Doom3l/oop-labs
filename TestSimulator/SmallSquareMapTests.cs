using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        var m = new SmallSquareMap(10);
        Assert.Equal(10, m.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrow(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Fact]
    public void Exist_ShouldReturnTrueInside()
    {
        var m = new SmallSquareMap(5);
        Assert.True(m.Exist(new Point(0, 0)));
        Assert.True(m.Exist(new Point(4, 4)));
    }

    [Fact]
    public void Exist_ShouldReturnFalseOutside()
    {
        var m = new SmallSquareMap(5);
        Assert.False(m.Exist(new Point(-1, 0)));
        Assert.False(m.Exist(new Point(5, 5)));
    }

    [Fact]
    public void Next_Outside_ShouldStop()
    {
        var m = new SmallSquareMap(5);
        var p = new Point(4, 4);
        var next = m.Next(p, Direction.Right);

        Assert.Equal(p, next);
    }

    [Fact]
    public void NextDiagonal_Outside_ShouldStop()
    {
        var m = new SmallSquareMap(5);
        var p = new Point(4, 4);
        var next = m.NextDiagonal(p, Direction.Right);

        Assert.Equal(p, next);
    }
}
