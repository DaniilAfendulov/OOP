//Афендулов Д. группа 1290
/*Задача:
 * В файле находятся следующие струтуры данных:
 *    __
 *    |     <название улицы>
 *Nшт |     <номер дома>
 *    |     <количество жильцов>
 *    __
 *    
 *    Необходимо по заданному имени улицы вывести
 *    отсортированный список домов. 
 *    Пользователь выбирает сортировать по количеству жильцов или по номеру дома,
 *    а также в порядке возрастания или убывания их выводить.
 */
/*Анализ задачи:
 *     1)Основные функции:
 *         -Задание  домов
 *              -Чтение домов из файла
 *         -Задание улицы для поиска
 *              -Чтение улицы для поиска
 *         -Поиск списка домов по заданной улице              
 *         -Задание порядка сортировки
 *              -Чтение порядка сортировки
 *         -Задание критерия сортировки
 *              -Чтение критерия сортировки
 *         -Сортировка списка  домов
 *              -Сравнение домов
 *         -Вывод списка домов 

 *     2)Структуры данных
 *         -Словарь(Dictionary):
 *             -ключ: улица(string)
 *             -значение: список домов(List)
 *         -Дом(Struct): 
 *             -номер дома(int)
 *             -количество жильцов(int)
 *         -Порядок сортировки(Enum)
 *              -по возрастанию
 *              -по убыванию
 *         -Критерий сортировки(Enum)
 *              -по количеству жильцов
 *              -по номеру дома
 *         -Comparer(Class : IComparer)
 *              -реализует сравнение домов основываясь на
 *              критерии сортировки и порядке сортировки
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace AdressesProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<House>> Houses = ReadHousesFromFile("file.txt");
            string searchingStreet = ReadSearchingStreet();
            if (Houses.ContainsKey(searchingStreet))
            {
                List<House> houses = Houses[searchingStreet];
                SortCriterion sortCriterion = ReadSortCriterion();
                SortOrder sortOrder = ReadSortOrder();
                houses.Sort(new HouseComparer(sortCriterion, sortOrder));
                PrintHouses(houses);
            }
            else Console.WriteLine("Улица не найдена");
            Console.ReadLine();
        }

        private static SortCriterion ReadSortCriterion()
        {
            while (true)
            {
                Console.WriteLine("Как отсортировать?");
                Console.WriteLine("1 - по количеству жильцов");
                Console.WriteLine("2 - по номерам домов");
                if (int.TryParse(Console.ReadLine(), out int requestNumber)
                    && (requestNumber == 1 || requestNumber == 2))
                {
                    return (SortCriterion)requestNumber;
                }
            }
        }
        public enum SortCriterion
        {
            ResidentsAmount = 1,
            Number
        }
        public enum SortOrder
        {
            descending = -1,
            ascending = 1
        }
        public struct House
        {
            public int number, residentsAmount;

            public House(int number, int residentsAmount)
            {
                this.number = number;
                this.residentsAmount = residentsAmount;
            }
        }
        public class HouseComparer : IComparer<House>
        {
            SortCriterion sortCriterion;
            SortOrder sortOrder;

            public HouseComparer(SortCriterion sortCriterion, SortOrder sortOrder)
            {
                this.sortCriterion = sortCriterion;
                this.sortOrder = sortOrder;
            }

            public int Compare(House x, House y)
            {
                switch (sortCriterion)
                {
                    case SortCriterion.ResidentsAmount:
                        switch (sortOrder)
                        {
                            case SortOrder.descending:
                                return -x.residentsAmount.CompareTo(y.residentsAmount);
                            case SortOrder.ascending:
                                return x.residentsAmount.CompareTo(y.residentsAmount);
                        }
                        break;
                    case SortCriterion.Number:
                        switch (sortOrder)
                        {
                            case SortOrder.descending:
                                return -x.number.CompareTo(y.number);
                            case SortOrder.ascending:
                                return x.number.CompareTo(y.number);
                        }
                        break;
                }
                throw new NotImplementedException();
            }
        }

        static Dictionary<string, List<House>> ReadHousesFromFile(string filePath)
        {
            Dictionary<string, List<House>> houses = new Dictionary<string, List<House>>();
            using (StreamReader file = new StreamReader(filePath))
            {
                while (!file.EndOfStream)
                {
                    string street = file.ReadLine();
                    if (int.TryParse(file.ReadLine(), out int houseNumber)
                        && int.TryParse(file.ReadLine(), out int residentsAmount))
                    {
                        if (houses.ContainsKey(street)) houses[street].Add(new House(houseNumber, residentsAmount));
                        else houses.Add(street, new List<House>() { new House(houseNumber, residentsAmount) });
                    }
                }
            }
            return houses;
        }
        static string ReadSearchingStreet()
        {
            Console.WriteLine("Введите улицу");
            return Console.ReadLine();
        }
        static SortOrder ReadSortOrder()
        {
            while (true)
            {
                Console.WriteLine("В каком порядке вывести?");
                Console.WriteLine("1 - по возрастанию");
                Console.WriteLine("-1 - по убыванию");
                if (int.TryParse(Console.ReadLine(), out int requestNumber) 
                    && (requestNumber == 1 || requestNumber == -1))
                {
                    return (SortOrder)requestNumber;
                }
            }
        }
        static void PrintHouses(List<House> houses)
        {
            houses.ForEach(house => Console.WriteLine($"number: {house.number}\tresidents: {house.residentsAmount}"));
        }
    }
}
