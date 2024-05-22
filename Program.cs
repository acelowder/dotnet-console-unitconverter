using System;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[ Unit Converter ]");

            int choice = 0;
            do
            {
                Console.WriteLine("1. Length");
                Console.WriteLine("2. Temperature");
                Console.WriteLine("3. Volume");
                Console.WriteLine("4. Weight");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    choice = 0;
                }

                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice.");
                }
                Console.WriteLine();
            } while (choice < 1 || choice > 5);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("[ Length Conversion ]");
                    break;
                case 2:
                    Console.WriteLine("[ Temperature Conversion ]");
                    break;
                case 3:
                    Console.WriteLine("[ Volume Conversion ]");
                    break;
                case 4:
                    Console.WriteLine("[ Weight Conversion ]");
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}