//Афендулов Д. группа 1290
/*Зададча:
 * На плоскости задан прямоугольный участок. Задается он четырмя точками.
 * Стороны могут быть не параллельны осям.
 * Если площадь этого участка больше заданной, то для вспашки этого
 * участка нужен трактор. Если меньше, то мотоблок. Необходимо, чтобы
 * программа вывела координаты участка с выводом о том, чем он вспахан.*/

/*Сущности
 * Участок
 *     *массив из 4 точек
 *     
 *     -задание с консоли 
 *     -определение площади 
 *     -конвертация в строку 
 * 
 * Точка
 *     *координата х
 *     *координата y
 *     
 *     -задание с консоли 
 *     -определение расстояния до другой точки
 *     -конвертация в строку
 *     -правее ли точка
 *     -выше ли точка
 * 
 * Вспахивающая машина
 *     *имя
 *     
 *     -выбор по площади
 *     -получить имя
 * 
 * Принтер
 *      -печать вспахивающей машины
 *      -печать участка
 * 
 * Manager
 *     *Участок
 *     *Вспахивающая машина
 *     *Принтер
 *     
 *     -считать данные участка
 *     -выбрать машину вспашки по площади
 *     -напечать участок
 *     -напечатать машину для вспашки
 */


using System;

namespace Plowing
{
   class Program
   {
       static void Main(string[] args)
       {
            Plot plot = new Plot();
            plot.EnterFromConsole();

            PlowingMachine plowingMachine = new PlowingMachine();
            plowingMachine.ChoosedByArea(plot.Area());

            Printer printer = new Printer();

            printer.PrintPlot(plot.ConvertToString());
            printer.PrintPlowingMachine(plowingMachine.GetName());

            Console.ReadLine();
       }


        static public bool AreDoubleNumbersEquals(double number1, double number2)
        {
            return Math.Abs(number1 - number2) < 0.00001;
        }

   }
}
