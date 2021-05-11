using System;
using System.Collections.Generic;

public class Triangle
{
    private Triangle() {}

    public static double getArea(double AB, double BC, double CA)
    {
        double P = (AB + BC + CA) / 2;
        return Math.Sqrt(P * (P - AB) * (P - BC) * (P - CA));
    }

    public static bool isRight(double AB, double BC, double CA)
    {
        List<double> sides = new List<double>();
        sides.Add(AB);
        sides.Add(BC);
        sides.Add(CA);
        sides.Sort();
        sides.Reverse();
        return sides[0] * sides[0] == sides[1] * sides[1] + sides[2] * sides[2];
    }
}
