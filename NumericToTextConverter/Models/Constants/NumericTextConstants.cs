using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models.Constants;

public static class NumericTextConstants
{
    public static readonly int GroupSize = 3;
    public static readonly string And = "AND";
    public static readonly string Comma = ",";
    public static readonly string Hyphen = "-";
    public static readonly Dictionary<int, string> Hundreds = new Dictionary<int, string>
    {
        { 1, nameof(HundredsNames.HUNDRED) },
        { 2, nameof(HundredsNames.THOUSAND) },
        { 3, nameof(HundredsNames.MILLION) },
        { 4, nameof(HundredsNames.BILLION) },
        { 5, nameof(HundredsNames.TRILLION) },
        { 6, nameof(HundredsNames.QUADRILLION) },
        { 7, nameof(HundredsNames.QUINTILLION) },
        { 8, nameof(HundredsNames.SEXTILLION) }
    };

    public static readonly Dictionary<int, string> Tens = new Dictionary<int, string>
    {
        { 1, nameof(TensNames.TEN) },
        { 2, nameof(TensNames.TWENTY) },
        { 3, nameof(TensNames.THIRTY) },
        { 4, nameof(TensNames.FORTY) },
        { 5, nameof(TensNames.FIFTY) },
        { 6, nameof(TensNames.SIXTY) },
        { 7, nameof(TensNames.SEVENTY) },
        { 8, nameof(TensNames.EIGHTY) },
        { 9, nameof(TensNames.NINETY) }
    };
    
    public static readonly Dictionary<int, string> Ones = new Dictionary<int, string>
    {
        { 0, nameof(OnesNames.ZERO) },
        { 1, nameof(OnesNames.ONE) },
        { 2, nameof(OnesNames.TWO) },
        { 3, nameof(OnesNames.THREE) },
        { 4, nameof(OnesNames.FOUR) },
        { 5, nameof(OnesNames.FIVE) },
        { 6, nameof(OnesNames.SIX) },
        { 7, nameof(OnesNames.SEVEN) },
        { 8, nameof(OnesNames.EIGHT) },
        { 9, nameof(OnesNames.NINE) },
        { 10, nameof(OnesNames.TEN) },
        { 11, nameof(OnesNames.ELEVEN) },
        { 12, nameof(OnesNames.TWELVE) },
        { 13, nameof(OnesNames.THIRTEEN) },
        { 14, nameof(OnesNames.FOURTEEN) },
        { 15, nameof(OnesNames.FIFTEEN) },
        { 16, nameof(OnesNames.SIXTEEN) },
        { 17, nameof(OnesNames.SEVENTEEN) },
        { 18, nameof(OnesNames.EIGHTEEN) },
        { 19, nameof(OnesNames.NINETEEN) }
    };
}