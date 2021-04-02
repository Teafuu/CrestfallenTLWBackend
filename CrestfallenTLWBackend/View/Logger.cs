using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrestfallenTLWBackend.View
{
    public static class Logger
    {
        public static Queue<string> Logs { get; set; } = new Queue<string>();
        public static void Log(string log) {
            string logMsg = $"{DateTime.Now}: {log}";
            Console.WriteLine(logMsg);
            Logs.Enqueue(logMsg);
        }
        public static void SaveLogs() //legacy, should be changed.
        {
            using (FileStream fs = File.Create("logs.txt"))
                while(Logs.Count > 0)
                    fs.Write(Encoding.UTF8.GetBytes($"{Logs.Dequeue()}\n"));
        }
    }
}
