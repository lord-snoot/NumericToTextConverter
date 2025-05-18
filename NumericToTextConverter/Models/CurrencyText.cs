using System.Text;
using NumericToTextConverter.Models.Constants;
using NumericToTextConverter.Models.Enum;

namespace NumericToTextConverter.Models;

public class CurrencyText : NumericText
{
    public CurrencyText(string numberString) : base(numberString)
    {

    }

    public override string GetText()
    {
        StringBuilder builder = new StringBuilder();
        if (WholeGroups.Count > 0)
        {
            builder.Append(GetWholeGroupsText());
            builder.Append(CurrencyTextConstants.Space);
            builder.Append(CurrencyTextConstants.Dollar);
            if (!GetWholeGroupsText().Equals(nameof(OnesNames.ONE)))
            {
                builder.Append(CurrencyTextConstants.Plural);
            }
        }

        if (DecimalGroups.Count > 0)
        {
            if (WholeGroups.Count > 0)
            {
                builder.Append(CurrencyTextConstants.Space);
                builder.Append(CurrencyTextConstants.Decimal);
                builder.Append(CurrencyTextConstants.Space);
            }
            
            builder.Append(GetDecimalGroupsText());
            builder.Append(CurrencyTextConstants.Space);
            builder.Append(CurrencyTextConstants.Cent);
            if (!GetDecimalGroupsText().Equals(nameof(OnesNames.ONE)))
            {
                
                builder.Append(CurrencyTextConstants.Plural);
            }
        }
        return builder.ToString();
    }
}