//Афендулов Даниил групппа 1290
/* Задание: 
 * В файле заданы имена и телефоны.
 * Необходимо вывести имена и телефоны,
 * где имена начинающиеся с заданной буквы.
 */
/*Аналаиз задачи:
 *  Предметная область:
 *      - работа с файлами
 *      - телефонная книга(состоит из пар имен и номеров телефонов)
 *      
 *  Функции-требования:
 *      Чтение телефонной книги из файла
 *          Чтение пары из файла
 *              Чтение имени из файла
 *              Чтение номера из файла
 *          Проверка пары на валидность
 *          Добавление пары в телефонную книгу
 *      Вывод пар телефонной книги, начинающихся с одной буквы
 *          Чтение буквы(метки) для поиска
 *          Нахождение пар с подходящим именем
 *              Проверка: соответствует ли имя пары искомому
 *          Вывод пар     
 *     
 *  Структуры данных:
 *      -Телефонная книга - Словарь, где ключ - это имя владельца(строка),
 *       а значение - это соответствующий ему номер телефона(массив целых чисел)            
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> phoneBook = ReadPhoneBookFromFile("PhoneBook.txt");
            PrintPhonesBySameFirstLetter(phoneBook);
            Console.ReadKey();
        }

        static Dictionary<string, int[]> ReadPhoneBookFromFile(string filePath)
        {
            var phoneBook = new Dictionary<string, int[]>();
            using (StreamReader file = new StreamReader(filePath))
            {
                while (!file.EndOfStream)
                {
                    while ((char)file.Peek() == ' ') file.Read();
                    string name = ReadNameFromFile(file);
                    int[] phoneNumber = ReadNumberFromFile(file);
                    if (IsValid(name) && IsValid(phoneNumber)) phoneBook.Add(name, phoneNumber);
                }
            }
            return phoneBook;
        }

        static int[]  ReadNumberFromFile(StreamReader file)
        {
            List<int> number = new List<int>();
            string[] parts = new string[] { " ", "+", "(", ")", "-" };
            char[] lineChars = DeletePartsOfString(file.ReadLine(), parts).ToCharArray();
            foreach (var lineChar in lineChars)
            {
                if (int.TryParse(lineChar.ToString(), out int digit)) number.Add(digit);
                else return null;
            }
            return number.ToArray();
        }
        static string ReadNameFromFile(StreamReader file)
        {
            string name = string.Empty;
            while ((char)file.Peek() != ' ')
            {
                name += (char)file.Read();
            }
            return name;
        }
        static string DeletePartsOfString(string oldString, string[] parts)
        {
            foreach (var part in parts)
            {
                oldString = oldString.Replace(part, "");
            }
            return oldString;
        }
        static bool IsValid(string name)
        {
            if (String.IsNullOrEmpty(name)) return false;
            return true;
        }
        
        static bool IsValid(int[] phoneNumber)
        {
            if (phoneNumber == null) return false;
            return true;
        }

        static void PrintPhonesBySameFirstLetter(Dictionary<string, int[]> phoneBook)
        {
            char firstLetter = ReadFirstLetterForSearchFromConsole();
            Dictionary<string, int[]> requestedPhoneBook = FindPhonesBySameFirstLetter(firstLetter, phoneBook);
            PrintPhoneBook(requestedPhoneBook);
        }

        static Dictionary<string, int[]> FindPhonesBySameFirstLetter(char firstLetter, Dictionary<string, int[]> phoneBook)
        {
            var requestedPhones = new Dictionary<string, int[]>();
            foreach (var phone in phoneBook)
            {
                if (phone.Key.ToCharArray()[0] == firstLetter)
                {
                    requestedPhones.Add(phone.Key, phone.Value);
                }
            }
            return requestedPhones;
        }
        static char ReadFirstLetterForSearchFromConsole()
        {
            Console.Write("введите букву с которой начинаются искомые имена: ");
            return (char)Console.Read();
        }
        static void PrintPhoneBook(Dictionary<string, int[]> PhoneBook)
        {
            if (PhoneBook.Count == 0)
            {
                Console.WriteLine("Телефонов с заданной буквы не найдено");
            }
            else
            {
                foreach (var phone in PhoneBook)
                {
                    Console.Write($"{phone.Key}\t");
                    foreach (int digit in phone.Value) Console.Write(digit);
                    Console.WriteLine();
                }
            }         
        }
    }
}
