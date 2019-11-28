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
    public class Circle
    {
        Point _point;
        double _radius;
        public void ReadFromConsole()
        {
            _point = new Point();
            _point.ReadFromConcole();

            bool IsValid;
            do
            {
                IsValid = false;
                Console.Write("Введите радиус: ");
                if (double.TryParse(Console.ReadLine(), out _radius) && _radius >= 0)
                    IsValid = true;
            } while (!IsValid);
        }

        public void IsCrossingCircle(Circle circle2)
        {            

            if (_point.FindDistanceForPoint(circle2._point) <= _radius + circle2._radius
                    && _point.FindDistanceForPoint(circle2._point) >= Math.Abs(_radius - circle2._radius) )
            {
                Console.WriteLine("пересекаются");
            }
            else Console.WriteLine("не пересекаются");
        }
    }
}