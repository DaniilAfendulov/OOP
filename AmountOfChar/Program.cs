//Афендулов Д.Ю. группа 1290
//
//Задание: Пользователь вводит текст, 
//подсчитать количество каждой из букв 
//
using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ReadText(new StreamReader("TextFile.txt"));
            Dictionary<char, uint> charactersDictionary = CalculateAmountOfCharacters(text);
            PrintAmountOfCharacters(charactersDictionary);
        }

        static string ReadText(StreamReader reader)
        {
            return reader.ReadToEnd();
        }

        static Dictionary<char, uint> CalculateAmountOfCharacters(string text)
        {
            var charactersDictionary = new Dictionary<char, uint>();
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();

            foreach (var character in alphabet)            
                charactersDictionary.Add(character, 0);   
            
            char[] TextInChar = text.ToLower().ToCharArray();
            foreach (var character in TextInChar)
            {
                if (charactersDictionary.ContainsKey(character))
                    charactersDictionary[character]++;
            }       
            
            return charactersDictionary;
        }

        static void PrintAmountOfCharacters(Dictionary<char, uint> charactersDictionary)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
            foreach (var character in alphabet)
                Console.WriteLine("{0} : {1}", character, charactersDictionary[character]);
            Console.ReadKey();
        }


    }
}
