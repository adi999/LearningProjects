using System;

namespace PointsAndSegments
{
    class Program
    {
        static void Main(string[] args)
        {
            var countInput = Console.ReadLine()?.Split(' ');

            int numberOfSegments;
            int numberOfPoints;
            if (countInput != null)
            {
                numberOfSegments = Int32.Parse(countInput[0]);
                numberOfPoints = Int32.Parse(countInput[1]);
            }


        }
    }
}
