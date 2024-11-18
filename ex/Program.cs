using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String line;
            try
            {
                for (int i = 10; i < 30; i++)
                {
                    StreamReader sr = new StreamReader($"{i}.txt");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}
