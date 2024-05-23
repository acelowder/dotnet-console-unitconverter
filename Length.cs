using System;

namespace UnitConverter
{
    public class Length : Unit
    {
        UnitType[] lengthUnits = {
            UnitType.Millimeter,
            UnitType.Centimeter,
            UnitType.Meter,
            UnitType.Kilometer,
            UnitType.Foot,
            UnitType.Yard,
            UnitType.Mile
        };

        public Length(double value, UnitType type)
        {
            if (!lengthUnits.Contains(type)) throw new ArgumentException("Invalid unit type");

            Type = type;
            Value = value;
        }

        public void ConvertTo(UnitType type)
        {
            switch (type)
            {
                case UnitType.Millimeter:
                    ConvertToMetric();
                    Type = UnitType.Millimeter;
                    Value *= 1000;
                    break;
                case UnitType.Centimeter:
                    ConvertToMetric();
                    Type = UnitType.Centimeter;
                    Value *= 100;
                    break;
                case UnitType.Meter:
                    ConvertToMetric();
                    break;
                case UnitType.Kilometer:
                    ConvertToMetric();
                    Type = UnitType.Kilometer;
                    Value /= 1000;
                    break;
                case UnitType.Foot:
                    ConvertToImperial();
                    break;
                case UnitType.Yard:
                    ConvertToImperial();
                    Type = UnitType.Yard;
                    Value /= 3;
                    break;
                case UnitType.Mile:
                    ConvertToImperial();
                    Type = UnitType.Mile;
                    Value /= 5280;
                    break;
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }

        protected override void ConvertToMetric()
        {
            switch (Type)
            {
                case UnitType.Millimeter:
                    Type = UnitType.Meter;
                    Value *= 0.001;
                    break;
                case UnitType.Centimeter:
                    Type = UnitType.Meter;
                    Value *= 0.01;
                    break;
                case UnitType.Meter:
                    break;
                case UnitType.Kilometer:
                    Type = UnitType.Meter;
                    Value *= 1000;
                    break;
                case UnitType.Foot:
                    Type = UnitType.Meter;
                    Value *= 0.3048;
                    break;
                case UnitType.Yard:
                    Type = UnitType.Meter;
                    Value *= 0.9144;
                    break;
                case UnitType.Mile:
                    Type = UnitType.Meter;
                    Value *= 1609.344;
                    break;
            }
        }

        protected override void ConvertToImperial()
        {
            switch (Type)
            {
                case UnitType.Millimeter:
                    Type = UnitType.Foot;
                    Value *= 0.00328084;
                    break;
                case UnitType.Centimeter:
                    Type = UnitType.Foot;
                    Value *= 0.0328084;
                    break;
                case UnitType.Meter:
                    Type = UnitType.Foot;
                    Value *= 3.28084;
                    break;
                case UnitType.Kilometer:
                    Type = UnitType.Foot;
                    Value *= 3280.84;
                    break;
                case UnitType.Foot:
                    break;
                case UnitType.Yard:
                    Type = UnitType.Foot;
                    Value *= 3;
                    break;
                case UnitType.Mile:
                    Type = UnitType.Foot;
                    Value *= 5280;
                    break;
            }
        }
    }
}