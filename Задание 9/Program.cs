using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_9
{
    class Point
    {
        public int Data { get; set; }      //информационное поле
        public Point Next { get; set; }    //следующий элемент

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="next">Следующий элемент</param>
        public Point(int data, Point next)
        {
            Data = data;
            Next = next;
        }

        /// <summary>
        /// Преобразование в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Data + " ";
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            int size;
            Console.Write("Введите количество элементов списка:");      //количество элементов списка
            while (!Int32.TryParse(Console.ReadLine(), out size) || (size < 1) ||size > 100)
                Console.WriteLine("Введи число больше 1, но не выходящие за пределы допустимого значения 100!");

            Console.WriteLine("Введите 1 элемент последовательности:"); //первый элемент списка
            Point beg1 = MakeList(size);                //полученный список
            Console.Write("Исходный список: ");       //печать списка
            Print(beg1);
            Difference(beg1);                           //Нахождение разности сумм             
            Console.ReadKey();
        }
        /// <summary>
        /// Инициализация списка
        /// </summary>
        /// <param name="size">Длина списка</param>
        /// <returns></returns>
        static Point MakeList(int size)
        {
            Point beg1 = new Point(IsInt(), null);      //первый элемент списка
            Point last1 = beg1;                            //последний элемент списка
            for (int i = 1; i < size; i++)
            {
                Console.WriteLine(String.Format($"Введите {i + 1} элемент последовательности:"));
                Point p = new Point(IsInt(), null);     //добавляемый элемент
                last1.Next = p;                            //переход к следующему элементу
                last1 = p;                                 //инициализация элемента
            }

            return beg1;
        }
        /// <summary>
        /// Вычисление разности сумм
        /// </summary>
        /// <param name="beg">Первый элемент списка</param>
        /// <returns></returns>
        static void Difference (Point beg)
        {
            Point p = beg;                   //первый элемент списка
            int chetn = 0, nechetn = 0;
            while (p != null)
            {
                if (p.Data % 2 == 0)
                    chetn += p.Data;
                else nechetn += p.Data;
                    p = p.Next;                  //переход к следующему элементу
            }
            Console.WriteLine("\nПосчитанная разность: {0}", chetn-nechetn);
        }
        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="beg">Первый элемент списка</param>
        static void Print(Point beg)
        {
            Point p = beg;                          //первый элемент списка
            while (p.Next != null)                  //печать элементов списка
            {
                Console.Write(p.ToString());
                p = p.Next;
            }
            Console.Write(p.ToString());            //печать последнего элемента списка
            Console.WriteLine();
        }
        /// <summary>
        /// Проверка ввода элементов
        /// </summary>
        /// <returns></returns>
        static int IsInt()
        {
            int el;
            while (!Int32.TryParse(Console.ReadLine(), out el))
            Console.WriteLine("Ошибка ввода! Ожидалось целое число!");
            return el;
        }
    }

}
