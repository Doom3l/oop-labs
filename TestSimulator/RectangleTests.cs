using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidPoints_ShouldSetXY()
    {
        var r = new Rectangle(1, 2, 5, 6);
        Assert.Equal("(1, 2):(5, 6)", r.ToString());
    }

    [Fact]
    public void Constructor_ShouldSwapCoordinatesIfWrongOrder()
    {
        var r = new Rectangle(5, 6, 1, 2);
        Assert.Equal("(1, 2):(5, 6)", r.ToString());
    }

    [Fact]
    public void Constructor_ShouldThrowWhenCollinear()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 2, 1, 10));
    }

    [Fact]
    public void Contains_ShouldCheckCorrectly()
    {
        var r = new Rectangle(0, 0, 10, 10);
        Assert.True(r.Contains(new Point(5, 5)));
        Assert.False(r.Contains(new Point(-1, 0)));
    }
}
