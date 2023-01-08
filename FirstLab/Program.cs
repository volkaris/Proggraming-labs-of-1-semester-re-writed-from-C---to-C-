using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var amount_of_lines = 0; //
            var amount_of_words = 0; //
            var amount_of_letters = 0;//
            var amount_of_bytes = new FileInfo("D:\\c#\\ConsoleApp3\\ConsoleApp3\\1234.txt").Length; //
            List<string> result = new List<string>();
            string text=null;
            StreamReader reader = new StreamReader("D:\\c#\\ConsoleApp3\\ConsoleApp3\\1234.txt", Encoding.Default, true);
            while (true)
            {
                
                var str = reader.ReadLine();
                if (str == null) //достигнут конец файла
                    break;
                else
                {
                    //amount_of_lines++;
                    string[] arr_1 = str.Split(' ');
                    
                    foreach (var s in arr_1)
                    {
                        if (s!=" " && s!="")
                            result.Add(s);
                        text+=s;
                    }
                }
            }
            amount_of_lines=File.ReadLines("D:\\c#\\ConsoleApp3\\ConsoleApp3\\1234.txt").Count();
            amount_of_letters =text.Length;
            amount_of_words =result.Count;

            Console.WriteLine($"Количество строк: {amount_of_lines} Количество слов: {amount_of_words} Количество символов: {amount_of_letters} Количество байт: {amount_of_bytes}");

        }
    
    
    }
    
    
}
