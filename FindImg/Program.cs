using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

//Задача
//6. ***В заданной папке найти во всех html файлах теги <img src=...> и вывести названия картинок. Использовать регулярные выражения.
//Автор Матюков Евгений

namespace FindImg
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parsePath = new string[3];

            // Получаем список файлов в папке. AllDirectories - сканировать так же и подпапки
            string[] fs = Directory.GetFiles("e:\\temp", "*.*", SearchOption.AllDirectories);
            // Просматриваем каждый файл в массиве
            foreach (var filename in fs)
            {
                // Создаем регулярное выражения дя поиска почтовых адресов
                Regex regex = new Regex(@"<[ ]{0,4}img[ ]{0,4}src[ ]{0,4}=[ ]{0,4}""[:;?'/_ A-Za-z0-9.()]{1,200}""");  

                // Считываем файл
                string s = File.ReadAllText(filename);
                Console.WriteLine(filename);
         
                // Выводим найденные адреса на экран
                foreach (var path in regex.Matches(s))
                {
                    try
                    {
                        parsePath = path.ToString().Split('"');
                        Console.WriteLine("     {0}", parsePath[1]);
                    }
                    catch
                    {
                        break;
                    }
                }
                Console.WriteLine("\n");
            }
            
            Console.ReadKey();

        }
    }
}
