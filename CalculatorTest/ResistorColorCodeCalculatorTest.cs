using ResistorValueCalculator;
using NUnit.Framework;

namespace ResistorColorCodeCalculatorTest
{ 
    [TestFixture]
    public class ResistorColorCodeCalculatorTest
    {
        ResistorValueCalculator.ResistorValueCalculator calc;

        [SetUp]
        public void Initialize()
        {
            calc = new ResistorValueCalculator.ResistorValueCalculator();
        }        

        [TestCase("Red","Orange","Yellow","Green", 230000)]
        [TestCase("Orange", "Red", "Yellow", "Green", 320000)]      

        public void CalculateResistorValue_valid_color(string bandAColor, string bandBColor, string bandCColor, string bandDColor,int expectedOhm)
        {            
            int actualOhm=calc.CalculateResistorValue(bandAColor, bandBColor,bandCColor, bandDColor);
            Assert.AreEqual(expectedOhm, actualOhm);
        }

        [TestCase(2, 3, 4, 5 , 330000)]
        [TestCase(3, 4, 3, 5, 44000)]
        [TestCase(4, 5, 2, 5, 5500)]
        [TestCase(5, 6, 1, 5, 660)]    

        public void CalculateResistorValue_valid_enuminput(BandAColors bandAColor, BandBColors bandBColor, BandCColors bandCColor, BandDColors bandDColor, int expectedOhm)
        {
            int actualOhm = calc.CalculateResistorValue(bandAColor.ToString(), bandBColor.ToString(), bandCColor.ToString(), bandDColor.ToString());            
            Assert.AreEqual(expectedOhm, actualOhm);
        }

        [TestCase(1006, 41, 42, 45, 10)]
        public void CalculateOhmValue_invalidColorCode_ThrowsException(BandAColors bandAColor, BandBColors bandBColor, BandCColors bandCColor, BandDColors bandDColor, int expectedOhm)
        {
            var ex = Assert.Throws<System.ArgumentException>(() => calc.CalculateResistorValue(bandAColor.ToString(), bandBColor.ToString(), bandCColor.ToString(), bandDColor.ToString()));

        }
    }
}
