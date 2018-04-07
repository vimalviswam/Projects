using System;

namespace ResistorValueCalculator
{
    public class ResistorValueCalculator : IResistorValueCalculator
    {
        public int CalculateResistorValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int ohm;

            if (Enum.IsDefined(typeof(BandAColors), bandAColor) &&
                Enum.IsDefined(typeof(BandBColors), bandBColor) &&
                Enum.IsDefined(typeof(BandCColors), bandCColor) &&
                Enum.IsDefined(typeof(BandDColors), bandDColor))
            {
                int Digit1 = (int)Enum.Parse(typeof(BandAColors), bandAColor) +1;                
                int Digit2 = (int)Enum.Parse(typeof(BandBColors), bandBColor);
                double Multiplier = ResistorColorCode.Multiplier[(BandCColors)Enum.Parse(typeof(BandCColors), bandCColor)];
                ohm = Convert.ToInt32(int.Parse(Digit1.ToString() + Digit2.ToString()) * Multiplier);
            }
            else
                throw new System.ArgumentException("One of the color code provided is invalid.");

            return ohm;            
        }

        public double GetTolerance(string bandDColor)
        {
            return ResistorColorCode.Tolerance[(BandDColors)Enum.Parse(typeof(BandDColors), bandDColor)];
        }
        
    }
}
