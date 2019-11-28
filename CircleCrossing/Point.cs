//Афендулов Д. группа 1290
/*Задание
 * Задано 2 окружности. Окружность задается
 * центром и радиусом. Необходимо попределить
 * имеется ли пересечение. В случае, если есть 
 * пересечение, то вывести "да пересекается", 
 * если нет, то "нет пересечения"*/

/*Сущности:
 * Окружность(точка и радиус(число))
 *     -пересекается ли с окружностью
 *     -ввод окружности
 * Точка(2 координаты(числа))
 *     -ввод точки
 *     -определение расстояния до точки
 * Manager(2 окружности)
 *     -Запрос о пересечении окружностей*/

using System;

namespace CircleCrossing
{
    public class Point
    {
        double _x, _y;
        public void ReadFromConcole()
        {
            bool IsValid;
            do
            {
                IsValid = true;
                Console.WriteLine("Введите координаты центра окружности");

                Console.Write("Введите x: ");
                if (!double.TryParse(Console.ReadLine(), out _x))
                    IsValid = false;

                Console.Write("Введите y: ");
                if (!double.TryParse(Console.ReadLine(), out _y))
                    IsValid = false;


            } while (!IsValid);
        }

        public double FindDistanceForPoint(Point point)
        {
            return Math.Sqrt(Math.Pow(_x - point._x, 2) + Math.Pow(_y - point._y, 2));
        }
    }
}