using System;

namespace Plowing
{
    public class PlowingMachine
    {
        string _name;
        public void ChoosedByArea(double area)
        {
            double settedArea;
            do
            {
                Console.Write("Задайте минимальную площадь участка для вспашки которого нужен трактор: ");
            } while (!double.TryParse(Console.ReadLine(), out settedArea) && settedArea > 0);

            _name = area < settedArea ? "мотоблок" : "трактор";
        }

        public string GetName() => _name;

    }
}