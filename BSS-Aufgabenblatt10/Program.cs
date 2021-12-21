using System.Collections.Generic;
using System;

namespace BSS_Aufgabenblatt10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Process> processes = new List<Process>();

            processes.Add(new Process(22));
            processes.Add(new Process(2));
            processes.Add(new Process(3));
            processes.Add(new Process(5));
            processes.Add(new Process(8));

            processes.ForEach(p =>
            {
                Console.WriteLine("Execution Time   : " + p.executionTime_.ToString());
                Console.WriteLine("Ready Time       : " + p.readyTime_.ToString());
                Console.WriteLine("Deadline Time    : " + p.deadline_.ToString());
                Console.WriteLine("----------------------------------------------");
            });



            IScheduler scheduler = new SJF();
            Console.WriteLine(scheduler.Solve(processes));

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
