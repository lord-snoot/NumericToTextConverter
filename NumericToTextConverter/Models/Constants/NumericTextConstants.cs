using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models.Constants;

public static class NumericTextConstants
{
    private static readonly Dictionary<int, string> Hundreds = new Dictionary<int, string>
    {
        { 1, "HUNDRED" },
        { 2, "THOUSAND" },
        { 3, "MILLION" },
        { 4, "BILLION" },
        { 5, "TRILLION" },
        { 6, "QUADRILLION" },
        { 7, "QUINTILLION" },
        { 8, "SEXTILLION" },
    };

    private static readonly Dictionary<int, string> Tens = new Dictionary<int, string>
    {
        { 1, "TEN"},
        { 2, "TWENTY"},
        { 3, "THIRTY"},
        { 4, "FORTY"},
        { 5, "FIFTY"},
        { 6, "SIXTY"},
        { 7, "SEVENTY"},
        { 8, "EIGHTY"},
        { 9, "NINETY"},
    };
    
    private static readonly Dictionary<int, string> Ones = new Dictionary<int, string>
    {
        { 0, "ZERO"},
        { 1, "ONE" },
        { 2, "TWO" },
        { 3, "THREE" },
        { 4, "FOUR" },
        { 5, "FIVE" },
        { 6, "SIX" },
        { 7, "SEVEN" },
        { 8, "EIGHT" },
        { 9, "NINE" },
        { 10, "TEN" },
        { 11, "ELEVEN" },
        { 12, "TWELVE" },
        { 13, "THIRTEEN" },
        { 14, "FOURTEEN" },
        { 15, "FIFTEEN" },
        { 16, "SIXTEEN" },
        { 17, "SEVENTEEN" },
        { 18, "EIGHTEEN" },
        { 19, "NINTEEN" }
    };
}