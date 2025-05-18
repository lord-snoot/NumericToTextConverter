
using NumericToTextConverter.Service;

namespace NumericToTextConverterTests.Service;

public class ConverterServiceTests
{
    ConverterService _converterService;
    
    [SetUp]
    public void Setup()
    {
        _converterService = new ConverterService();
    }
    
    //Invalid inputs
    [TestCase("", ExpectedResult = "Please provide a number with up to two decimals.")]
    [TestCase("invalid text", ExpectedResult = "Invalid number: invalid text. Please provide a number with up to two decimals.")]
    [TestCase("1.111", ExpectedResult = "Invalid number: 1.111. Number can not have more than two decimals.")]
    
    //Singular vs Plural
    [TestCase("1.1", ExpectedResult = "ONE DOLLAR AND ONE CENT")]
    [TestCase("2.1", ExpectedResult = "TWO DOLLARS AND ONE CENT")]
    [TestCase("2.2", ExpectedResult = "TWO DOLLARS AND TWO CENTS")]
    
    //Test all OnesNames
    [TestCase("0", ExpectedResult = "ZERO DOLLARS")]
    [TestCase("1", ExpectedResult = "ONE DOLLAR")]
    [TestCase("2", ExpectedResult = "TWO DOLLARS")]
    [TestCase("3", ExpectedResult = "THREE DOLLARS")]
    [TestCase("4", ExpectedResult = "FOUR DOLLARS")]
    [TestCase("5", ExpectedResult = "FIVE DOLLARS")]
    [TestCase("6", ExpectedResult = "SIX DOLLARS")]
    [TestCase("7", ExpectedResult = "SEVEN DOLLARS")]
    [TestCase("8", ExpectedResult = "EIGHT DOLLARS")]
    [TestCase("9", ExpectedResult = "NINE DOLLARS")]
    [TestCase("10", ExpectedResult = "TEN DOLLARS")]
    [TestCase("11", ExpectedResult = "ELEVEN DOLLARS")]
    [TestCase("12", ExpectedResult = "TWELVE DOLLARS")]
    [TestCase("13", ExpectedResult = "THIRTEEN DOLLARS")]
    [TestCase("14", ExpectedResult = "FOURTEEN DOLLARS")]
    [TestCase("15", ExpectedResult = "FIFTEEN DOLLARS")]
    [TestCase("16", ExpectedResult = "SIXTEEN DOLLARS")]
    [TestCase("17", ExpectedResult = "SEVENTEEN DOLLARS")]
    [TestCase("18", ExpectedResult = "EIGHTEEN DOLLARS")]
    [TestCase("19", ExpectedResult = "NINETEEN DOLLARS")]
    
    //Test all TensNames
    [TestCase("10", ExpectedResult = "TEN DOLLARS")]
    [TestCase("20", ExpectedResult = "TWENTY DOLLARS")]
    [TestCase("30", ExpectedResult = "THIRTY DOLLARS")]
    [TestCase("40", ExpectedResult = "FORTY DOLLARS")]
    [TestCase("50", ExpectedResult = "FIFTY DOLLARS")]
    [TestCase("60", ExpectedResult = "SIXTY DOLLARS")]
    [TestCase("70", ExpectedResult = "SEVENTY DOLLARS")]
    [TestCase("80", ExpectedResult = "EIGHTY DOLLARS")]
    [TestCase("90", ExpectedResult = "NINETY DOLLARS")]
    
    //Test hyphenation
    [TestCase("25", ExpectedResult = "TWENTY-FIVE DOLLARS")]
    
    //Test all HundredsNames
    [TestCase("100", ExpectedResult = "ONE HUNDRED DOLLARS")]
    [TestCase("200", ExpectedResult = "TWO HUNDRED DOLLARS")]
    [TestCase("300", ExpectedResult = "THREE HUNDRED DOLLARS")]
    [TestCase("400", ExpectedResult = "FOUR HUNDRED DOLLARS")]
    [TestCase("500", ExpectedResult = "FIVE HUNDRED DOLLARS")]
    [TestCase("600", ExpectedResult = "SIX HUNDRED DOLLARS")]
    [TestCase("700", ExpectedResult = "SEVEN HUNDRED DOLLARS")]
    [TestCase("800", ExpectedResult = "EIGHT HUNDRED DOLLARS")]
    [TestCase("900", ExpectedResult = "NINE HUNDRED DOLLARS")]
    
    //Test all ThousandsNames
    [TestCase("1000", ExpectedResult = "ONE THOUSAND DOLLARS")]
    [TestCase("1000000", ExpectedResult = "ONE MILLION DOLLARS")]
    [TestCase("1000000000", ExpectedResult = "ONE BILLION DOLLARS")]
    [TestCase("1000000000000", ExpectedResult = "ONE TRILLION DOLLARS")]
    [TestCase("1000000000000000", ExpectedResult = "ONE QUADRILLION DOLLARS")]
    [TestCase("1000000000000000000", ExpectedResult = "ONE QUINTILLION DOLLARS")]
    [TestCase("1000000000000000000000", ExpectedResult = "ONE SEXTILLION DOLLARS")]
    [TestCase("1000000000000000000000000", ExpectedResult = "ONE SEPTILLION DOLLARS")]
    [TestCase("1000000000000000000000000000", ExpectedResult = "ONE OCTILLION DOLLARS")]
    
    public string TestConverterService(string input)
    {
        return _converterService.Convert(input);
    }
}