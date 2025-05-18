using System.Text;
using NumericToTextConverter.Models.Constants;
using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models;

public class HundredGroup
{
    public HundredGroup(string number, int thousand)
    {
        List<string> numberList = number.Split("").ToList();
        numberList.Reverse();
        One = int.Parse(numberList[NumericTextConstants.OnePos]);
        Ten = numberList.Count > NumericTextConstants.TenPos ? int.Parse(numberList[NumericTextConstants.TenPos]) : 0;
        Hundred = numberList.Count > NumericTextConstants.HundredPos
            ? int.Parse(numberList[NumericTextConstants.HundredPos])
            : 0;
        Thousand = thousand;
    }

    private int One {get; set;}
    private int Ten {get; set;}
    private int Hundred {get; set;}
    private int Thousand {get; set;}

    public string GetOneName()
    {
        string name = string.Empty;
        if (One == (int) OnesNames.ZERO && (Ten > (int) TensNames.ZERO || Hundred > (int) HundredsNames.ZERO))
        {
            return name;
        }
        else if (Ten == (int) TensNames.TEN)
        {
            //the compiler says the .ToString() calls are redundant but it errors if they are removed
            int tenAndOne = int.Parse(Ten.ToString() + One.ToString());
            return NumericTextConstants.Ones.TryGetValue(tenAndOne, out name) ? name : string.Empty;
        }
        else
        {
            return NumericTextConstants.Ones.TryGetValue(One, out name) ? name : string.Empty;
        }
    }

    public string GetTenName()
    {
        string name = string.Empty;
        if (Ten >= (int) TensNames.TWENTY)
        {
            return NumericTextConstants.Tens.TryGetValue(Ten, out name) 
                ? name + NumericTextConstants.Hyphen : string.Empty;
        }
        else
        {
            return NumericTextConstants.Tens.TryGetValue(Ten, out name) ? name : string.Empty;
        }
    }

    public string GetHundredName()
    {
        string name = string.Empty;
        return NumericTextConstants.Hundreds.TryGetValue(Hundred, out name) ? name : string.Empty;;
    }

    public string GetThousandName()
    {
        string name = string.Empty;
        return NumericTextConstants.Thousands.TryGetValue(Thousand, out name) ? name : string.Empty;
    }

    public string GetGroupName()
    {
        StringBuilder builder = new StringBuilder();
        if (!string.IsNullOrEmpty(GetHundredName()))
        {
            builder.Append(GetHundredName());
            builder.Append(NumericTextConstants.Space);
            builder.Append(NumericTextConstants.Hundred);
            if (!string.IsNullOrEmpty(GetTenName()) || !string.IsNullOrEmpty(GetOneName()))
            {
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

        if (string.IsNullOrEmpty(GetThousandName()))
        {
            builder.Append(NumericTextConstants.Space);
            builder.Append(GetThousandName());
        }
        return builder.ToString();
    }
}