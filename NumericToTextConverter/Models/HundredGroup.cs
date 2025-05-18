using System.Text;
using NumericToTextConverter.Models.Constants;
using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models;

public class HundredGroup
{
    public HundredGroup(string numberText, int thousand)
    {
        int textEnd = numberText.Length - 1;
        One = int.Parse(numberText.Substring(textEnd, 1));
        Ten = numberText.Length > NumericTextConstants.TenPos 
            ? int.Parse(numberText.Substring(textEnd - NumericTextConstants.TenPos, 1)) : 0;
        Hundred = numberText.Length > NumericTextConstants.HundredPos
            ? int.Parse(numberText.Substring(textEnd - NumericTextConstants.HundredPos, 1)) : 0;
        
        Thousand = thousand;
    }

    private int One {get; set;}
    private int Ten {get; set;}
    private int Hundred {get; set;}
    private int Thousand {get; set;}

    public string GetOneName()
    {
        if (One == (int) OnesNames.ZERO && (Ten > (int) TensNames.ZERO || Hundred > (int) HundredsNames.ZERO))
        {
            return string.Empty;
        }
        else if (Ten == (int) TensNames.TEN)
        {
            //the compiler says the .ToString() calls are redundant but it errors if they are removed
            int tenAndOne = int.Parse(Ten.ToString() + One.ToString());
            return NumericTextConstants.Ones.TryGetValue(tenAndOne, out string? name) ? name : string.Empty;
        }
        else if (NumericTextConstants.Ones.TryGetValue(One, out string? name))
        {
            if (Ten >= (int) TensNames.TWENTY)
            {
                return NumericTextConstants.Hyphen + name;
            }
            else
            {
                return name;
            }
        }
        else
        {
            return string.Empty;
        }
    }

    public string GetTenName()
    {
        if (Ten >= (int) TensNames.TWENTY)
        {
            return NumericTextConstants.Tens.TryGetValue(Ten, out string? name) 
                ? name : string.Empty;
        }
        else if (Ten == (int) TensNames.TEN && One > (int) OnesNames.ZERO)
        {
            return string.Empty;
        }
        {
            return NumericTextConstants.Tens.TryGetValue(Ten, out string? name) ? name : string.Empty;
        }
    }

    public string GetHundredName()
    {
        return NumericTextConstants.Hundreds.TryGetValue(Hundred, out string? name) ? name : string.Empty;;
    }

    public string GetThousandName()
    {
        return NumericTextConstants.Thousands.TryGetValue(Thousand, out string? name) ? name : string.Empty;
    }

    public int GetThousand()
    {
        return Thousand;
    }

    public string GetGroupText()
    {
        StringBuilder builder = new StringBuilder();
        if (!string.IsNullOrEmpty(GetHundredName()))
        {
            builder.Append(GetHundredName());
            builder.Append(NumericTextConstants.Space);
            builder.Append(NumericTextConstants.Hundred);
            if (!string.IsNullOrEmpty(GetTenName()) || !string.IsNullOrEmpty(GetOneName()))
            {
                builder.Append(NumericTextConstants.Space);
                builder.Append(NumericTextConstants.And);
                builder.Append(NumericTextConstants.Space);
            }
        }

        if (!string.IsNullOrEmpty(GetTenName()))
        {
            builder.Append(GetTenName());
        }

        if (!string.IsNullOrEmpty(GetOneName()))
        {
            builder.Append(GetOneName());
        }

        if (!string.IsNullOrEmpty(GetThousandName()))
        {
            builder.Append(NumericTextConstants.Space);
            builder.Append(GetThousandName());
        }
        return builder.ToString();
    }
}