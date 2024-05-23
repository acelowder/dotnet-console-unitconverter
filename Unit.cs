using System;

namespace UnitConverter
{
    public abstract class Unit
    {
        public enum UnitType
        {
            Undefined,
            Millimeter,
            Centimeter,
            Meter,
            Kilometer,
            Foot,
            Yard,
            Mile,
            Fahrenheit,
            Celsius,
            Kelvin
        }

        public double Value { get; set; }
        public UnitType Type { get; protected set; }

        public override string ToString()
        {
            return Value == 1 ? $"{Value} {Type.ToString().ToLower()}" : $"{Value} {Pluralize(Type)}";
        }

        public static string Pluralize(Unit.UnitType unit)
        {
            switch (unit)
            {
                case Unit.UnitType.Millimeter:
                    return "millimeters";
                case Unit.UnitType.Centimeter:
                    return "centimeters";
                case Unit.UnitType.Meter:
                    return "meters";
                case Unit.UnitType.Kilometer:
                    return "kilometers";
                case Unit.UnitType.Foot:
                    return "feet";
                case Unit.UnitType.Yard:
                    return "yards";
                case Unit.UnitType.Mile:
                    return "miles";
                case Unit.UnitType.Fahrenheit:
                    return "fahrenheit";
                case Unit.UnitType.Celsius:
                    return "celsius";
                case Unit.UnitType.Kelvin:
                    return "kelvin";
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }

        protected abstract void ConvertToMetric();
        protected abstract void ConvertToImperial();
    }
}