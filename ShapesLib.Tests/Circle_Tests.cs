namespace ShapesLib.Tests;

public class Circle_Tests
{
    [Fact]
    public void Circle_TakesPositiveRadius()
    {
        Circle circle = new Circle(1);

        var result = circle.Radius;

        Assert.Equal(1, result);
    }

    [Fact]
    public void Circle_DontTakesZeroRadius()
    {
        Assert.Throws<ArgumentException>(() => { Circle circle = new Circle(0); });
    }

    [Fact]
    public void Circle_DontTakesNegativeRadius()
    {
        Assert.Throws<ArgumentException>(() => { Circle circle = new Circle(-1); });
    }

    [Fact]
    public void SetRadius_TakesPositiveRadius()
    {
        Circle circle = new Circle(1);

        circle.Radius = 2;
        var result = circle.Radius;

        Assert.Equal(2, result);
    }

    [Fact]
    public void SetRadius_DontTakesZeroRadius()
    {
        Circle circle = new Circle(1);
        Assert.Throws<ArgumentException>(() => { circle.Radius = 0; });
    }

    [Fact]
    public void SetRadius_DontTakesNegativeRadius()
    {
        Circle circle = new Circle(1);
        Assert.Throws<ArgumentException>(() => { circle.Radius = -1; });
    }

    [Fact]
    public void GetArea_CanCalculateArea()
    {
        Circle circle = new Circle(10);

        var result = circle.GetArea();

        Assert.Equal(100 * Math.PI, result, 0.000000000001);
    }

    [Fact]
    public void GetPerimeter_CanCalculatePerimeter()
    {
        Circle circle = new Circle(10);

        var result = circle.GetPerimeter();

        Assert.Equal(20 * Math.PI, result, 0.000000000001);
    }
}
