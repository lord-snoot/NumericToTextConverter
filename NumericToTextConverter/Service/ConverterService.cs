using System.Text.Encodings.Web;
using NumericToTextConverter.Models.Constants;

namespace NumericToTextConverter.Service;

public class ConverterService
{
    public ConverterService()
    {
        
    }
    
    public string Convert(string input)
    {
        
        
        List<string> inputGroups = new List<string>();
        for (int i = input.Length; i > 0; i-= NumericTextConstants.GroupSize)
        {
            if (i > NumericTextConstants.GroupSize)
            {
                inputGroups.Add(input.Substring(
                    i - NumericTextConstants.GroupSize, 
                    NumericTextConstants.GroupSize)
                );
            }
            else
            {
                inputGroups.Add(input.Substring(0, i));
            }
        }

        inputGroups.Reverse();
        
        return string.Join(",", inputGroups);
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