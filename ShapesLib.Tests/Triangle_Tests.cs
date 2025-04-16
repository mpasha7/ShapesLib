namespace ShapesLib.Tests;

public class Triangle_Tests
{
    [Fact]
    public void Triangle_TakesPositiveSides()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        var result = triangle.Sides;

        Assert.NotNull(result);
        Assert.Equal(3, result[0]);
        Assert.Equal(4, result[1]);
        Assert.Equal(5, result[2]);
    }

    [Fact]
    public void Triangle_DontTakesZeroSide()
    {
        Assert.Throws<ArgumentException>(() => { Triangle triangle = new Triangle(0, 4, 5); });
    }

    [Fact]
    public void Triangle_DontTakesNegativeSide()
    {
        Assert.Throws<ArgumentException>(() => { Triangle triangle = new Triangle(3, -4, 5); });
    }

    [Fact]
    public void Triangle_DontTakesTooBigSide()
    {
        Assert.Throws<ArgumentException>(() => { Triangle triangle = new Triangle(3, 4, 8); });
    }

    [Fact]
    public void TrySetSide_TakesPositiveSide()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        triangle.TrySetSide(0, 5);
        var result = triangle.Sides;

        Assert.NotNull(result);
        Assert.Equal(5, result[0]);
        Assert.Equal(4, result[1]);
        Assert.Equal(5, result[2]);
    }

    [Fact]
    public void TrySetSide_DontTakesIndexOutOfRange()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        bool result1 = triangle.TrySetSide(-1, 5);
        bool result2 = triangle.TrySetSide(3, 5);
        var resultSides = triangle.Sides;

        Assert.False(result1);
        Assert.False(result2);
        Assert.NotNull(resultSides);
        Assert.Equal(3, resultSides[0]);
        Assert.Equal(4, resultSides[1]);
        Assert.Equal(5, resultSides[2]);
    }

    [Fact]
    public void TrySetSide_DontTakesZeroSide()
    {
        Triangle triangle = new Triangle(1, 1, 1);

        bool result = triangle.TrySetSide(0, 0);
        var resultSides = triangle.Sides;

        Assert.False(result);
        Assert.NotNull(resultSides);
        Assert.Equal(1, resultSides[0]);
        Assert.Equal(1, resultSides[1]);
        Assert.Equal(1, resultSides[2]);
    }

    [Fact]
    public void TrySetSide_DontTakesNegativeSide()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        bool result = triangle.TrySetSide(0, -1);
        var resultSides = triangle.Sides;

        Assert.False(result);
        Assert.NotNull(resultSides);
        Assert.Equal(3, resultSides[0]);
        Assert.Equal(4, resultSides[1]);
        Assert.Equal(5, resultSides[2]);
    }

    [Fact]
    public void TrySetSide_DontTakesTooBigSide()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        bool result = triangle.TrySetSide(2, 8);
        var resultSides = triangle.Sides;

        Assert.False(result);
        Assert.NotNull(resultSides);
        Assert.Equal(3, resultSides[0]);
        Assert.Equal(4, resultSides[1]);
        Assert.Equal(5, resultSides[2]);
    }

    [Fact]
    public void GetArea_CanCalculateArea()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        var result = triangle.GetArea();

        Assert.Equal(6, result, 0.000000000001);
    }

    [Fact]
    public void GetPerimeter_CanCalculatePerimeter()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        var result = triangle.GetPerimeter();

        Assert.Equal(12, result, 0.000000000001);
    }

    [Fact]
    public void IsRight_True()
    {
        Triangle triangle = new Triangle(3, 4, 5);

        var result = triangle.IsRight();

        Assert.True(result);
    }

    [Fact]
    public void IsRight_False()
    {
        Triangle triangle = new Triangle(5, 5, 5);

        var result = triangle.IsRight();

        Assert.False(result);
    }
}
