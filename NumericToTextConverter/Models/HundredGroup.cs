namespace NumericToTextConverter.Models;

public class HundredGroup
{
    public HundredGroup(string number)
    {
        List<string> numberList = number.Split("").ToList();
        numberList.Reverse();
        Ones = int.Parse(numberList[0]);
        
        if (numberList.Count > 1)
        {
            Tens = int.Parse(numberList[1]);
        }

        if (numberList.Count > 2)
        {
            Hundreds = int.Parse(numberList[2]);
        }
    }

    private int Ones {get; set;}
    private int Tens {get; set;}
    private int Hundreds {get; set;}
}