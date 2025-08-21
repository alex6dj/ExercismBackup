public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3) =>
        IsTriangle(side1, side2, side3) &&
        (side1 != side2 && side2 != side3 && side1 != side3);

    public static bool IsIsosceles(double side1, double side2, double side3) =>
        IsTriangle(side1, side2, side3) && 
        (side1 == side2 || side2 == side3 || side1 == side3);

    public static bool IsEquilateral(double side1, double side2, double side3) =>
        IsTriangle(side1, side2, side3) &&
        (side1 == side2 && side2 == side3);

    private static bool IsTriangle(double side1, double side2, double side3) => 
        SidesGraterThanZero(side1, side2, side3) && 
        IsRightSideLength(side1, side2, side3);

    private static bool SidesGraterThanZero(double side1, double side2, double side3) =>
        side1 > 0 && side2 > 0 && side3 > 0;

    private static bool IsRightSideLength(double side1, double side2, double side3) =>
        side1 + side2 >= side3 &&
        side2 + side3 >= side1 &&
        side3 + side1 >= side2;
}