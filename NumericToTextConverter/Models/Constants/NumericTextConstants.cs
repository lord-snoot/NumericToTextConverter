using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models.Constants;

public static class NumericTextConstants
{
    public static readonly int OnePos = 0;
    public static readonly int TenPos = 1;
    public static readonly int HundredPos = 2;
    public static readonly int GroupSize = 3;
    public static readonly int MaxDecimals = 2;
    
    public static readonly string DecimalSeparator = ".";
    public static readonly string NegativeSymbol = "-";
    
    public static readonly string And = "AND";
    public static readonly string Decimal = "POINT";
    public static readonly string Hundred = "HUNDRED";
    public static readonly string Negative = "NEGATIVE";
    public static readonly string CommaWithSpace = ", ";
    public static readonly string Hyphen = "-";
    public static readonly string Space = " ";
    
    public static readonly Dictionary<int, string> Thousands = new Dictionary<int, string>
    {
        { (int) ThousandsNames.ZERO, string.Empty },
        { (int) ThousandsNames.THOUSAND, nameof(ThousandsNames.THOUSAND) },
        { (int) ThousandsNames.MILLION, nameof(ThousandsNames.MILLION) },
        { (int) ThousandsNames.BILLION, nameof(ThousandsNames.BILLION) },
        { (int) ThousandsNames.TRILLION, nameof(ThousandsNames.TRILLION) },
        { (int) ThousandsNames.QUADRILLION, nameof(ThousandsNames.QUADRILLION) },
        { (int) ThousandsNames.QUINTILLION, nameof(ThousandsNames.QUINTILLION) },
        { (int) ThousandsNames.SEXTILLION, nameof(ThousandsNames.SEXTILLION) },
        { (int) ThousandsNames.SEPTILLION, nameof(ThousandsNames.SEPTILLION) },
        { (int) ThousandsNames.OCTILLION, nameof(ThousandsNames.OCTILLION) }
        
    };

    public static readonly Dictionary<int, string> Hundreds = new Dictionary<int, string>
    {
        { (int) HundredsNames.ZERO, string.Empty },
        { (int) HundredsNames.ONE, nameof(HundredsNames.ONE) },
        { (int) HundredsNames.TWO, nameof(HundredsNames.TWO) },
        { (int) HundredsNames.THREE, nameof(HundredsNames.THREE) },
        { (int) HundredsNames.FOUR, nameof(HundredsNames.FOUR) },
        { (int) HundredsNames.FIVE, nameof(HundredsNames.FIVE) },
        { (int) HundredsNames.SIX, nameof(HundredsNames.SIX) },
        { (int) HundredsNames.SEVEN, nameof(HundredsNames.SEVEN) },
        { (int) HundredsNames.EIGHT, nameof(HundredsNames.EIGHT) },
        { (int) HundredsNames.NINE, nameof(HundredsNames.NINE) }
    };

    public static readonly Dictionary<int, string> Tens = new Dictionary<int, string>
    {
        { (int) TensNames.ZERO, string.Empty },
        { (int) TensNames.TEN, nameof(TensNames.TEN) },
        { (int) TensNames.TWENTY, nameof(TensNames.TWENTY) },
        { (int) TensNames.THIRTY, nameof(TensNames.THIRTY) },
        { (int) TensNames.FORTY, nameof(TensNames.FORTY) },
        { (int) TensNames.FIFTY, nameof(TensNames.FIFTY) },
        { (int) TensNames.SIXTY, nameof(TensNames.SIXTY) },
        { (int) TensNames.SEVENTY, nameof(TensNames.SEVENTY) },
        { (int) TensNames.EIGHTY, nameof(TensNames.EIGHTY) },
        { (int) TensNames.NINETY, nameof(TensNames.NINETY) }
    };
    
    public static readonly Dictionary<int, string> Ones = new Dictionary<int, string>
    {
        { (int) OnesNames.ZERO, nameof(OnesNames.ZERO) },
        { (int) OnesNames.ONE, nameof(OnesNames.ONE) },
        { (int) OnesNames.TWO, nameof(OnesNames.TWO) },
        { (int) OnesNames.THREE, nameof(OnesNames.THREE) },
        { (int) OnesNames.FOUR, nameof(OnesNames.FOUR) },
        { (int) OnesNames.FIVE, nameof(OnesNames.FIVE) },
        { (int) OnesNames.SIX, nameof(OnesNames.SIX) },
        { (int) OnesNames.SEVEN, nameof(OnesNames.SEVEN) },
        { (int) OnesNames.EIGHT, nameof(OnesNames.EIGHT) },
        { (int) OnesNames.NINE, nameof(OnesNames.NINE) },
        { (int) OnesNames.TEN, nameof(OnesNames.TEN) },
        { (int) OnesNames.ELEVEN, nameof(OnesNames.ELEVEN) },
        { (int) OnesNames.TWELVE, nameof(OnesNames.TWELVE) },
        { (int) OnesNames.THIRTEEN, nameof(OnesNames.THIRTEEN) },
        { (int) OnesNames.FOURTEEN, nameof(OnesNames.FOURTEEN) },
        { (int) OnesNames.FIFTEEN, nameof(OnesNames.FIFTEEN) },
        { (int) OnesNames.SIXTEEN, nameof(OnesNames.SIXTEEN) },
        { (int) OnesNames.SEVENTEEN, nameof(OnesNames.SEVENTEEN) },
        { (int) OnesNames.EIGHTEEN, nameof(OnesNames.EIGHTEEN) },
        { (int) OnesNames.NINETEEN, nameof(OnesNames.NINETEEN) }
    };
}