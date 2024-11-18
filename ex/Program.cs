using System;
using System.IO;

namespace ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[40];
            int j = 0;
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
                            if (string.IsNullOrEmpty(line))
                            {
                                throw new InvalidDataException($"File {i}.txt contains no valid data.");
                            }

                            arr[j] = int.Parse(line);
                            arr[j+1] = int.Parse(line1);
                            Console.WriteLine($"File {i}.txt: {arr[j]}");
                            Console.WriteLine($"File {i}.txt: {arr[j+1]}");
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine($"File {i}.txt does not exist.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"File {i}.txt contains invalid data.");
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

            Console.ReadLine();
        }
    }
}
