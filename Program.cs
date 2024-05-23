using System;
using System.Drawing;

namespace UnitConverter
{
    class Program
    {
        enum ConversionType
        {
            Length = 1,
            Temperature = 2,
            Volume = 3,
            Weight = 4,
            Exit = 5
        }

        static void Main(string[] args)
        {
            ConversionType type;
            Unit.UnitType fromUnit, toUnit;

            string[] conversionOptions = new string[] { "Length", "Temperature", "Volume", "Weight", "Exit" };

            while (true)
            {
                DisplayTitle("Unit Converter", 30);
                Enum.TryParse(Menu(conversionOptions), out type);
                if (type == ConversionType.Exit) break;

                DisplayTitle("Select Conversion", 30);
                Console.WriteLine();
                DisplayConversion();

                fromUnit = GetUnit(type);
                if (fromUnit == Unit.UnitType.Undefined) continue;
                DisplayConversion(fromUnit);
                toUnit = GetUnit(type, fromUnit);
                if (toUnit == Unit.UnitType.Undefined) continue;

                DisplayTitle("Conversion Calculator", 30);
                DisplayConversion(fromUnit, toUnit);
                // ConversionCalculator(fromUnit, toUnit);
            }
            Environment.Exit(0);
        }

        static void DisplayTitle(string text, int size)
        {
            string bar = new string('=', size);
            string indent = new string(' ', (size - text.Length) / 2);

            Console.WriteLine(bar);
            Console.WriteLine(indent + text);
            Console.WriteLine(bar);
        }

        static string Menu(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine();
            Console.Write("Enter your choice (1-{0}): ", options.Length);

            int choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                choice = 0;
            }

            while (choice < 1 || choice > options.Length)
            {
                Console.WriteLine("Invalid choice");
                Console.Write("Enter your choice (1-{0}): ", options.Length);

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }
            }

            string choiceText = options[choice - 1];
            Console.WriteLine(">" + choiceText);
            Console.WriteLine();
            return choiceText;
        }


        static void DisplayConversion(Unit.UnitType fromUnit = Unit.UnitType.Undefined, Unit.UnitType toUnit = Unit.UnitType.Undefined)
        {
            string from, fromUnderline, to, toUnderline;
            if (fromUnit == Unit.UnitType.Undefined)
            {
                from = "_____";
                fromUnderline = "^^^^^";

                to = "_____";
                toUnderline = "     ";
            }
            else
            {
                from = fromUnit.ToString();
                fromUnderline = new string(' ', fromUnit.ToString().Length);

                if (toUnit == Unit.UnitType.Undefined)
                {
                    to = "_____";
                    toUnderline = "^^^^^";
                }
                else
                {
                    to = toUnit.ToString();
                    toUnderline = "     ";
                }
            }

            Console.WriteLine($"Convert from {from} to {to}");
            if (fromUnit == Unit.UnitType.Undefined || toUnit == Unit.UnitType.Undefined)
            {
                Console.WriteLine($"             {fromUnderline}    {toUnderline}");
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static Unit.UnitType GetUnit(ConversionType type, Unit.UnitType fromUnit = Unit.UnitType.Undefined)
        {
            switch (type)
            {
                case ConversionType.Length:
                    string[] lengthUnits = new string[] { "Meter", "Kilometer", "Foot", "Yard", "Mile" };
                    if (lengthUnits.Contains(fromUnit.ToString()))
                        lengthUnits = lengthUnits.Where(u => u != fromUnit.ToString()).ToArray();
                    Unit.UnitType unit = fromUnit;
                    Enum.TryParse(Menu(lengthUnits), out unit);
                    return unit;
                case ConversionType.Temperature:
                // return new Temperature();
                case ConversionType.Volume:
                // return new Volume();
                case ConversionType.Weight:
                // return new Weight();
                default:
                    return Unit.UnitType.Undefined;
            }
        }
    }
}