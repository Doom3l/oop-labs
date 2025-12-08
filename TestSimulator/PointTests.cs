using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Next_Right_ShouldIncreaseX()
    {
        var p = new Point(10, 20);
        var next = p.Next(Direction.Right);
        Assert.Equal(new Point(11, 20), next);
    }

    [Fact]
    public void NextDiagonal_Right_ShouldMoveCorrectly()
    {
        var p = new Point(10, 20);
        var next = p.NextDiagonal(Direction.Right);
        Assert.Equal(new Point(11, 19), next);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedCoordinates()
    {
        var p = new Point(5, 7);
        Assert.Equal("(5, 7)", p.ToString());
    }
}
