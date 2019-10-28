//Афендулов Д.Ю. группа 1290
//Задание2:  Задано 10 чисел. Найти число,
//наиболее близкое к среднему числу диапазона.
using System;

namespace SearchNumberAboutAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = ReadTenNumbersFromConsole();
            double closestToAveregeNumber = FindAboutAveregeNumber(numbers);
            PrintAboutAveregeNumber(closestToAveregeNumber);
        }

        static double[] ReadTenNumbersFromConsole()
        {
            double[] numbers = new double[10];

            Console.WriteLine("Введите десять чисел, каждое через Enter:");

            for (int i = 0; i < 10; i++)
            {
                numbers[i] = ReadNumberFromConsole();
            }

            return numbers;
        }

        static double ReadNumberFromConsole()
        {
            return double.Parse(Console.ReadLine());
        }

        static void PrintAboutAveregeNumber(double number)
        {
            Console.WriteLine("Близкое к среднему число равно: " + number);

            Console.ReadKey();
        }

        static double FindAboutAveregeNumber(double[] numbers)
        {
            double averegeNumber = 0,
                minDifference = double.MaxValue,
                closestToAveregeNumber = 0;

            foreach (double number in numbers)
            {
                averegeNumber += number;
            }

            averegeNumber /= 10;

            for (byte i = 0; i < 10; i++)
            {
                if (Math.Abs(averegeNumber - numbers[i]) < minDifference)
                {
                    minDifference = Math.Abs(averegeNumber - numbers[i]);
                    closestToAveregeNumber = numbers[i];
                }
            }

            return closestToAveregeNumber;
        }
    }
}

