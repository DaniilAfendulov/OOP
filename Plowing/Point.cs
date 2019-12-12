using System;

namespace Plowing
{
    public class Point
    {
        double _x, _y;
        public void EnterFromConsole()
        {
            bool IsValid;
            do
            {
                IsValid = true;
                Console.WriteLine("Введите координаты точки");

                Console.Write("Введите x: ");
                if (!double.TryParse(Console.ReadLine(), out _x))
                    IsValid = false;

                Console.Write("Введите y: ");
                if (!double.TryParse(Console.ReadLine(), out _y))
                    IsValid = false;

            } while (!IsValid);
        }

        public bool Lefter(Point point) => _x < point._x;


        public double DistanceToPoint(Point point)
        {
            return Math.Sqrt(Math.Pow(_x - point._x, 2) + Math.Pow(_y - point._y, 2));
        }

        public bool Higher(Point point) => _y > point._y;

        public string ConvertToString()
        {
            return $"({String.Format("{0:f4}", _x)};{String.Format("{0:f4}", _y)})";
        }
    }
}