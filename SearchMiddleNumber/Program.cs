//Афендулов Д.Ю. группа 1290
//Задание1: Задано 3 разных числа. Найти из них то,
//которое не является ни минимальным, ни максимальным.


using System;
using System.Collections.Generic;

namespace SearchMiddleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = ReadThreeNumbersFromConsole();
            double middleNumber = FindMiddleNumber(numbers);
            PrintMiddleNumber(middleNumber);

        }        

        private static double[] ReadThreeNumbersFromConsole()
        {
            double[] numbers = new double[3];
            Console.WriteLine("Введите три числа, каждое через Enter:");
            for(int i = 0; i < 3; i++)
            {
                numbers[i] = ReadNumberFromConsole();
            }
            return numbers;
        }

        private static double ReadNumberFromConsole()
        {
            return double.Parse(Console.ReadLine());
        }

        private static double FindMiddleNumber(double[] numbers)
        {
            double middleNumber;
            double minNumber = double.MaxValue;
            byte indexMinNumber = 0;
            List<double> listNumbers = new List<double>(numbers);

            for (byte i = 0; i < 3; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                    indexMinNumber = i;
                }
            }

            listNumbers.RemoveAt(indexMinNumber);

            if (listNumbers[0] > listNumbers[1])
                middleNumber = listNumbers[1];
            else
                middleNumber = listNumbers[0];

            return middleNumber;
        }

        private static void PrintMiddleNumber(double number)
        {
            Console.WriteLine("Среднее число равно: " + number);
            Console.ReadKey();
        }
    }
}
