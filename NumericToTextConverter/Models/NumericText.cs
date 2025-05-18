using System.Text;
using NumericToTextConverter.Models.Constants;
using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models;

public class NumericText
{
    public NumericText(string numberString)
    {
        if (numberString.StartsWith(NumericTextConstants.NegativeSymbol))
        {
            Negative = true;
            numberString = numberString.Replace(NumericTextConstants.NegativeSymbol, string.Empty);
        }
        
        if (numberString.Contains(NumericTextConstants.DecimalSeparator))
        {
            string[] decimalSplit = numberString.Split(NumericTextConstants.DecimalSeparator);
            string wholeNumberString = decimalSplit[0];
            string decimalString = decimalSplit[1];

            //0.1 is 0.10, need to add the zero
            if (decimalString.Length == 1)
            {
                decimalString += "0";
            }
                
            AddWholeGroups(parseTextToHundredGroups(wholeNumberString));
            AddDecimalGroups(parseTextToHundredGroups(decimalString));
        }
        else
        {
            AddWholeGroups(parseTextToHundredGroups(numberString));
        }
    }

    protected bool Negative = false;
    
    protected SortedList<int, HundredGroup> WholeGroups = new SortedList<int, HundredGroup>();
    protected SortedList<int, HundredGroup> DecimalGroups = new SortedList<int, HundredGroup>();

    private void AddWholeGroups(List<HundredGroup> wholeGroups)
    {
        foreach (HundredGroup wholeGroup in wholeGroups)
        {
            AddWholeGroup(wholeGroup);
        }
    }
    
    private void AddWholeGroup(HundredGroup hundredGroup)
    {
        WholeGroups.Add(hundredGroup.GetThousand(), hundredGroup);
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
        DecimalGroups.Add(hundredGroup.GetThousand(), hundredGroup);
    }

    protected String GetHundredGroupsText(IList<HundredGroup> hundredGroups)
    {
        List<string> hundredGroupList = new List<string>();
        foreach (HundredGroup hundredGroup in hundredGroups)
        {
            string hundredGroupText = hundredGroup.GetGroupText();
            if (!string.IsNullOrEmpty(hundredGroupText)
                && !(hundredGroupText.Equals(nameof(OnesNames.ZERO)) && hundredGroups.Count > 1)
               )
            {
                hundredGroupList.Add(hundredGroupText);
            }
        }
        
        hundredGroupList.Reverse();
        return string.Join(NumericTextConstants.CommaWithSpace, hundredGroupList);
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

    public virtual string GetText()
    {
        StringBuilder builder = new StringBuilder();
        if (Negative)
        {
            builder.Append(NumericTextConstants.Negative);
            builder.Append(NumericTextConstants.Space);
        }
        
        if (WholeGroups.Count > 0)
        {
            builder.Append(GetHundredGroupsText(WholeGroups.Values));
        }

        if (DecimalGroups.Count > 0)
        {
            if (WholeGroups.Count > 0)
            {
                builder.Append(NumericTextConstants.Space);
            }
            
            builder.Append(NumericTextConstants.Decimal);
            builder.Append(NumericTextConstants.Space);
            
            builder.Append(GetHundredGroupsText(DecimalGroups.Values));
        }
        return builder.ToString();
    }
}