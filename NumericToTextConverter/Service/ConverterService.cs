using System.Text.Encodings.Web;
using NumericToTextConverter.Models;
using NumericToTextConverter.Models.Constants;
using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Service;

public class ConverterService : IConverterService
{
    public ConverterService()
    {
        
    }
    
    public string Convert(string input)
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

        List<string> inputGroups = new List<string>();
        hundredGroups.Reverse();
        foreach (HundredGroup hundredGroup in hundredGroups)
        {
            inputGroups.Add(hundredGroup.GetGroupName());
        }
        
        return string.Join(", ", inputGroups);
    }

    private string validate(string input)
    {
        string output = "";
        if (string.IsNullOrEmpty(input))
        {
            output = "Please enter a value.";
        } else if (decimal.TryParse(input, out _))
        {
            
        }
        else
        {
            output = "Invalid value, please enter a numeric value with up to two decimal places.";
        }
        return output;
    }
}