using System;
using FiguresLibrary.Interfaces;

namespace FiguresLibrary.Models;

public sealed class Triangle: ISquareCalculable 
{
    public Triangle(double a, double b, double c) 
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("All sides of triangle must be positive numbers.");
        
        _minimumSide = Math.Min(a, Math.Min(b, c));
        _maximumSide = Math.Max(a, Math.Max(b, c));
        _mediumSide = a + b + c - _minimumSide - _maximumSide;

        if (_minimumSide + _mediumSide - _maximumSide < Constants.Epsilon)
            throw new ArgumentException("Triangle cannot be degenerate.");
    }
    
    public double CalculateSquare() 
    {
        var semiperimeter = (_minimumSide + _mediumSide + _maximumSide) / 2;
        return Math.Sqrt(semiperimeter * (semiperimeter - _minimumSide) * (semiperimeter - _mediumSide) * (semiperimeter - _maximumSide));
    }
    
    public bool IsRight() => Math.Abs(Math.Pow(_maximumSide, 2) - Math.Pow(_mediumSide, 2) - Math.Pow(_minimumSide, 2)) < Constants.Epsilon;
    
    private readonly double _minimumSide, _mediumSide, _maximumSide;
}
