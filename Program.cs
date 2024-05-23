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
                Console.WriteLine();
                fromUnit = GetUnit(type);
                if (fromUnit == Unit.UnitType.Undefined) continue;

                DisplayConversion(fromUnit);
                Console.WriteLine();
                toUnit = GetUnit(type, fromUnit);
                if (toUnit == Unit.UnitType.Undefined) continue;

                DisplayTitle("Conversion Calculator", 30);
                DisplayConversion(fromUnit, toUnit);
                ConversionCalculator(fromUnit, toUnit, type);
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
                from = Unit.Pluralize(fromUnit);
                fromUnderline = new string(' ', from.Length);

                if (toUnit == Unit.UnitType.Undefined)
                {
                    to = "_____";
                    toUnderline = "^^^^^";
                }
                else
                {
                    to = Unit.Pluralize(toUnit);
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

        static void ConversionCalculator(Unit.UnitType fromUnit, Unit.UnitType toUnit, ConversionType type)
        {
            string fromUnits = Unit.Pluralize(fromUnit);
            string toUnits = Unit.Pluralize(toUnit);

            Console.Write($"Enter value in {fromUnits} (0 to exit): ");

            double value = 1;
            while (true)
            {
                try
                {
                    value = Convert.ToDouble(Console.ReadLine());
                    if (value == 0) break;

                    switch (type)
                    {
                        case ConversionType.Length:
                            Length length = new Length(value, fromUnit);
                            length.ConvertTo(toUnit);
                            Console.WriteLine("= " + length.ToString());
                            Console.WriteLine();
                            break;
                        case ConversionType.Temperature:
                        // length.ConvertTo(toUnit);
                        // break;
                        case ConversionType.Volume:
                        // length.ConvertTo(toUnit);
                        // break;
                        case ConversionType.Weight:
                        // length.ConvertTo(toUnit);
                        // break;
                        default:
                            break;
                    }

                    Console.Write($"Enter value in {fromUnits}: ");
                }
                catch
                {
                    Console.WriteLine("Invalid value");
                    Console.Write($"Enter value in {fromUnits}: ");
                }
            }

            Console.WriteLine();
        }


    }
}
