using System;
using FiguresLibrary;
using FiguresLibrary.Interfaces;
using FiguresLibrary.Models;
using Xunit;

namespace FiguresTests;

public class Tests 
{
    [Fact]
    public void TriangleIntegerSidesTest() 
    {
        ISquareCalculable triangle = new Triangle(3, 4, 5);
        Assert.True(CompareSquares(6d, triangle.CalculateSquare()));
        Assert.True((triangle as Triangle)?.IsRight());
    }
    
    [Fact]
    public void TriangleFractionalSidesTest() 
    {
        ISquareCalculable triangle = new Triangle(0.5, 0.5, 0.5);
        Assert.True(CompareSquares(Math.Sqrt(3) / 16, triangle.CalculateSquare()));
        Assert.False((triangle as Triangle)?.IsRight());
    }
    
    [Fact]
    public void TriangleIrrationalSidesTest() 
    {
        ISquareCalculable triangle = new Triangle(3 * Math.Sqrt(11), 3 * Math.Sqrt(11), 4 * Math.Sqrt(11));
        Assert.True(CompareSquares(11 * Math.Sqrt(20), triangle.CalculateSquare()));
        Assert.False((triangle as Triangle)?.IsRight());
    }
    
    [Fact]
    public void DegenerateTriangleTest() 
    {
        Assert.Throws<ArgumentException>(() => new Triangle(Math.Sqrt(3), Math.Sqrt(3), 2 * Math.Sqrt(3)));
    }
    
    [Fact]
    public void TriangleNegativeSideTest() 
    {
        Assert.Throws<ArgumentException>(() => new Triangle(-4, 4, 4));
    }

    [Fact]
    public void CircleIntegerRadiusTest() 
    {
        ISquareCalculable circle = new Circle(1);
        Assert.True(CompareSquares(Math.PI, circle.CalculateSquare()));
    }
    
    [Fact]
    public void CircleFractionalRadiusTest() 
    {
        ISquareCalculable circle = new Circle(1.374);
        Assert.True(CompareSquares(Math.PI * Math.Pow(1.374, 2), circle.CalculateSquare()));
    }
    
    [Fact]
    public void CircleIrrationalRadiusTest() 
    {
        ISquareCalculable circle = new Circle(Math.Sqrt(17));
        Assert.True(CompareSquares(Math.PI * 17, circle.CalculateSquare()));
    }

    [Fact]
    public void CircleZeroRadiusTest() 
    {
        Assert.Throws<ArgumentException>(() => new Circle(0));
    }
    
    [Fact]
    public void CircleNegativeRadiusTest() 
    {
        Assert.Throws<ArgumentException>(() => new Circle(-Math.Sqrt(2)));
    }

    private static bool CompareSquares(double expectedSquare, double actualSquare) =>
        Math.Abs(expectedSquare - actualSquare) < Constants.Epsilon;
}
   