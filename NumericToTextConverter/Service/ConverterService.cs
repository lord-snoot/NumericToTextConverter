using System.Text.Encodings.Web;
using NumericToTextConverter.Models;
using NumericToTextConverter.Models.Constants;
using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Service;

public class ConverterService : IConverterService
{
    private static readonly string ErrorEmpty = "Please provide a number with up to two decimals.";
    private static readonly string ErrorInvalid = "Invalid number: ";
    private static readonly string ErrorDecimals = "Number can not have more than two decimals.";
    
    public ConverterService()
    {
        
    }
    
    public string Convert(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return ErrorEmpty;
        }
        else if (decimal.TryParse(input, out decimal number))
        {
            //Parse back into a string to remove any trailing zeroes
            string numberString = number.ToString();
            
            if (numberString.Contains(NumericTextConstants.DecimalSeparator))
            {
                string[] decimalSplit = numberString.Split(NumericTextConstants.DecimalSeparator);
                string decimalString = decimalSplit[1];
                
                if (decimalString.Length > NumericTextConstants.MaxDecimals)
                {
                    return ErrorInvalid + input + ". " + ErrorDecimals;
                }
            }
            
            return new NumericText(numberString).GetText();
        }
        else
        {
            return ErrorInvalid + input + ". " + ErrorEmpty;
        }
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