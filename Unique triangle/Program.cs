//Афендулов группа 1290
/*Задание:
 * В файле находятся отрезки. Их количество неизвестно.
 * Из каких отрезков можно построить уникальные 
 * прямоугольные треугольники.
 * Уникальным называют треугольник у которого
 * отличается хотя бы одна сторона.*/
/*Анализ задачи:
 * 1)Функции
 *  -считывание отрезков из файла
 *      -считывание отрезка
 *          -считывание точек
 *              -считывание точки
 *      -добавление отрезка в список отрезков  
 *  -найти все прямоугольные треугольники 
 *      -являются ли double числа равными
 *  -найти  уникальные треугольники в списке треугольников
 *      -являются ли треугольники равными
 *          -являются ли double числа равными
 *  -вывести треугольник
 * 2)Структуры данных
 *  -треугольник
 *      -массив из 3 отрезков
 *      (причем нулевой элемент массива является наибольшим по длине)
 *  -отрезок
 *      -массив из 2 точек
 *  -точка
 *      -координата x (вещественные число)
 *      -координата y (вещественные число)
 *      -координата z (вещественные число)
 *  -список отрезков
 *  -список треугольников

 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "file.txt";
            List<LineSegment> lineSegments = ReadLineSegmentsFromFile(filePath);
            List<Triangle> triangles = FindAllRightTriangles(lineSegments);
            triangles = FindUniqueTriangles(triangles);
            triangles.ForEach(triangle => PrintTriangle(triangle));
            Console.ReadLine();
        }


        public struct Triangle
        {
            public LineSegment[] sides;

            public Triangle(LineSegment side1, LineSegment side2, LineSegment side3)
            {
                sides = new LineSegment[] { side1, side2, side3 };
            }
        }

        public struct LineSegment
        {
            public Point[] points;
            public LineSegment(Point start, Point end)
            {
                points = new Point[] { start, end };
            }
        }

        public struct Point
        {
            public double x, y, z;
            public Point(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        private static List<Triangle> FindAllRightTriangles(List<LineSegment> lineSegments)
        {
            List<Triangle> triangles = new List<Triangle>();
            for (int i = 0; i < lineSegments.Count; i++)
            {
                for (int j = i+1; j < lineSegments.Count; j++)
                {
                    for (int k = j+1; k < lineSegments.Count; k++)
                    {
                        LineSegment side1 = lineSegments[i];
                        LineSegment side2 = lineSegments[j];
                        LineSegment side3 = lineSegments[k];
                        if (CuclculateLineSegmentLenght(side1) < CuclculateLineSegmentLenght(side2))
                        {
                            LineSegment temp = side1;
                            side1 = side2;
                            side2 = temp;
                        }
                        if (CuclculateLineSegmentLenght(side1) < CuclculateLineSegmentLenght(side3))
                        {
                            LineSegment temp = side1;
                            side1 = side3;
                            side3 = temp;
                        }
                        if(IsDoubleNumberEqual(Math.Pow(CuclculateLineSegmentLenght(side1), 2),
                            Math.Pow(CuclculateLineSegmentLenght(side2), 2) + Math.Pow(CuclculateLineSegmentLenght(side3), 2)))
                            triangles.Add(new Triangle(lineSegments[i], lineSegments[j], lineSegments[k]));
                    }
                }
            }
            return triangles;
        }

        private static List<Triangle> FindUniqueTriangles(List<Triangle> triangles)
        {
            List<Triangle> uniqueTriangles = new List<Triangle>();
            bool isUnique = true;
            if (triangles.Count != 0) uniqueTriangles.Add(triangles[0]);
            foreach (var triangle in triangles)
            {
                foreach (var uniqueTriangle in uniqueTriangles)
                {
                    if (IsEqual(triangle, uniqueTriangle)) isUnique = false;
                }
                if (isUnique) uniqueTriangles.Add(triangle);
            }
            return uniqueTriangles;
        }

        private static bool IsEqual(Triangle triangle1, Triangle triangle2)
        {
            List<double> sides1 = new List<double>();
            List<double> sides2 = new List<double>();
            for (int i = 0; i < 3; i++)
            {
                sides1.Add(CuclculateLineSegmentLenght(triangle1.sides[i]));
                sides2.Add(CuclculateLineSegmentLenght(triangle2.sides[i]));
            }
            sides1.Sort();
            sides2.Sort();
            for (int i = 0; i < 3; i++)
            {
                if (!IsDoubleNumberEqual(sides1[i], sides2[i])) return false;
            }
            return true;

        }

        public static bool IsDoubleNumberEqual(double number1, double number2)
        {
            return Math.Abs(number1 - number2) < 0.00001;
        }

        private static List<LineSegment> ReadLineSegmentsFromFile(string filePath)
        {
            List<LineSegment> lineSegments = new List<LineSegment>();
            using (StreamReader file = new StreamReader(filePath))
            {
                while (!file.EndOfStream) lineSegments.Add(ReadLineSegment(file));
            }
            return lineSegments;
        }

        private static LineSegment ReadLineSegment(StreamReader file)
        {           
            Point start = ReadPointFromFile(file);
            Point end = ReadPointFromFile(file);
            file.ReadLine();
            return new LineSegment(start, end);
        }

        private static Point ReadPointFromFile(StreamReader file)
        {
            List<double> coordinates = new List<double>();
            List<char> buffer = new List<char>();
            char a;
            while (file.Peek() != '(') a = (char)file.Read();
            a = (char)file.Read();
            while (file.Peek() != ')')
            {
                while (file.Peek() != ';' && file.Peek() != ')')
                {
                    buffer.Add((char)file.Read());
                }
                if (buffer.Count != 0) coordinates.Add(double.Parse(new string(buffer.ToArray())));
                else file.Read();
                buffer.Clear();
            }
            return new Point(coordinates[0], coordinates[1], coordinates[2]);
        }

        public static double CuclculateLineSegmentLenght(LineSegment lineSegment)
        {
            return Math.Sqrt(Math.Pow(lineSegment.points[0].x - lineSegment.points[1].x, 2)
                + Math.Pow(lineSegment.points[0].y - lineSegment.points[1].y, 2)
                + Math.Pow(lineSegment.points[0].z - lineSegment.points[1].z, 2));
        }

        private static void PrintTriangle(Triangle triangle)
        {
            foreach (var side in triangle.sides)
            {
                Console.Write("[");
                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"({side.points[i].x};{side.points[i].y};{side.points[i].z})");
                }
                Console.Write("]\t");
            }
            Console.WriteLine();
        }
    }
}
