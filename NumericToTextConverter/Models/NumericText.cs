using System.Text;
using NumericToTextConverter.Models.Constants;
using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models;

public class NumericText
{
    public NumericText(string numberString)
    {
        if (numberString.Contains(NumericTextConstants.DecimalSeparator))
        {
            string[] decimalSplit = numberString.Split(NumericTextConstants.DecimalSeparator);
            string wholeNumberString = decimalSplit[0];
            string decimalString = decimalSplit[1];
                
            AddWholeGroups(parseTextToHundredGroups(wholeNumberString));
            AddDecimalGroups(parseTextToHundredGroups(decimalString));
        }
        else
        {
            AddWholeGroups(parseTextToHundredGroups(numberString));
        }
    }
    
    private SortedList<int, HundredGroup> _wholeGroups = new SortedList<int, HundredGroup>();
    private SortedList<int, HundredGroup> _decimalGroups = new SortedList<int, HundredGroup>();

    private void AddWholeGroups(List<HundredGroup> wholeGroups)
    {
        foreach (HundredGroup wholeGroup in wholeGroups)
        {
            AddWholeGroup(wholeGroup);
        }
    }
    
    private void AddWholeGroup(HundredGroup hundredGroup)
    {
        _wholeGroups.Add(hundredGroup.GetThousand(), hundredGroup);
    }

    private void AddDecimalGroups(List<HundredGroup> decimalGroups)
    {
        foreach (HundredGroup decimalGroup in decimalGroups)
        {
            AddDecimalGroup(decimalGroup);
        }
    }
    
    private void AddDecimalGroup(HundredGroup hundredGroup)
    {
        _decimalGroups.Add(hundredGroup.GetThousand(), hundredGroup);
    }

    private String GetWholeGroupsText()
    {
        List<string> wholeGroupText = new List<string>();
        foreach (HundredGroup wholeGroup in _wholeGroups.Values)
        {
            wholeGroupText.Add(wholeGroup.GetGroupText());
        }
        
        wholeGroupText.Reverse();
        return string.Join(NumericTextConstants.Comma, wholeGroupText);
    }

    private String GetDecimalGroupsText()
    {
        List<string> decimalGroupText = new List<string>();
        foreach (HundredGroup decimalGroup in _decimalGroups.Values)
        {
            decimalGroupText.Add(decimalGroup.GetGroupText());
        }
        
        decimalGroupText.Reverse();
        return string.Join(NumericTextConstants.Comma, decimalGroupText);
    }
    
    private List<HundredGroup> parseTextToHundredGroups(string input)
    {
        List<HundredGroup> hundredGroups = new List<HundredGroup>();
        int thousandCount = (int) ThousandsNames.ZERO;
        for (int i = input.Length; i > 0; i-= NumericTextConstants.GroupSize)
        {
            string groupString;
            if (i > NumericTextConstants.GroupSize)
            {
                groupString = input.Substring(
                        i - NumericTextConstants.GroupSize, 
                        NumericTextConstants.GroupSize)
                    ;
            }
            else
            {
                groupString = input.Substring(0, i);
            }
            
            HundredGroup hundredGroup = new HundredGroup(groupString, thousandCount);
            hundredGroups.Add(hundredGroup);
            thousandCount++;
        }

        hundredGroups.Reverse();
        
        return hundredGroups;
    }

    public string GetText()
    {
        StringBuilder builder = new StringBuilder();
        if (_wholeGroups.Count > 0)
        {
            builder.Append(GetWholeGroupsText());
        }

        if (_decimalGroups.Count > 0)
        {
            if (_wholeGroups.Count > 0)
            {
                builder.Append(NumericTextConstants.Space);
            }
            
            builder.Append(NumericTextConstants.Decimal);
            builder.Append(NumericTextConstants.Space);
            
            builder.Append(GetDecimalGroupsText());
        }
        return builder.ToString();
    }
}