//Платформа  .Net Framework 4.7.2
//Афендулов Д. группа 1290
#region Task
/* Задача: В файле содержится описание дома,
* необходимо по этому описанию ответить на вопросы:
* 1)Сколько в нем жильцов?
* 2)Сколько этажей?
* 3)Сколько квартир на заданном этаже?
* 4)Сколько жителей в заданной квартире?
* 5)Какие номера квартир на заданном этаже?
* 
* Описание дома состоит из:
* 1)id дома
* 2)количества этажей
* 3)для каждого этажа зада id этажа
* 4)для каждой квартиры заданы id и количество жильцов
*/
#endregion
#region File wiew
/* Вид файла:
* Дом <номер дома>
* Количество этажей <количество этажей>
* 
* Этаж <номер этажа>:
* Количество квартир <количество квартир>
* квартира <номер квартиры>: <количество жильцов> жильцов
* ...
* ...
* квартира <номер квартиры>: <количество жильцов> жильцов
* 
* ...
* ...
* Этаж <номер этажа>:
* Количество квартир <количество квартир>
* квартира <номер квартиры>: <количество жильцов> жильцов
*/
#endregion
#region Task analysis
/* Анализ задачи:
* Считывание информации о доме из файла
*      считывание общей информации о доме
*      считывание информации об этажах
*          считывание информации об этаже
*              считывание общей информации об этаже
*              считывание информации о квартирах 
*                  считывание информации о квартире
*                      поиск числа в строке
*              (*повторить, пока не считается информация о всех квартирах)
*      (*повторить, пока не считается информация о всех этажах)
* Запуск машины запросов
*      вывод меню(список вопросов о доме)
*      считывание ответа
*      выполнение запроса или завершение работы программы
*      (*повторить, пока не поступит запрос о завершении) 
*      
* Структуры данных
*      дом(состоит из номера дома, этажей и их количества в доме)
*      этаж(состоит из номера этажа, квартир и их количества на нем)
*      квартира(состоит из номера квартиры и количества жильцов в ней)
*      запросы(перечисление)
*/
#endregion


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = ReadHouseInfoFromFile(new StreamReader("House.txt"));
            StartMachineOfRequests(house);
        }

        #region Structures of data
        struct House
        {
            public int number, floorsAmount;
            public List<Floor> floors;
        }

        struct Floor
        {
            public int number, flatsAmount;
            public List<Flat> flats;
        }

        struct Flat
        {
            public int number, residentsAmount;
        }

        enum Requests
        {
            residentsAmount = 1,
            floorsAmount,
            flatsAmountOnTheFloor,
            residentsAmountInFlat,
            flatsNumbersOnTheFloor,
            exit
        }
        #endregion

        #region Reading functions
        static House ReadHouseInfoFromFile(StreamReader reader)
        {
            House house;
            string lineInFile = reader.ReadLine();
            house.number = SearchNumberInLine(lineInFile + ".", "Дом ", ".");

            lineInFile = reader.ReadLine();
            house.floorsAmount = SearchNumberInLine(lineInFile + ".", "Количество этажей ", ".");
            reader.ReadLine();

            house.floors = new List<Floor>();
            for (int i = 0; i < house.floorsAmount ; i++)
            {
                house.floors.Add(ReadFloorFromFile(reader));
            }
            reader.Close();
            return house;
        }

        static Floor ReadFloorFromFile(StreamReader reader)
        {
            Floor floor;
            string lineInFile = reader.ReadLine();
            floor.number = SearchNumberInLine(lineInFile, "Этаж", ":");

            lineInFile = reader.ReadLine();
            floor.flatsAmount = SearchNumberInLine(lineInFile + ".", "Количество квартир ", ".");

            floor.flats = new List<Flat>();
            for (int i = 0; i < floor.flatsAmount; i++)
            {
                floor.flats.Add(ReadFlatFromFile(reader));
            }
            reader.ReadLine();
            return floor;
        }

        static Flat ReadFlatFromFile(StreamReader reader)
        {
            Flat flat;
            string lineInFile = reader.ReadLine();
            flat.number = SearchNumberInLine(lineInFile, "квартира ", ":");
            flat.residentsAmount = SearchNumberInLine(lineInFile, ": ", "жильцов");
            return flat;
        }

        static int SearchNumberInLine(string line, string startMark, string endMark)
        {
            line = line.Replace(" ", "").ToLower();
            startMark = startMark.Replace(" ", "").ToLower();
            endMark = endMark.Replace(" ", "").ToLower();
            int startOfNumber = line.IndexOf(startMark) + startMark.Length;
            int endOfNumber = line.IndexOf(endMark);
            return int.Parse(line.Substring(startOfNumber, endOfNumber - startOfNumber));
        }
        #endregion

        #region Machine of requests
        
        static void StartMachineOfRequests(House house)
        {
            string[] requests = new string[]
            {
                "1)Сколько в доме жильцов?",
                "2)Сколько этажей в доме?",
                "3)Сколько квартир на заданном этаже?",
                "4)Сколько жителей в заданной квартире?",
                "5)Какие номера квартир на заданном этаже?",
                "6)Выход"
            };
            while (true)
            {
                WriteRequestsList(requests);
                Requests request = ReadRequest(requests);
                string answer = FindRequestedInfo(request, house);
                if (answer != null)
                {
                    Console.WriteLine("\n" + answer + "\n");
                }
                else break;

            }

        }



        static void WriteRequestsList(string[] requests)
        {
            foreach(string request in requests)
            {
                Console.WriteLine(request);
            }
        }
        static Requests ReadRequest(string[] requests)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int requestNumber))
                {
                    if (requestNumber <= (int)Requests.exit && requestNumber >= 1)
                    {
                        return (Requests)requestNumber;
                    }
                }
                Console.WriteLine("некорректное значение, попробуйте еще раз\n");
            }
        }

        static string FindRequestedInfo(Requests request, House house)
        {
            switch (request)
            {
                case Requests.residentsAmount:
                    return FindResidentsAmount(house);
                case Requests.floorsAmount:
                    return FindFloorsAmount(house);
                case Requests.flatsAmountOnTheFloor:
                    return FindFlatsAmountOnTheFloor(house);
                case Requests.residentsAmountInFlat:
                    return FindResidentsAmountInFlat(house);
                case Requests.flatsNumbersOnTheFloor:
                    return FindFlatsNumbersOnTheFloor(house);
                case Requests.exit:
                    return null;
            }
            return "данная информация не может быть получена";
        }

        static string FindResidentsAmount(House house)
        {
            int ResidentsAmount = 0;
            foreach (Floor floor in house.floors)
            {
                foreach (Flat flat in floor.flats)
                {
                    ResidentsAmount += flat.residentsAmount;
                }
            }
            return string.Format("количество жильцов в доме: {0}", ResidentsAmount);
        }

        static string FindFloorsAmount(House house)
        {
            return string.Format("количество этажей: {0}", house.floorsAmount);
        }

        static string FindFlatsAmountOnTheFloor(House house)
        {
            Floor floor = ReadRequestedFloor(house);
            return string.Format("количество квартир на {0} этаже равно {1}", floor.number , floor.flatsAmount);
        }

        static string FindResidentsAmountInFlat(House house)
        {
            Flat flat = ReadRequestedFlat(house);
            return string.Format("количество жильцов в квартире {0} равно {1}", flat.number, flat.residentsAmount);
        }

        static Floor ReadRequestedFloor(House house)
        {
            while (true)
            {
                Console.WriteLine("введите номер этажа");
                Console.WriteLine("Список этажей:");
                foreach (var floor in house.floors)
                {
                    Console.WriteLine(floor.number);
                }
                if (int.TryParse(Console.ReadLine(), out int requestNumber))
                {
                    foreach (var floor in house.floors)
                    {
                        if (floor.number == requestNumber)
                            return floor;
                    }
                }
                Console.WriteLine("некорректное значение, попробуйте еще раз" + "\n");
            }
        }

        static Flat ReadRequestedFlat(House house)
        {
            while (true)
            {
                Console.WriteLine("введите номер квартиры");
                Console.WriteLine("Список квартир:");
                foreach (var floor in house.floors)
                {
                    Console.WriteLine("Этаж {0}", floor.number);
                    foreach (var flat in floor.flats)
                    {
                        Console.Write(flat.number + "\t");
                    }
                    Console.WriteLine();
                }
                if (int.TryParse(Console.ReadLine(), out int requestNumber))
                {
                    foreach (var floor in house.floors)
                    {
                        foreach (var flat in floor.flats)
                        {
                            if (flat.number == requestNumber)
                                return flat;
                        }
                    }
                }
                Console.WriteLine("некорректное значение, попробуйте еще раз" + "\n");
            }
        }

        static string FindFlatsNumbersOnTheFloor(House house)
        {
            Floor floor = ReadRequestedFloor(house);
            string answer = string.Format("Номера квартир на {0} этаже:\n", floor.number);
            foreach (Flat flat in floor.flats)
            {
                answer += flat.number + "\t";
            }
            return answer;
        }

        #endregion
    }
}
