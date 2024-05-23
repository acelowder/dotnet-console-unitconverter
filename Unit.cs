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
        
        protected abstract UnitSystem DetermineSystem();
        protected abstract void ConvertToMetric();
        protected abstract void ConvertToImperial();
    }
}