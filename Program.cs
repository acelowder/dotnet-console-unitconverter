using System;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int conversionType;
            Unit.UnitType fromUnit;
            // Unit toUnit;

            while (true)
            {
                conversionType = ConversionMenu();
                if (conversionType == 5) break;
                DisplayConversion();
                fromUnit = GetFrom(conversionType);
                if (fromUnit == Unit.UnitType.Undefined) continue;
                DisplayConversion(fromUnit);
                // toUnit = GetTo();
                // if (!toUnit) continue;
                // DisplayConversion(fromUnit, toUnit);
                // ConversionCalculator(fromUnit, toUnit);
            }
            Environment.Exit(0);
        }

        static int ConversionMenu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("        Unit Converter        ");
            Console.WriteLine("==============================");
            Console.WriteLine("Choose a conversion type:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Temperature");
            Console.WriteLine("3. Volume");
            Console.WriteLine("4. Weight");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice (1-5): ");

            int choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                choice = 0;
            }

            while (choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice");
                Console.Write("Enter your choice (1-5): ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    choice = 0;
                }
            }

            Console.WriteLine();

            return choice;
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
                Console.WriteLine($"     {fromUnderline}    {toUnderline}");
            }
            else
            {
                Console.WriteLine("");
            }
        }

        static Unit.UnitType GetFrom(int conversionType)
        {
            switch (conversionType)
            {
                case 1:
                    return Unit.UnitType.Yard;
                case 2:
                // return new Temperature();
                case 3:
                // return new Volume();
                case 4:
                // return new Weight();
                default:
                    return Unit.UnitType.Undefined;
            }
        }
    }
}