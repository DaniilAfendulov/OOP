using System;
using System.Collections.Generic;

namespace Plowing
{
    public class Plot
    { 
        private Point[] _points = new Point[4];
        public void EnterFromConsole()
        {
            for (int i = 0; i < _points.Length; i++)
            {
                _points[i] = new Point();
            }

            do
            {
                Console.WriteLine("Введите участок");
                for (int i = 0; i < _points.Length; i++)
                {
                    Console.WriteLine($"Введите {i+1} точку");
                    _points[i].EnterFromConsole();
                    Console.WriteLine();
                }             
            } while (!ArePointsValid());
        }
        public double Area()
        {
            Point[] rightPoints = FindTwoRightMostPoints();
            Point[] highestPoints = FindTwoHighestPoints();
            return rightPoints[0].DistanceToPoint(rightPoints[1])
                 * highestPoints[0].DistanceToPoint(highestPoints[1]);
        }

        public string ConvertToString()
        {
            List<string> points = new List<string>();
            for (int i = 0; i < _points.Length; i++)
            {
                points.Add($"{i+1} точка: {_points[i].ConvertToString()}");
            }
            return "Координаты участка: " + Environment.NewLine + string.Join(Environment.NewLine, points);

        }
        private Point[] FindTwoLowestPoints()
        {
            Point[] lowestPoints = new Point[2];
            lowestPoints[0] = _points[0];
            lowestPoints[1] = _points[1];

            for (int i = 1; i < _points.Length; i++)
            {
                if (lowestPoints[0].Higher(_points[i]))
                {
                    lowestPoints[1] = lowestPoints[0];
                    lowestPoints[0] = _points[i];
                }
                else if (lowestPoints[1].Higher(_points[i]))
                {
                    lowestPoints[1] = _points[i];
                }
            }
            return lowestPoints;
        }

        private Point[] FindTwoHighestPoints()
        {

            Point[] highestPoints = new Point[2];
            highestPoints[0] = _points[0];
            highestPoints[1] = _points[1];
            for (int i = 1; i < _points.Length; i++)
            {
                if (!highestPoints[0].Higher(_points[i]))
                {
                    highestPoints[1] = highestPoints[0];
                    highestPoints[0] = _points[i];
                }
                else if (!highestPoints[1].Higher(_points[i]))
                {
                    highestPoints[1] = _points[i];
                }
            }
            return highestPoints;
        }

        private Point[] FindTwoLeftMostPoints()
        {

            Point[] left_points = new Point[2];
            left_points[0] = _points[0];
            left_points[1] = _points[1];

            for (int i = 1; i < _points.Length; i++)
            {
                if (!left_points[0].Lefter(_points[i]))
                {
                    left_points[1] = left_points[0];
                    left_points[0] = _points[i];
                }
                else if (!left_points[1].Lefter(_points[i]))
                {
                    left_points[1] = _points[i];
                }
            }
            return left_points;
        }

        private Point[] FindTwoRightMostPoints()
        {

            Point[] right_points = new Point[2];
            right_points[0] = _points[0];
            right_points[1] = _points[1];

            for (int i = 1; i < _points.Length; i++)
            {
                if (right_points[0].Lefter(_points[i]))
                {
                    right_points[1] = right_points[0];
                    right_points[0] = _points[i];
                }
                else if (right_points[1].Lefter(_points[i]))
                {
                    right_points[1] = _points[i];
                }
            }
            return right_points;
        }

        private bool ArePointsValid()
        {
            Point[] leftPoints = FindTwoLeftMostPoints();
            Point[] rightPoints = FindTwoRightMostPoints();
            Point[] highestPoints = FindTwoHighestPoints();
            Point[] lowestPoints = FindTwoLowestPoints();

            return AreLineSegmentsEquals(leftPoints, rightPoints)
                   && AreLineSegmentsEquals(highestPoints, lowestPoints)
                   && IsRightAngle(leftPoints, highestPoints)
                   && IsRightAngle(leftPoints, lowestPoints)
                   && IsRightAngle(rightPoints, lowestPoints);
        }

        private bool AreLineSegmentsEquals(Point[] lineSegment1, Point[] lineSegment2)
        {
            if (lineSegment1.Length != 2 && lineSegment2.Length != 2)
            {
                throw new Exception(); 
            }
            return Program.AreDoubleNumbersEquals(lineSegment1[0].DistanceToPoint(lineSegment1[1]),
                                                  lineSegment2[0].DistanceToPoint(lineSegment2[1]));
        }

        private bool IsRightAngle(Point[] lineSegment1, Point[] lineSegment2)
        {
            if (lineSegment1.Length != 2 && lineSegment2.Length != 2 )
            {
                throw new Exception("not valid line segments");
            }

            Point[] hypotenuse = new Point[2];
            if (lineSegment1[0] == lineSegment2[0])
            {
                hypotenuse[0] = lineSegment1[1];
                hypotenuse[1] = lineSegment2[1];
            }
            else if (lineSegment1[0] == lineSegment2[1])
            {
                hypotenuse[0] = lineSegment1[1];
                hypotenuse[1] = lineSegment2[0];
            }
            else if (lineSegment1[1] == lineSegment2[0])
            {
                hypotenuse[0] = lineSegment1[0];
                hypotenuse[1] = lineSegment2[1];
            }
            else if (lineSegment1[1] == lineSegment2[1])
            {
                hypotenuse[0] = lineSegment1[0];
                hypotenuse[1] = lineSegment2[0];
            }
            else throw new Exception("have not intersection");

            return Program.AreDoubleNumbersEquals(
                Math.Pow(hypotenuse[0].DistanceToPoint(hypotenuse[1]),2),
                (Math.Pow(lineSegment1[0].DistanceToPoint(lineSegment1[1]),2) 
                + Math.Pow(lineSegment2[0].DistanceToPoint(lineSegment2[1]), 2)));
        }





    }
}