using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива случайных целых чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Action<object> action1 = new Action<object>(CreateArray);
            Task task1 = new Task(action1, n);
            Action<Task<int[]>> action2 = new Action<Task<int[]>>(Max);
            Task task2 = task1.ContinueWith(action2);
            Action<Task<int[]>> action3 = new Action<Task<int[]>>(Summa);
            Task task3 = task2.ContinueWith(action3);
            Console.ReadKey();
        }
        static void CreateArray(object z)
        {
            int n = (int)z;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 20);
                Console.Write($"{array[i]} ");
            }
        }
        static void Max(Task<int[]> task)
        {
            int[] array = task.Result;
            int num = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                if (num >= 0)
                {
                    num = array[i];
                }
            }
            Console.WriteLine("Самое большое число: {0}", num);
        }
        static void Summa(Task<int[]> task)
        {
            int[] array = task.Result;
            int Sum = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                Sum += array[i];
            }
        }
    }
}
