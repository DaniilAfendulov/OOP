﻿//Афендулов Д. группа 1290
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

namespace CircleCrossing
{
    class Manager
    {
        Circle _circle1, _circle2;
        public void IsCirclesCrossing()
        {
            _circle1 = new Circle();
            _circle2 = new Circle();
            _circle1.ReadFromConsole();
            _circle2.ReadFromConsole();
            _circle1.IsCrossingCircle(_circle2);
        }
    }
}