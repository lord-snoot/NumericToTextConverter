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
            
            builder.Append(GetHundredGroupsText(WholeGroups.Values));
            builder.Append(CurrencyTextConstants.Space);
            builder.Append(CurrencyTextConstants.Dollar);
            if (!GetHundredGroupsText(WholeGroups.Values).Equals(nameof(OnesNames.ONE)))
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
            
            builder.Append(GetHundredGroupsText(DecimalGroups.Values));
            builder.Append(CurrencyTextConstants.Space);
            builder.Append(CurrencyTextConstants.Cent);
            if (!GetHundredGroupsText(DecimalGroups.Values).Equals(nameof(OnesNames.ONE)))
            {
                
                builder.Append(CurrencyTextConstants.Plural);
            }
        }
        return builder.ToString();
    }
}