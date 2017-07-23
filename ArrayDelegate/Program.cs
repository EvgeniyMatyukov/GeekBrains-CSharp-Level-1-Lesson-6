using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Задача
//2. *Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
//Сделать меню с различными функциями и представьте пользователю выбор для какой функции и на каком отрезке находить минимум. 
//Используйте массив делегатов.
//Автор Матюков Евгений

namespace ArrayDelegate
{

    public delegate double Fun(double x); //прототип функции

    class Program
    {
        /// <summary>
        /// Поиск минимального значения функции на отрезке a..b с шагом step
        /// </summary>
        /// <param name="F">указатель на функцию</param>
        /// <param name="a">начальная точка отрезка</param>
        /// <param name="b">конечная точка отрезка</param>
        /// <param name="step">шаг увеличения координаты</param>
        public static void MinValue(Fun F, double a, double b, double step)
        {

            double min = F(a);

            Console.WriteLine("Минимальное значение функции от {0,5:0.00} до {1,5:0.00} с шагом {2,5:0.00}", a, b, step);

            do 
            {
                a += step;
                if (min > F(a)) min = F(a);
            }
            while (a <= b);

            Console.WriteLine("min F(x) = {0,5:0.00}", min);
        }
        
        static void Main(string[] args)
        {
            int funcPointer = 0; //указатель на функцию
            double a, b;
            double step = 0.5; //шаг

            Func<double, double>[] funcs = new Func<double, double>[3]; //массив из функций
            funcs[0] = x => x * x - 50 * x + 10;
            funcs[1] = x => x * x * x;
            funcs[2] = x => 10 * Math.Sin(x) + 5;


            while (true)
            {

                Console.WriteLine("Программа найдет минимум функции на указанном отрезке от a до b");

                Console.WriteLine("Выберите функцию от 0 до 2, или нажмите enter, 3 для выхода");
                Console.WriteLine("[0] y = x * x - 50 * x + 10");
                Console.WriteLine("[1] y = x * x * x");
                Console.WriteLine("[2] y = 10 * Sin(x) + 5");
                Console.WriteLine("[3] Exit");

                try
                {
                    funcPointer = Convert.ToInt16(Console.ReadLine());
                    if (funcPointer < 0 || funcPointer > 3) funcPointer = 0;
                    if (funcPointer == 3) return;
                }
                catch
                {
                    funcPointer = 0;
                }

                Console.Write("Введите начальную точку отрезка a=");
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите конечную точку отрезка b=");
                    b = Convert.ToDouble(Console.ReadLine());
                    if (b < a + step) b = a + 200;
                }
                catch
                {
                    a = -100;
                    b = 100;
                }


                MinValue(new Fun(funcs[funcPointer]), a, b, step);

                //MinValue(x => x * x, 10, 20, 1);

                Console.WriteLine();
                
            }
            //Console.ReadKey();

        }
    }
}
