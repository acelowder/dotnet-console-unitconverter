using System;

namespace UnitConverter
{
    public class Temperature : Unit
    {
        UnitType[] temperatureUnits = {
            UnitType.Celsius,
            UnitType.Fahrenheit,
            UnitType.Kelvin
        };

        public Temperature(double value, UnitType type)
        {
            if (!temperatureUnits.Contains(type)) throw new ArgumentException("Invalid unit type");

            Type = type;
            Value = value;
        }

        public void ConvertTo(UnitType type)
        {
            UnitType from = Type;
            UnitType to = type;

            switch (from)
            {
                case UnitType.Celsius:
                    switch (to)
                    {
                        case UnitType.Celsius:
                            break;
                        case UnitType.Fahrenheit:
                            Type = UnitType.Fahrenheit;
                            Value = (Value * 9 / 5) + 32;
                            break;
                        case UnitType.Kelvin:
                            Type = UnitType.Kelvin;
                            Value += 273.15;
                            break;
                    }
                    break;
                case UnitType.Fahrenheit:
                    switch (to)
                    {
                        case UnitType.Celsius:
                            Type = UnitType.Celsius;
                            Value = (Value - 32) * 5 / 9;
                            break;
                        case UnitType.Fahrenheit:
                            break;
                        case UnitType.Kelvin:
                            Type = UnitType.Kelvin;
                            Value = (Value + 459.67) * 5 / 9;
                            break;
                    }
                    break;
                case UnitType.Kelvin:
                    switch (to)
                    {
                        case UnitType.Celsius:
                            Type = UnitType.Celsius;
                            Value -= 273.15;
                            break;
                        case UnitType.Fahrenheit:
                            Type = UnitType.Fahrenheit;
                            Value = (Value - 273.15) * 9 / 5 + 32;
                            break;
                        case UnitType.Kelvin:
                            break;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }

        protected override void ConvertToMetric()
        {
            throw new NotImplementedException();
        }

        protected override void ConvertToImperial()
        {
            throw new NotImplementedException();
        }
    }
}