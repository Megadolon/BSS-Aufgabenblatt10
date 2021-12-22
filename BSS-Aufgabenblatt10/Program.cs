using System.Collections.Generic;
using System;

namespace BSS_Aufgabenblatt10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Process> processes = new List<Process>();

            processes.Add(new Process(22, 25, 0));
            processes.Add(new Process(2, 7, 0));
            processes.Add(new Process(3, 10, 4));
            processes.Add(new Process(5, 15, 4));
            processes.Add(new Process(8, 8, 4));

            PrintProcesses(processes);
            IScheduler scheduler;
            scheduler = new EDF();
            Console.WriteLine("Wait Time" + scheduler.Solve(processes));
            PrintProcesses(processes);

            //aufgabe 2
            //Console.WriteLine("Aufgabe 2:");
            //for (int i = 1; i < 10; i++)
            //{
            //    scheduler = new RoundRobin(i);
            //    Console.WriteLine("Wait Time: " + scheduler.Solve(processes));
            //}
            //PrintProcesses(processes);

        }

        private static void PrintProcesses(List<Process> processes)
        {
            processes.ForEach(p =>
            {
                Console.WriteLine("Execution Time   : " + p.executionTime_.ToString());
                Console.WriteLine("Ready Time       : " + p.readyTime_.ToString());
                Console.WriteLine("Deadline Time    : " + p.deadline_.ToString());
                Console.WriteLine("----------------------------------------------");
            });
        }
    }
}
