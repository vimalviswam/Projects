using System.Collections.Generic;

namespace ResistorValueCalculator
{

    public static class ResistorColorCode
    {    
        public static Dictionary<BandCColors, double> Multiplier;
        public static Dictionary<BandDColors, double> Tolerance;

        static ResistorColorCode()
        {
            Multiplier = new Dictionary<BandCColors, double>();

            Multiplier.Add(BandCColors.Black, 1);
            Multiplier.Add(BandCColors.Brown, 10);
            Multiplier.Add(BandCColors.Red, 100);
            Multiplier.Add(BandCColors.Orange, 1000);
            Multiplier.Add(BandCColors.Yellow, 10000);
            Multiplier.Add(BandCColors.Blue, 100000);
            Multiplier.Add(BandCColors.Violet, 1000000);
            Multiplier.Add(BandCColors.Gray, 10000000);
            Multiplier.Add(BandCColors.White, 100000000);
            Multiplier.Add(BandCColors.Gold, .1);
            Multiplier.Add(BandCColors.Silver, .01);

            Tolerance = new Dictionary<BandDColors, double>();

            Tolerance.Add(BandDColors.Brown, 1);
            Tolerance.Add(BandDColors.Red, 2);
            Tolerance.Add(BandDColors.Green, .5);
            Tolerance.Add(BandDColors.Blue, .25);
            Tolerance.Add(BandDColors.Violet, .1);
            Tolerance.Add(BandDColors.Gray, .05);
            Tolerance.Add(BandDColors.Gold, 5);
            Tolerance.Add(BandDColors.Silver, 10);
        }        
         
    }   

    public enum BandAColors
    {        
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Gray,
        White
    }

    public enum BandBColors
    {
        Black,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Gray,
        White
    }

    public enum BandCColors
    {
        Black,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Gray,
        White,
        Gold,
        Silver
    }

    public enum BandDColors
    {
        Brown,
        Red,
        Green,
        Blue,
        Violet,
        Gray,
        Gold,        
        Silver
    }
}
