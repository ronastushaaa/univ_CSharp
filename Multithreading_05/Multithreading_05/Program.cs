using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_05
{
    internal class Program
    {
        private class ThreadData
        {
            public string id;
            public int iterations;
        }
        static void Main(string[] args)
        {

            // Параметры: число итераций для каждого потока 
            int[] workloads = new int[5];
            workloads[0] = 50000;
            workloads[1] = 100000;
            workloads[2] = 200000;
            workloads[3] = 500000;
            workloads[4] = 1000000;

            ThreadPriority[] priorities = new ThreadPriority[5];
            priorities[0] = ThreadPriority.Normal;
            priorities[1] = ThreadPriority.Normal;
            priorities[2] = ThreadPriority.Normal;
            priorities[3] = ThreadPriority.Normal;
            priorities[4] = ThreadPriority.Normal;
            
            Console.WriteLine("Запуск 5 потоков с вычислительной нагрузкой (x = Math.Sin(x))\n");
            Thread[] threads = new Thread[5];

            int i = 0;
            while (i < 5)
            {
                ThreadData data = new ThreadData();
                data.id = (i + 1).ToString();
                data.iterations = workloads[i];

                ParameterizedThreadStart starter = new ParameterizedThreadStart(function);
                Thread t = new Thread(starter);
                t.Priority = priorities[i];
                threads[i] = t;

                t.Start(data);
                i += 1;
            }

            Compute("0", 250000); // средняя нагрузка

            i = 0;
            while (i < 5)
            {
                threads[i].Join();
                i = i + 1;
            }

            Console.WriteLine("\n Все потоки завершили работу.");
            Console.ReadKey(); 
        }

        static void function (object obj)
        {
            ThreadData data = (ThreadData)obj;
            Compute(data.id, data.iterations);
        }

        static void Compute(string threadId, int iterations)
        {
            Console.WriteLine("[START] Поток \"" + threadId + "\" НАЧАЛ вычисления.");
            double id = double.Parse(threadId);
            double x = 1 + id * Math.PI;

            int cnt = 0;
            while (cnt < iterations)
            {
                x = Math.Sin(x);
                cnt += 1;
            }

            Console.WriteLine("[END] Поток \"" + threadId + "\" ЗАВЕРШИЛ " +
                                          iterations.ToString("N0") + " итераций. x = " + x.ToString("F6"));
        }
    }
}
