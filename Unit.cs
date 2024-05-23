using System;

namespace UnitConverter
{
    public abstract class Unit
    {
        public enum UnitSystem
        {
            Metric,
            Imperial
        }

        public enum UnitType
        {
            Undefined,
            Meter,
            Kilometer,
            Foot,
            Yard,
            Mile
        }

        public double Value { get; set; }
        public UnitType Type { get; protected set; }
        public UnitSystem System { get; protected set; }

        public override string ToString() => $"{Value} {Pluralize(Type)}";
        public static string Pluralize(Unit.UnitType unit)
        {
            switch (unit)
            {
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
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }

        protected abstract UnitSystem DetermineSystem();
        protected abstract void ConvertToMetric();
        protected abstract void ConvertToImperial();
    }
}