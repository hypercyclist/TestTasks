using System;

class LibTest
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start test");
        Console.WriteLine("");

        Console.WriteLine("Get circle area:");
        Console.Write("Radius = 5.0, Area = ");
        Console.WriteLine(Circle.getArea(5.0));
        Console.WriteLine("");

        Console.WriteLine("Get triangle area:");
        Console.Write("Sides = 5.0, 5.0, 5.0, Area = ");
        Console.WriteLine(Triangle.getArea(5.0, 5.0, 5.0));
        Console.WriteLine("");

        Console.WriteLine("Is right triangle?");
        Console.Write("Sides = 5.0, 5.0, 5.0, is right = ");
        Console.WriteLine(Triangle.isRight(5.0, 5.0, 5.0));
        Console.Write("Sides = 26.0, 24.0, 10.0, is right = ");
        Console.WriteLine(Triangle.isRight(26.0, 24.0, 10.0));
        Console.WriteLine("");
        
        Console.WriteLine("End");
    }
}
