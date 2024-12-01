using System;
using System.IO;
using System.Text;

namespace ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[40];
            int j = 0;
            int mult;
            int summ = 0;
            int count = 0;
            int temp = 0;
            try
            {
                for (int i = 10; i < 30; i++)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader($"{i}.txt"))
                        {
                            string line = sr.ReadLine();
                            string line1 = sr.ReadLine();
                            arr[j] = int.Parse(line);
                            arr[j+1] = int.Parse(line1);
                            Console.WriteLine($"File {i}.txt: {arr[j]}");
                            Console.WriteLine($"File {i}.txt: {arr[j+1]}");
                            mult = arr[j] * arr[j+1];
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        using (StreamWriter writer = new StreamWriter("no_file.txt", true))
                        {
                            writer.WriteLine(i + ".txt");
                        }
                        continue;
                    }
                    catch (FormatException)
                    {
                        using (StreamWriter writer = new StreamWriter("bad_data.txt", true))
                        {
                            writer.WriteLine(i + ".txt");
                        }
                        continue;
                    }
                    catch (OverflowException)
                    {
                        using (StreamWriter writer = new StreamWriter("overflow.txt", true))
                        {
                            writer.WriteLine(i + ".txt");
                        }
                        continue;
                    }
                    catch (InvalidDataException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    j += 2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception: " + e.Message);
            }
            Console.WriteLine(summ/count);
            Console.ReadLine();
        }
    }
}
