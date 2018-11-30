using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CoveringSegments
{
    class Program
    {
        public class Segment
        {
            public int Start;
            public int End;

            public Segment(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }
        }

        public static List<int> optimal_points(List<Segment> segments)
        {
            List<int> points = new List<int>();
            segments.Sort(new Comparison<Segment>((x,y) => x.End.CompareTo(y.End)));
            int point = segments[0].End;
            points.Add(point);
 
            for (int i = 1; i < segments.Count; i++)
            {
                if (point < segments[i].Start || point > segments[i].End)
                {
                    point = segments[i].End;
                    points.Add(point);
                }
            }
            return points;
        }


        static void Main(string[] args)
        {
            int numberOfSegments = Int32.Parse(Console.ReadLine());

            List<Segment> segments = new List<Segment>();

            for (int i = 0; i < numberOfSegments; i++)
            {
                var input = Console.ReadLine().Split(' ');
                Segment seg = new Segment(Int32.Parse(input[0]), Int32.Parse(input[1]));
                segments.Add(seg);
            }

            List<int> points = optimal_points(segments);
            Console.WriteLine(points.Count);
            string output = String.Empty;

            for (int i = 0; i < points.Count; i++)
            {
                output += points[i].ToString();
                output += " ";
            }

            Console.WriteLine(output);
        }
    }
}
