using System;

namespace UnitConverter
{
    public class Length : Unit
    {
        UnitType[] lengthUnits = { UnitType.Meter, UnitType.Kilometer, UnitType.Foot, UnitType.Yard, UnitType.Mile };

        public Length(double value, UnitType type)
        {
            if (!lengthUnits.Contains(type)) throw new ArgumentException("Invalid unit type");

            Type = type;
            Value = value;
            System = DetermineSystem();
        }

        public void ConvertTo(UnitType type)
        {
            switch (type)
            {
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
                    Type = UnitType.Foot;
                    Value /= 0.3048;
                    break;
                case UnitType.Yard:
                    ConvertToImperial();
                    Type = UnitType.Yard;
                    Value /= 0.9144;
                    break;
                case UnitType.Mile:
                    ConvertToImperial();
                    Type = UnitType.Mile;
                    Value /= 1609.344;
                    break;
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }

        protected override UnitSystem DetermineSystem()
        {
            switch (Type)
            {
                case UnitType.Meter:
                    return UnitSystem.Metric;
                case UnitType.Kilometer:
                    return UnitSystem.Metric;
                case UnitType.Foot:
                    return UnitSystem.Imperial;
                case UnitType.Yard:
                    return UnitSystem.Imperial;
                case UnitType.Mile:
                    return UnitSystem.Imperial;
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }

        protected override void ConvertToMetric()
        {
            switch (Type)
            {
                case UnitType.Meter:
                    break;
                case UnitType.Kilometer:
                    Type = UnitType.Meter;
                    Value *= 1000;
                    break;
                case UnitType.Foot:
                    Type = UnitType.Meter;
                    Value *= 0.3048;
                    System = UnitSystem.Metric;
                    break;
                case UnitType.Yard:
                    Type = UnitType.Meter;
                    Value *= 0.9144;
                    System = UnitSystem.Metric;
                    break;
                case UnitType.Mile:
                    Type = UnitType.Meter;
                    Value *= 1609.344;
                    System = UnitSystem.Metric;
                    break;
            }
        }

        protected override void ConvertToImperial()
        {
            switch (Type)
            {
                case UnitType.Meter:
                    Type = UnitType.Foot;
                    Value *= 3.28084;
                    System = UnitSystem.Imperial;
                    break;
                case UnitType.Kilometer:
                    Type = UnitType.Foot;
                    Value *= 3280.84;
                    System = UnitSystem.Imperial;
                    break;
                case UnitType.Foot:
                    break;
                case UnitType.Yard:
                    Type = UnitType.Foot;
                    Value *= 3;
                    System = UnitSystem.Imperial;
                    break;
                case UnitType.Mile:
                    Type = UnitType.Foot;
                    Value *= 5280;
                    System = UnitSystem.Imperial;
                    break;
            }
        }
    }
}