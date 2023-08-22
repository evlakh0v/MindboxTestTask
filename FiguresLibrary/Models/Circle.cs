using System;
using FiguresLibrary.Interfaces;

namespace FiguresLibrary.Models;

public sealed class Circle: ISquareCalculable 
{
    public Circle(double radius) 
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be a positive number.");

        _radius = radius;
    }
    
    public double CalculateSquare() =>  Math.PI * Math.Pow(_radius, 2);
    
    private readonly double _radius;
}
