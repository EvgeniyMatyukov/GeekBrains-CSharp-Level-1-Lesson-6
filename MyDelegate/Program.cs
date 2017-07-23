using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Задача
//1.Изменить программу вывода функции так, чтобы можно было передавать функции типа double(double,double). Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
//Автор Матюков Евгений

namespace MyDelegate
{

    public delegate double Fun(double a, double x);


    class Program
    {

        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("a = " + a);
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double ax2(double a, double x)
        {
            return a * x * x;
        }

        public static double asinx(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Таблица функции a * x^2");
            Table(ax2, 3, -2, 2);

            Console.WriteLine("Таблица функции a * sin(x)");
            Table(asinx, 3, -2, 2);


            Console.ReadKey();

        }
    }
}
