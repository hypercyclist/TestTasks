using System;

public class Circle
{
    private Circle() {}

    public static double getArea(double radius)
    {
        return Math.PI * radius * radius;
    }
}
