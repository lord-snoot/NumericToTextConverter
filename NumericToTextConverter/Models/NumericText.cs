namespace NumericToTextConverter.Models;

public class NumericText
{
    private Dictionary<int, HundredGroup> HundredGroups = new Dictionary<int, HundredGroup>();

    public void AddHundredGroup(int pos, HundredGroup hundredGroup)
    {
        HundredGroups.Add(pos, hundredGroup);
    }
}