/*
 * Afendulov D.group 1290
 *
 *Задание: в файле задано N прямоугольников.
 *Каждый прямоугольник задается левой верхней и правой нижней точками.
 *Каждая точка задается двумя вещественными числами - их координатами.
 *Пользователь вводит точку и нужно вывести характеристики прямоугольников
 *в которых лежит эта точка.
 *
 *Анализ задачи:
 * 
 *Считывание прямоугольников из файла
 *   Считывание левой точки
 *   Считывание правой точки
 *   
 *Проверка валидности данных о прямоугольниках
 * 
 *Считывание точки 
 * 
 *Нахождение прямоугольноков в которых лежит точка
 * 
 *Вывод характеристик прямоугольноков в которых лежит точка
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle[] rectangles = ReadRectanglesFromFile("File.txt");
            if (IsDataValid(rectangles))
            {
                ReadPointFromConsole();
                Rectangle[] rectanglesWithPoinIn = FindRectanglesWithPointIn(rectangles);
                WriteCharacteristicOfRectangles(rectanglesWithPoinIn);
            }
            else
                WriteMessageAboutUnvalidData();            
        }

        static Point _point;
        struct Point
        {
            public double x, y;
        }

        struct Rectangle
        {
            public Point leftUpperPoint, rightLowerPoint;
        }

        static Rectangle[] ReadRectanglesFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            int amountOfRectangles = File.ReadLines(path).Count();
            Rectangle[] rectangles = new Rectangle[amountOfRectangles];

            string textLine;
            string[] coordinatesInLine;
            double[] coordinates = new double[4];
            
            for(int i = 0; i < amountOfRectangles; i++)
            {
                textLine = reader.ReadLine();
                coordinatesInLine = textLine.Split(' ');
                for (var k = 0; k < 4; k++)
                    coordinates[k] = double.Parse(coordinatesInLine[k]);
                rectangles[i].leftUpperPoint = GetPointFromNumbers(coordinates[0], coordinates[1]);
                rectangles[i].rightLowerPoint = GetPointFromNumbers(coordinates[2], coordinates[3]);
            }
            return rectangles;
        }

        static Point GetPointFromNumbers(double x, double y)
        {
            Point point;
            point.x = x;
            point.y = y;
            return point;
        }

        static bool IsDataValid(Rectangle[] rectangles)
        {
            foreach (var rectangle in rectangles)
            {
                if ((rectangle.leftUpperPoint.x < rectangle.rightLowerPoint.x) &&
                    (rectangle.leftUpperPoint.y > rectangle.rightLowerPoint.y) )
                    return true;
            }
            return false;
        }

        static void WriteMessageAboutUnvalidData()
        {
            Console.WriteLine("введённые данные невалидны");
            Console.ReadKey();
        }

        static void ReadPointFromConsole()
        {
            Console.WriteLine("введите координаты точки x, y через пробел соответственно");
            string[] coordinatesInLine = Console.ReadLine().Split();
            double x = double.Parse(coordinatesInLine[0]);
            double y = double.Parse(coordinatesInLine[1]);
            _point = GetPointFromNumbers(x, y);
        }

        static Rectangle[] FindRectanglesWithPointIn(Rectangle[] rectangles)
        {
            List<Rectangle> choosenRectengles = new List<Rectangle>(rectangles);
            return choosenRectengles.FindAll(IsPointInRectangle).ToArray();
        }

        static bool IsPointInRectangle(Rectangle rectangle)
        {
            return ((rectangle.leftUpperPoint.x <= _point.x) &&
                (rectangle.rightLowerPoint.x >= _point.x) &&
                (rectangle.leftUpperPoint.y >= _point.y) &&
                (rectangle.rightLowerPoint.y <= _point.y));
        }
        static void WriteCharacteristicOfRectangles(Rectangle[] rectangles)
        {
            foreach(Rectangle rectangle in rectangles)
            {
                Console.WriteLine("leftUpperPoint: ({0};{1})", rectangle.leftUpperPoint.x, rectangle.leftUpperPoint.y);
                Console.WriteLine("rightLowerPoin: ({0};{1})", rectangle.rightLowerPoint.x, rectangle.rightLowerPoint.y);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
